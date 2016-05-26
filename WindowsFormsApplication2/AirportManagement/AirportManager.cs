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
            if(instance == null) instance = new AirportManager(handleAppWindow);
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
            
            initializePbSelectedPlane();

            runwayList.Add(new Runway(handleAppWindow.getPasStartowy1(), 1));
            runwayList.Add(new Runway(handleAppWindow.getPasStartowy2(), 2));
        }
        
        public PlaneImage getSelectedPlane() { return selectedPlane; }
        public Hangar getHangar() { return hangar; }
        public Airspace getAirspace() { return airspace; }

        private void initializePbSelectedPlane()
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
            handleAppWindow.uaktualnijPrzyciskiPanelu(selectedPlane);
        }
        public void refreshButtonPanelIfSelected(Plane samolot)
        {
            if (selectedPlane is Plane && ((Plane)selectedPlane) == samolot)
            {
                handleAppWindow.uaktualnijPrzyciskiPanelu(selectedPlane);
            }
        }
        
        

        public void zaznaczSamolot(PlaneImage samolot) {
            selectedPlane = samolot;
            
            pbSelectedPlane.Parent = samolot.getCurrentOnTop();
            pbSelectedPlane.Location = new Point(0, 0);

            if (samolot.isVisible()) pbSelectedPlane.Visible = true;
            refreshInformationPanel();
            refreshButtonPanel();
        }


        //--------------------------------------------------------------------
        //--------------------------------------------------------------------
        //--------   OPERACJE NA ZAZNACZONYM AKTUALNIE SAMOLOCIE -------------
        /// <summary>
        /// rozpoczyna operacje tankowania zaznaczonego samolotu
        /// </summary>
        public void fuel()
        {
            if (selectedPlane is Plane)
                OperationManager.getInstance().addOperation(new OperationFueling((Plane)selectedPlane));
        }
        /// <summary>
        /// rozpoczyna operacje kontroli technicznej zaznaczonego samolotu
        /// </summary>
        public void inspectTechnically()
        {
            if (selectedPlane is Plane)
                OperationManager.getInstance().addOperation(new OperationTechnicalInspection((Plane)selectedPlane));
        }

        public void odeslijZaznaczonySamolot()
        {
            if(selectedPlane is Plane && ((Plane)selectedPlane).getCurrentState() == State.InAir)
            {
                if (false) // warunek odeslania - np za mala ilosc paliwa
                {
                   // LOG --Nie mozna odeslac samolotu (zaznaczony) ze wzgledu na......--
                }
                else
                {
                    // LOG --Samolot (zaznazczony) zostal odeslany--
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " zostal odeslany", NotificationType.Neutral);

                    //listaSamolotowPowietrze.usunSamolot((Plane)selectedPlane);
                    airspace.remove((Plane)selectedPlane);
                    ((Plane)selectedPlane).hide();

                    selectedPlane.setParent(null);
                    selectedPlane = null;

                    refreshInformationPanel();
                    refreshButtonPanel();
                    //narysujSamolotyZListyPowietrze();
                }
            }
        }

        public void placeSelectedOnRunway()
        {
            if (!(selectedPlane is Plane) || !((Plane)selectedPlane).isAfterTechnicalInspection() || !(((Plane)selectedPlane).getCurrentState() == State.Hangar))
            {
                // LOG--Informacje ze nie jest po kontroli technicznej.--
                NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie przeszedł kontroli technicznej", NotificationType.Negative);
                return;
            }

            foreach(Runway runway in runwayList)
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
            
            // LOG--Informacja, ze nie ma wolnych pasów startowych.
            NotificationManager.getInstance().addNotification("Wszystkie pasy startowe są aktualnie zajete", NotificationType.Negative);
            
        }
        public void takeoffSelectedPlane()
        {
            if (!(selectedPlane is Plane) || ((Plane)selectedPlane).getCurrentState() != State.OnRunwayBefTakeoff) return;
            
            if (false) // warunek  czy ludzi jest dobra ilosc i towarow
            {
                // LOG --Samolotu (zaznaczony) nie przeszedl kontroli przed startem. Np jest przeludniony--
                return;
            }

            foreach (Runway runway in runwayList)
            {
                if (!runway.isFree() && runway.getPlane() == (Plane)selectedPlane)
                {
                    // LOG --Samolot (zaznaczony) startuje z pasa pierwszego.--
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " startuje z pasa startowego nr " + runway.getID() + ".", NotificationType.Neutral);
                            
                    ((Plane)selectedPlane).setCurrentState(State.Takeoff);
                    OperationManager.getInstance().addOperation(new OperationTakeoff((Plane)selectedPlane, runway, this));
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

        public void umiescZaznaczonyWHangarze()
        {
            if(selectedPlane is Plane && ((Plane)selectedPlane).getCurrentState() == State.OnRunwayBefTakeoff)
            {
                if (selectedPlane is PassengerPlane)
                {
                    if (((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() != 0)
                    {
                        NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie moze zostac umieszczony w hangarze, poniewaz nie zostal opuszczony przez pasazerow.", NotificationType.Negative);
                        return;
                    }
                }
                // zaznaczony is SamolotTowarowy

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

        public int unload()
        {
            if (selectedPlane is TransportPlane)
            {
                if(((TransportPlane)selectedPlane).getCurrentStorageContent() == 0)
                {
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " jest juz rozładowany", NotificationType.Neutral);
                    return 0;
                }

                int diff = ((TransportPlane)selectedPlane).getCurrentStorageContent();
                ((TransportPlane)selectedPlane).setCurrentStorageContent(0);

                NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " został rozładowany", NotificationType.Positive);

                return diff;
            }

            if(selectedPlane is PassengerPlane)
            {
                if (((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() == 0)
                {
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " jest pusty", NotificationType.Neutral);
                    return 0;
                }

                int diff = ((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers();
                ((PassengerPlane)selectedPlane).setCurrentNumberOfPassengers(0);

                NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " został opuszczony przez pasażerów", NotificationType.Positive);

                return diff;
            }

            return 0;
        }
        public int addCargo(int numberOfCargo, bool toFull)
        {
            if (selectedPlane == null)
            {
                NotificationManager.getInstance().addNotification("Najpierw zaznacz samolot", NotificationType.Negative);

                return 0;
            }
            if (!(selectedPlane is TransportPlane))
            {
                NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem transportowym", NotificationType.Negative);
                return 0;
            }


            TransportPlane plane = ((TransportPlane)selectedPlane);

            if (!(plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.Hangar))
            {
                NotificationManager.getInstance().addNotification("Teraz nie można załadować towaru", NotificationType.Negative);
                return 0;
            }
            if (toFull)
            {
                if (plane.getMaxStorageCapacity() - plane.getCurrentStorageContent() > numberOfCargo)
                {
                    plane.setCurrentStorageContent(plane.getCurrentStorageContent() + numberOfCargo);
                    return numberOfCargo;
                }
                else
                {
                    int difference = plane.getMaxStorageCapacity() - plane.getCurrentStorageContent();
                    plane.setCurrentStorageContent(plane.getMaxStorageCapacity());
                    return difference;
                }
            }
            else
            {
                if (numberOfCargo < 1)
                {
                    return 0;
                }
                if (plane.getCurrentStorageContent() + 1 <= plane.getMaxStorageCapacity())
                {
                    plane.setCurrentStorageContent(plane.getCurrentStorageContent() + 1);
                    return 1;
                }

                return 0;

            }

        }
        public int addPeople(int numberOfPeople, bool toFull)
        {
            if(selectedPlane == null)
            {
                NotificationManager.getInstance().addNotification("Najpierw zaznacz samolot", NotificationType.Negative);

                return 0;
            }
            if(!(selectedPlane is PassengerPlane))
            {
                NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem pasażerskim", NotificationType.Negative);
                return 0;
            }
            

            PassengerPlane plane = ((PassengerPlane)selectedPlane);

            if(!(plane.getCurrentState() == State.OnRunwayBefTakeoff))
            {
                NotificationManager.getInstance().addNotification("Pasażerowie do samolotu mogą wchodzić tylko na pasie startowym przed startem", NotificationType.Negative);
                return 0;
            }
            if (toFull)
            {
                if(plane.getMaxNumberOfPassengers() - plane.getCurrentNumberOfPassengers() > numberOfPeople)
                {
                    plane.setCurrentNumberOfPassengers(plane.getCurrentNumberOfPassengers() + numberOfPeople);
                    return numberOfPeople;
                }
                else
                {
                    int difference = plane.getMaxNumberOfPassengers() - plane.getCurrentNumberOfPassengers();
                    plane.setCurrentNumberOfPassengers(plane.getMaxNumberOfPassengers());
                    return difference;
                }
            }
            else
            {
                if (numberOfPeople < 1)
                {
                    return 0;
                }
                if(plane.getCurrentNumberOfPassengers() + 1 <= plane.getMaxNumberOfPassengers())
                {
                    plane.setCurrentNumberOfPassengers(plane.getCurrentNumberOfPassengers() + 1);
                    return 1;
                }

                return 0;

            }

        }
        public int addAmmo(int numberOfAmmo, bool toFull)
        {
            if (selectedPlane == null)
            {
                NotificationManager.getInstance().addNotification("Najpierw zaznacz samolot", NotificationType.Negative);

                return 0;
            }
            if (!(selectedPlane is MilitaryPlane))
            {
                NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " nie jest samolotem militarnym", NotificationType.Negative);
                return 0;
            }


            MilitaryPlane plane = ((MilitaryPlane)selectedPlane);

            if (!(plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.Hangar))
            {
                NotificationManager.getInstance().addNotification("W tym momencie nie można naładować broni.", NotificationType.Negative);
                return 0;
            }
            if (toFull)
            {
                if (plane.getMaxAmmo() - plane.getCurrentAmmo() > numberOfAmmo)
                {
                    plane.setCurrentAmmo(plane.getCurrentAmmo() + numberOfAmmo);
                    return numberOfAmmo;
                }
                else
                {
                    int difference = plane.getMaxAmmo() - plane.getCurrentAmmo();
                    plane.setCurrentAmmo(plane.getMaxAmmo());
                    return difference;
                }
            }
            else
            {
                if (numberOfAmmo < 1)
                {
                    return 0;
                }
                if (plane.getCurrentAmmo() + 1 <= plane.getMaxAmmo())
                {
                    plane.setCurrentAmmo(plane.getCurrentAmmo() + 1);
                    return 1;
                }

                return 0;

            }

        }
        public void wyprowadzLudzi(int n)
        {
            if (selectedPlane is PassengerPlane)
            {
                if(((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() - n < 0)
                {
                    // LOG --Nie ma tylu pasazerow
                    return;
                }

                ((PassengerPlane)selectedPlane).setCurrentNumberOfPassengers(((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() - n);
            }
        }
        
        public void umiescWPowietrzu(Plane samolot)
        {
            airspace.addToAirspace(samolot);
            OperationManager.getInstance().addOperation(new OperationInAir(samolot));
        }
        
        public void redraw()
        {
            hangar.redraw();
            airspace.redraw();
        }
    }
}
