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
    //TODO: Klase MenedzerSamolotow oraz MendzerOperacji mozna zrobic jako singleton. (podobnie jak MenedzerPowiadomien)
    //TODO: SKoro odnalazlem ten bład moze jednak lepiej bedzie rozdzielic operacje lotu, startowania itp?
    //      ^ polaczenie tych 3 ze soba jest juz niewygodne gdy trzeba dodac informacje do operacji na temat wolnego
    //        pasa startowego.
    //TODO: W setCurrentState mozna dodac ifa ktory sprawdza czy samolot sie zniszczyl i wtedy ewentualnie robi cos ciekawego
    public class AirportManager
    {
        private PlaneImage selectedPlane;
        private PictureBox pbSelectedPlane;

        private AppWindow handleAppWindow;
        private OperationManager handleOperationManager;

        private Hangar hangar;
        private Airspace airspace;
        private List<Runway> pasyStartowe;
                
        public AirportManager(AppWindow handleAppWindow, OperationManager handleOperationManager) {
            this.handleAppWindow = handleAppWindow;
            this.handleOperationManager = handleOperationManager;

            pasyStartowe = new List<Runway>();
            hangar = new Hangar(handleAppWindow.getPanelSamolotow(), 3, 4);
            airspace = new Airspace(handleAppWindow.getPanelSamolotowPowietrze(), 8);
            
            pbSelectedPlane = new PictureBox();
            initializePbSelectedPlane();

            pasyStartowe.Add(new Runway(handleAppWindow.getPasStartowy1(), 1));
            pasyStartowe.Add(new Runway(handleAppWindow.getPasStartowy2(), 2));
        }
        
        public PlaneImage getZaznaczony() { return selectedPlane; }

        public Hangar getHangar() { return hangar; }
        public Airspace getAirspace() { return airspace; }

        private void initializePbSelectedPlane()
        {
            if (pbSelectedPlane == null || handleAppWindow == null) return;

            pbSelectedPlane.Image = (Image)Properties.Resources.ResourceManager.GetObject(ConfigurationConstants.adresZnacznik);
            pbSelectedPlane.BackColor = Color.Transparent;
            pbSelectedPlane.Location = new Point(0, 0);
            pbSelectedPlane.Enabled = false;
            pbSelectedPlane.Visible = false;
            pbSelectedPlane.Size = new Size(ConfigurationConstants.imageSize, ConfigurationConstants.imageSize);
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
        public void dbgDodajSamolot(int i) { // Funkcja do usuniecia jak bedzie kreator
            if (i == 1) wygenerujLosowySamolotWPowietrzu();
            else
            {
                hangar.addToHangar(new PassengerPlane(this, handleAppWindow.getPanelSamolotow(), 50, 50, 1 , 30, 100, "Boen4ing707"));
            }
        }

        public void wygenerujLosowySamolotWPowietrzu() { // DO usuniecia jak bedzie kreator
            Plane samolot = new PassengerPlane(this, handleAppWindow.getPanelSamolotowPowietrze(), 20, 20, 500, 30, 100, "Tupolew");
            samolot.setCurrentState(State.InAir);
            samolot.setCurrentFuelLevel(samolot.getMaxFuelLevel()); // to pozniej bedzie losowe
            airspace.addToAirspace(samolot);
            handleOperationManager.addOperation(new OperationInAir(samolot));
            //narysujSamolotyZListyPowietrze();
        }
        

        public OperationManager getMenedzerOperacji() { return handleOperationManager; }
        


        

        public void zaznaczSamolot(PlaneImage samolot) {
            selectedPlane = samolot;
            
            pbSelectedPlane.Parent = samolot.getCurrentOnTop();
            pbSelectedPlane.Location = new Point(0, 0);

            if (samolot.isVisible()) pbSelectedPlane.Visible = true;

            // zmiana informacji
            //if (samolot is Samolot) uchwytForma.getLabelInformacje().Text = ((Samolot)samolot).wypiszInformacje();
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
                getMenedzerOperacji().addOperation(new OperationFueling((Plane)selectedPlane));
        }
        /// <summary>
        /// rozpoczyna operacje kontroli technicznej zaznaczonego samolotu
        /// </summary>
        public void inspectTechnically()
        {
            if (selectedPlane is Plane)
                getMenedzerOperacji().addOperation(new OperationTechnicalInspection((Plane)selectedPlane));
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
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " zostal odeslany", NotificationType.Normal);

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

            foreach(Runway runway in pasyStartowe)
            {
                if (runway.isFree())
                {
                    ((Plane)selectedPlane).setCurrentState(State.OnRunwayBefTakeoff);
                    hangar.remove((Plane)selectedPlane);
                    runway.setPlane((Plane)selectedPlane);
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " został umieszczony na pasie startowym nr " + runway.getID() + ".", NotificationType.Normal);
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

            foreach (Runway runway in pasyStartowe)
            {
                if (!runway.isFree() && runway.getPlane() == (Plane)selectedPlane)
                {
                    // LOG --Samolot (zaznaczony) startuje z pasa pierwszego.--
                    NotificationManager.getInstance().addNotification("Samolot " + ((Plane)selectedPlane).getModelID() + " startuje z pasa startowego nr " + runway.getID() + ".", NotificationType.Normal);
                            
                    ((Plane)selectedPlane).setCurrentState(State.Takeoff);
                    getMenedzerOperacji().addOperation(new OperationTakeoff((Plane)selectedPlane, runway, this));
                    return;
                }
            }          
        }

        public void landSelectedPlane()
        {
            if (!(selectedPlane is Plane) || ((Plane)selectedPlane).getCurrentState() != State.InAir) return;

            foreach (Runway runway in pasyStartowe)
            {
                if (runway.isFree())
                {
                    getMenedzerOperacji().addOperation(new OperationLanding((Plane)selectedPlane, runway));
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

                foreach (Runway runway in pasyStartowe)
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

        public void wprowadzLudzi(int n)
        {
            if(selectedPlane is PassengerPlane)
            {
                ((PassengerPlane)selectedPlane).setCurrentNumberOfPassengers(((PassengerPlane)selectedPlane).getCurrentNumberOfPassengers() + n);
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

        //--------------------------------------------------------------------
        //--------------------------------------------------------------------
        //--------   OPERACJE NA SAMOLOTACH                      -------------

        public void umiescWPowietrzu(Plane samolot)
        {
            //listaSamolotowPowietrze.dodajSamolot(samolot);
            airspace.addToAirspace(samolot);
            //samolot.getPlaneImage().Parent = handleAppWindow.getPanelSamolotowPowietrze();
            getMenedzerOperacji().addOperation(new OperationInAir(samolot));
            //narysujSamolotyZListyPowietrze();
        }

      
        public void redraw()
        {
            hangar.redraw();
            airspace.redraw();
        }


     
    }
}
