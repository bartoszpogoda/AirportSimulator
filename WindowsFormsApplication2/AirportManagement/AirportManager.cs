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
    // Mozna napisać bota, który będzie automatycznie przyjmował przylajtujące samoloty, rozładowywał, tankowal i odsyłał
   
        
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

        private TextBox peopleCount, cargoCount, ammoCount;

        private Hangar hangar;
        private Airspace airspace;
        private List<Runway> runwayList;

        private bool acceptsIncomingPlanes;
        private bool assistant;

        IOperation incommingPlanes;
        IOperation automatedAssistant;

        private AirportManager(AppWindow handleAppWindow) {
            this.handleAppWindow = handleAppWindow;

            runwayList = new List<Runway>();
            pbSelectedPlane = new PictureBox();
            hangar = new Hangar(handleAppWindow.getPanelSamolotow(), 3, 4);
            airspace = new Airspace(handleAppWindow.getPanelSamolotowPowietrze(), 8);

            acceptsIncomingPlanes = false;
            assistant = false;

            incommingPlanes = new OperationIncommingPlanes();
            automatedAssistant = new OperationAssistant();

            peopleCount = handleAppWindow.getPeopleCount();
            cargoCount = handleAppWindow.getCargoCount();
            ammoCount = handleAppWindow.getAmmoCount();

            initPbSelectedPlane();

            runwayList.Add(new Runway(handleAppWindow.getPasStartowy1(), 1));
            runwayList.Add(new Runway(handleAppWindow.getPasStartowy2(), 2));
        }

        public PlaneImage getSelectedPlane() { return selectedPlane; }
        public Hangar getHangar() { return hangar; }
        public Airspace getAirspace() { return airspace; }

        public List<Runway> getRunwayList() { return runwayList; }

        public bool isAcceptingIncommingPlanes() { return acceptsIncomingPlanes; }
        public void setAcceptingIncomingPlanes(bool acceptsIncomingPlanes) {
            if (acceptsIncomingPlanes == false && this.acceptsIncomingPlanes == true)
            {
                OperationManager.getInstance().stopOperation(incommingPlanes);
            }
            else if(acceptsIncomingPlanes == true && this.acceptsIncomingPlanes == false)
                OperationManager.getInstance().addOperation(incommingPlanes);

            this.acceptsIncomingPlanes = acceptsIncomingPlanes;
        }

        public bool isAssistantOn() { return assistant; }
        public void setAsistant(bool assistant)
        {
            if (assistant == false && this.assistant == true)
            {
                OperationManager.getInstance().stopOperation(automatedAssistant);
            }
            else if (assistant == true && this.assistant == false)
                OperationManager.getInstance().addOperation(automatedAssistant);

            this.assistant = assistant;
        }

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
               fuel((Plane)selectedPlane);
        }
        public void inspectTechnically()
        {
            if (selectedPlane is Plane)
                inspectTechnically((Plane)selectedPlane);        
        }
        public void sendAway()
        {
            if (selectedPlane is Plane)
                sendAway((Plane)selectedPlane);
        }
        public void takeOff()
        {
            if (selectedPlane is Plane)
                takeOff((Plane)selectedPlane);
        }
        public void land()
        {
            if (selectedPlane is Plane)
                land((Plane)selectedPlane);
        }
        public void placeOnRunway()
        {
            if (selectedPlane is Plane)
                placeOnRunway((Plane)selectedPlane);
        }
        public void placeInHangar()
        {
            if (selectedPlane is Plane)
                placeInHangar((Plane)selectedPlane);
        }
        /*
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
            if (selectedPlane is Plane && (((Plane)selectedPlane).getCurrentState() == State.OnRunwayBefTakeoff || ((Plane)selectedPlane).getCurrentState() == State.OnRunwayAftLanding))
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
        }*/

        public void fuel(Plane plane)
        {
            OperationManager.getInstance().addOperation(new OperationFueling(plane));
        }
        public void inspectTechnically(Plane plane)
        {
            OperationManager.getInstance().addOperation(new OperationTechnicalInspection(plane));
        }
        public void sendAway(Plane plane)
        {
            if(plane.getCurrentState() == State.InAir)
            {
                if (plane.getCurrentFuelLevel() < (plane.getMaxFuelLevel() / 2))
                {
                    NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie może zostać odesłany ze względu na małą ilość paliwa", NotificationType.Negative);
                }
                else
                {
                    NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " opuszcza przestrzeń powietrzną nad lotniskiem", NotificationType.Positive);

                    airspace.remove(plane);
                    plane.hide();

                    plane.setParent(null);
                    plane = null;

                    refreshInformationPanel();
                    refreshButtonPanel();
                }
            }
        }
        public void takeOff(Plane plane)
        {
            if (plane.getCurrentState() != State.OnRunwayBefTakeoff) return;

            foreach (Runway runway in runwayList)
            {
                if (!runway.isFree() && runway.getPlane() == plane)
                {
                    NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " startuje z pasa startowego nr " + runway.getID() + ".", NotificationType.Neutral);

                    plane.setCurrentState(State.Takeoff);
                    OperationManager.getInstance().addOperation(new OperationTakeoff(plane, runway));
                    return;
                }
            }
        }
        public void land(Plane plane)
        {
            if (plane.getCurrentState() != State.InAir) return;

            foreach (Runway runway in runwayList)
            {
                if (runway.isFree())
                {
                    OperationManager.getInstance().addOperation(new OperationLanding(plane, runway));
                    airspace.remove(plane);
                    runway.setPlane(plane);
                    return;
                }
            }

            if(plane == selectedPlane) NotificationManager.getInstance().addNotification("Wszystkie pasy startowe są aktualnie zajete", NotificationType.Negative);
        }
        public void placeOnRunway(Plane plane)
        {
            if (!plane.isAfterTechnicalInspection() || !(plane.getCurrentState() == State.Hangar))
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie przeszedł kontroli technicznej", NotificationType.Negative);
                return;
            }

            foreach (Runway runway in runwayList)
            {
                if (runway.isFree())
                {
                    plane.setCurrentState(State.OnRunwayBefTakeoff);
                    hangar.remove(plane);
                    runway.setPlane(plane);
                    NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " został umieszczony na pasie startowym nr " + runway.getID() + ".", NotificationType.Neutral);
                    return;
                }
            }

            if(plane == selectedPlane) NotificationManager.getInstance().addNotification("Wszystkie pasy startowe są aktualnie zajete", NotificationType.Negative);
        }
        public void placeInHangar(Plane plane)
        {
            if (plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.OnRunwayAftLanding)
            {
                if (plane is PassengerPlane)
                {
                    if (((PassengerPlane)plane).getCurrentNumberOfPassengers() != 0)
                    {
                        NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie moze zostac umieszczony w hangarze, poniewaz nie zostal opuszczony przez pasazerow.", NotificationType.Negative);
                        return;
                    }
                }

                foreach (Runway runway in runwayList)
                {
                    if (!runway.isFree() && runway.getPlane() == plane)
                    {
                        runway.takeOffCurrentPlane();
                        hangar.addToHangar(plane);
                        plane.setCurrentState(State.Hangar);
                        return;
                    }
                }
            }
        }

        public void loadPeopleOperation()
        {
            if (selectedPlane is Plane)
                loadPeopleOperation((Plane)selectedPlane);
        }
        public void loadCargoOperation()
        {
            if (selectedPlane is Plane)
                loadCargoOperation((Plane)selectedPlane);
        }
        public void loadAmmoOperation()
        {
            if (selectedPlane is Plane)
                loadAmmoOperation((Plane)selectedPlane);
        }
        public void unloadPeopleOperation()
        {
            if (selectedPlane is Plane)
                unloadPeopleOperation((Plane)selectedPlane);
        }
        public void unloadCargoOperation()
        {
            if (selectedPlane is Plane)
                unloadCargoOperation((Plane)selectedPlane);
        }
        public void unloadAmmoOperation()
        {
            if (selectedPlane is Plane)
                unloadAmmoOperation((Plane)selectedPlane);
        }
        public void loadPeopleOperation(Plane plane)
        {
            if (plane is PassengerPlane)
            {
                if(((PassengerPlane)plane).getCurrentState() == State.Loading)
                    return;

                OperationManager.getInstance().addOperation(new OperationLoading(plane, peopleCount));
                return;
            }
               
            NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie jest samolotem pasażerskim", NotificationType.Negative);
        }
        public void loadCargoOperation(Plane plane)
        {
            if (plane is TransportPlane)
            {
                if (((TransportPlane)plane).getCurrentState() == State.Loading)
                    return;

                OperationManager.getInstance().addOperation(new OperationLoading(plane, cargoCount));
                return;
            }

            NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie jest samolotem transportowym", NotificationType.Negative);
        }
        public void loadAmmoOperation(Plane plane)
        {
            if (plane is MilitaryPlane)
            {
                if (((MilitaryPlane)plane).getCurrentState() == State.Loading)
                    return;

                OperationManager.getInstance().addOperation(new OperationLoading(plane, ammoCount));
                return;
            }
            NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie jest samolotem militarnym", NotificationType.Negative);
        }
       
        public void unloadPeopleOperation(Plane plane)
        {
            if (plane is PassengerPlane)
            {
                if (((PassengerPlane)plane).getCurrentState() == State.Unloading)
                    return;

                OperationManager.getInstance().addOperation(new OperationUnloading(plane, peopleCount));
                return;
            }

            NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie jest samolotem pasażerskim", NotificationType.Negative);
        }
        public void unloadCargoOperation(Plane plane)
        {
            if (plane is TransportPlane)
            {
                if (((TransportPlane)plane).getCurrentState() == State.Unloading)
                    return;

                OperationManager.getInstance().addOperation(new OperationUnloading(plane, cargoCount));
                return;
            }

            NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie jest samolotem transportowym", NotificationType.Negative);
        }
        public void unloadAmmoOperation(Plane plane)
        {
            if (plane is MilitaryPlane)
            {
                if (((MilitaryPlane)plane).getCurrentState() == State.Unloading)
                    return;

                OperationManager.getInstance().addOperation(new OperationUnloading(plane, ammoCount));
                return;
            }
            NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie jest samolotem militarnym", NotificationType.Negative);
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
