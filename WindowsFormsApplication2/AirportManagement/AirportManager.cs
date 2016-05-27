using SymulatorLotniska.Operations;
using SymulatorLotniska.Planes;
using SymulatorLotniska.OperationManagement;
using System.Drawing;
using System.Windows.Forms;
using System;
using SymulatorLotniska.NotificationManagement;
using System.Collections.Generic;

namespace SymulatorLotniska.AirportManagement
{
    // FAJNE JAKBY ZROBIC OPERACJE ZE CO JAKIS CZAS PRZYLATUJE LOSOWY SAMOLOT ( Z JAKIEJS LISTY SAMOLOTOW)
    //TODO: W setCurrentState mozna dodac ifa ktory sprawdza czy samolot sie zniszczyl i wtedy ewentualnie robi cos ciekawego
    public class AirportManager
    {
        private static AirportManager instance;

        public static void init(AppWindow handleAppWindow)
        {
            if (instance == null) instance = new AirportManager(handleAppWindow);
        }

        public static AirportManager getInstance()
        {
            if (instance == null) throw new Exception("AirportManager nie zostal zainicjalizowany");
            return instance;
        }

        private AppWindow handleAppWindow;

        private PlaneImage selectedPlane;
        private PictureBox pbSelectedPlane;

        private Hangar hangar;
        private Airspace airspace;
        private List<Runway> runwayList;

        private AirportManager(AppWindow handleAppWindow) {
            this.handleAppWindow = handleAppWindow;

            runwayList = new List<Runway>();
            pbSelectedPlane = new PictureBox();
            hangar = new Hangar(handleAppWindow.getPanelSamolotow(), 3, 4);
            airspace = new Airspace(handleAppWindow.getPanelSamolotowPowietrze(), 8);

            initPbSelectedPlane();

            runwayList.Add(new Runway(handleAppWindow.getPasStartowy1(), 1));
            runwayList.Add(new Runway(handleAppWindow.getPasStartowy2(), 2));
        }

        public PlaneImage getSelectedPlane() { return selectedPlane; }
        public Hangar getHangar() { return hangar; }
        public Airspace getAirspace() { return airspace; }

        private void initPbSelectedPlane()
        {
            if (pbSelectedPlane == null || handleAppWindow == null) return;

            pbSelectedPlane.Image = (Image)Properties.Resources.ResourceManager.GetObject(Constants.adresZnacznik);
            pbSelectedPlane.BackColor = Color.Transparent;
            pbSelectedPlane.Location = new Point(0, 0);
            pbSelectedPlane.Enabled = false;
            pbSelectedPlane.Visible = false;
            pbSelectedPlane.Size = new Size(Constants.imageSize, Constants.imageSize);
            pbSelectedPlane.Parent = handleAppWindow;
        }
        public void refreshPbSelectedIfSelected(PlaneImage samolot)
        {
            if (selectedPlane == samolot)
                pbSelectedPlane.Parent = selectedPlane.getCurrentOnTop();
        }
        public void refreshInformationPanel()
        {
            if (selectedPlane is Plane)
            {
                handleAppWindow.getLabelInformacje().Text = ((Plane)selectedPlane).getInformation();
            }
            else
                handleAppWindow.getLabelInformacje().Text = "Wybierz samolot";
        }
        public void refreshInformationPanelIfSelected(Plane samolot)
        {
            if (selectedPlane is Plane && selectedPlane == samolot)
            {
                handleAppWindow.getLabelInformacje().Text = ((Plane)selectedPlane).getInformation();
            }
        }
        public void refreshButtonPanel()
        {
            handleAppWindow.refreshButtonPanel(selectedPlane);
        }
        public void refreshButtonPanelIfSelected(Plane samolot)
        {
            if (selectedPlane is Plane && ((Plane)selectedPlane) == samolot)
            {
                handleAppWindow.refreshButtonPanel(selectedPlane);
            }
        }
        public void selectPlane(PlaneImage samolot) {
            selectedPlane = samolot;

            pbSelectedPlane.Parent = samolot.getCurrentOnTop();
            pbSelectedPlane.Location = new Point(0, 0);

            if (samolot.isVisible()) pbSelectedPlane.Visible = true;
            refreshInformationPanel();
            refreshButtonPanel();
        }
        public void redraw()
        {
            hangar.redraw();
            airspace.redraw();
        }

        //--------------------------------------------------------------------
        //--------------------------------------------------------------------
        //--------   OPERACJE NA ZAZNACZONYM AKTUALNIE SAMOLOCIE -------------

        public void fuel()
        {
            if (selectedPlane is Plane)
                OperationManager.getInstance().addOperation(new OperationFueling((Plane)selectedPlane));
        }
        public void inspectTechnically()
        {
            if (selectedPlane is Plane)
                OperationManager.getInstance().addOperation(new OperationTechnicalInspection((Plane)selectedPlane));
        }
        public void sendAwaySelected()
        {
            if (selectedPlane is Plane && ((Plane)selectedPlane).getCurrentState() == State.InAir)
            {
                if (((Plane)selectedPlane).getCurrentFuelLevel() < ((Plane)selectedPlane).getMaxFuelLevel()/2 ) 
                {
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie może zostać odesłany ze względu na małą ilość paliwa", NotificationType.Negative);
                }
                else
                {
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " opuszcza przestrzeń powietrzną nad lotniskiem", NotificationType.Positive);
                    
                    airspace.remove((Plane)selectedPlane);
                    ((Plane)selectedPlane).hide();

                    selectedPlane.setParent(null);
                    selectedPlane = null;

                    refreshInformationPanel();
                    refreshButtonPanel();
                }
            }
        }
        public void takeoffSelectedPlane()
        {
            if (!(selectedPlane is Plane) || ((Plane)selectedPlane).getCurrentState() != State.OnRunwayBefTakeoff) return;
            
            foreach (Runway runway in runwayList)
            {
                if (!runway.isFree() && runway.getPlane() == (Plane)selectedPlane)
                {
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " startuje z pasa startowego nr " + runway.getID() + ".", NotificationType.Neutral);

                    ((Plane)selectedPlane).setCurrentState(State.Takeoff);
                    OperationManager.getInstance().addOperation(new OperationTakeoff((Plane)selectedPlane, runway));
                    return;
                }
            }
        }
        public void landSelectedPlane()
        {
            if (!(selectedPlane is Plane) || ((Plane)selectedPlane).getCurrentState() != State.InAir) return;

            foreach (Runway runway in runwayList)
            {
                if (runway.isFree())
                {
                    OperationManager.getInstance().addOperation(new OperationLanding((Plane)selectedPlane, runway));
                    airspace.remove((Plane)selectedPlane);
                    runway.setPlane((Plane)selectedPlane);
                    return;
                }
            }

            NotificationManager.getInstance().addNotification("Wszystkie pasy startowe są aktualnie zajete", NotificationType.Negative);
        }
        public void placeSelectedOnRunway()
                {
                    if (!(selectedPlane is Plane) || !((Plane)selectedPlane).isAfterTechnicalInspection() || !(((Plane)selectedPlane).getCurrentState() == State.Hangar))
                    {
                        NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie przeszedł kontroli technicznej", NotificationType.Negative);
                        return;
                    }

                    foreach (Runway runway in runwayList)
                    {
                        if (runway.isFree())
                        {
                            ((Plane)selectedPlane).setCurrentState(State.OnRunwayBefTakeoff);
                            hangar.remove((Plane)selectedPlane);
                            runway.setPlane((Plane)selectedPlane);
                            NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " został umieszczony na pasie startowym nr " + runway.getID() + ".", NotificationType.Neutral);
                            return;
                        }
                    }
            
                    NotificationManager.getInstance().addNotification("Wszystkie pasy startowe są aktualnie zajete", NotificationType.Negative);
                }
        public void placeSelectedInHangar()
        {
            if (selectedPlane is Plane && ((Plane)selectedPlane).getCurrentState() == State.OnRunwayBefTakeoff)
            {
                if (selectedPlane is PassengerPlane)
                {
                    if (((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() != 0)
                    {
                        NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie moze zostac umieszczony w hangarze, poniewaz nie zostal opuszczony przez pasazerow.", NotificationType.Negative);
                        return;
                    }
                }

                foreach (Runway runway in runwayList)
                {
                    if (!runway.isFree() && runway.getPlane() == selectedPlane)
                    {
                        runway.takeOffCurrentPlane();
                        hangar.addToHangar((Plane)selectedPlane);
                        ((Plane)selectedPlane).setCurrentState(State.Hangar);
                        return;
                    }
                }
            }
        }
        
        public void loadPeopleOperation(TextBox handleTextBox)
        {
            if (selectedPlane is PassengerPlane)
            {
                if(((PassengerPlane)selectedPlane).getCurrentState() == State.Loading)
                    return;

                OperationManager.getInstance().addOperation(new OperationLoading((Plane)selectedPlane, handleTextBox));
                return;
            }
               
            NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem pasażerskim", NotificationType.Negative);
        }
        public void loadCargoOperation(TextBox handleTextBox)
        {
            if (selectedPlane is TransportPlane)
            {
                if (((TransportPlane)selectedPlane).getCurrentState() == State.Loading)
                    return;

                OperationManager.getInstance().addOperation(new OperationLoading((Plane)selectedPlane, handleTextBox));
                return;
            }

            NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem transportowym", NotificationType.Negative);
        }
        public void loadAmmoOperation(TextBox handleTextBox)
        {
            if (selectedPlane is MilitaryPlane)
            {
                if (((MilitaryPlane)selectedPlane).getCurrentState() == State.Loading)
                    return;

                OperationManager.getInstance().addOperation(new OperationLoading((Plane)selectedPlane, handleTextBox));
                return;
            }
            NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem militarnym", NotificationType.Negative);
        }
       
        public void unloadPeopleOperation(TextBox handleTextBox)
        {
            if (selectedPlane is PassengerPlane)
            {
                if (((PassengerPlane)selectedPlane).getCurrentState() == State.Unloading)
                    return;

                OperationManager.getInstance().addOperation(new OperationUnloading((Plane)selectedPlane, handleTextBox));
                return;
            }

            NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem pasażerskim", NotificationType.Negative);
        }
        public void unloadCargoOperation(TextBox handleTextBox)
        {
            if (selectedPlane is TransportPlane)
            {
                if (((TransportPlane)selectedPlane).getCurrentState() == State.Unloading)
                    return;

                OperationManager.getInstance().addOperation(new OperationUnloading((Plane)selectedPlane, handleTextBox));
                return;
            }

            NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem transportowym", NotificationType.Negative);
        }
        public void unloadAmmoOperation(TextBox handleTextBox)
        {
            if (selectedPlane is MilitaryPlane)
            {
                if (((MilitaryPlane)selectedPlane).getCurrentState() == State.Unloading)
                    return;

                OperationManager.getInstance().addOperation(new OperationUnloading((Plane)selectedPlane, handleTextBox));
                return;
            }
            NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem militarnym", NotificationType.Negative);
        }

        public bool addSinglePerson()
        {
            if (selectedPlane == null)
            {
                NotificationManager.getInstance().addNotification("Najpierw zaznacz samolot", NotificationType.Negative);
                return false;
            }
            if (!(selectedPlane is PassengerPlane))
            {
                NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem pasażerskim", NotificationType.Negative);
                return false;
            }

            if (!(((Plane)selectedPlane).getCurrentState() == State.OnRunwayBefTakeoff))
            {
                NotificationManager.getInstance().addNotification("Pasażerowie do samolotu mogą wchodzić tylko na pasie startowym przed startem", NotificationType.Negative);
                return false;
            }

            if (((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() + 1 <= ((PassengerPlane)selectedPlane).getMaxNumberOfPassengers())
            {
                ((PassengerPlane)selectedPlane).setCurrentNumberOfPassengers(((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() + 1);
                return true;
            }

            return false;
        }
        public bool addSingleAmmo()
        {
            if (selectedPlane == null)
            {
                NotificationManager.getInstance().addNotification("Najpierw zaznacz samolot", NotificationType.Negative);
                return false;
            }
            if (!(selectedPlane is MilitaryPlane))
            {
                NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem militarnym", NotificationType.Negative);
                return false;
            }

            if (!(((Plane)selectedPlane).getCurrentState() == State.OnRunwayBefTakeoff || ((Plane)selectedPlane).getCurrentState() == State.Hangar))
            {
                NotificationManager.getInstance().addNotification("W tym momencie nie można naładować broni.", NotificationType.Negative);
                return false;
            }

            if (((MilitaryPlane)selectedPlane).getCurrentAmmo() + 1 <= ((MilitaryPlane)selectedPlane).getMaxAmmo())
            {
                ((MilitaryPlane)selectedPlane).setCurrentAmmo(((MilitaryPlane)selectedPlane).getCurrentAmmo() + 1);
                return true;
            }

            return false;
        }
        public bool addSingleCargo()
        {
            if (selectedPlane == null)
            {
                NotificationManager.getInstance().addNotification("Najpierw zaznacz samolot", NotificationType.Negative);
                return false;
            }
            if (!(selectedPlane is TransportPlane))
            {
                NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem transportowym", NotificationType.Negative);
                return false;
            }

            if (!(((Plane)selectedPlane).getCurrentState() == State.OnRunwayBefTakeoff || ((Plane)selectedPlane).getCurrentState() == State.Hangar))
            {
                NotificationManager.getInstance().addNotification("Teraz nie można załadować towaru", NotificationType.Negative);
                return false;
            }

            if (((TransportPlane)selectedPlane).getCurrentStorageContent() + 1 <= ((TransportPlane)selectedPlane).getMaxStorageCapacity())
            {
                ((TransportPlane)selectedPlane).setCurrentStorageContent(((TransportPlane)selectedPlane).getCurrentStorageContent() + 1);
                return true;
            }


            return false;
        }
        
    }
}
