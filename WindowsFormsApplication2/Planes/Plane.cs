using SymulatorLotniska.ZarzadzanieSamolotami;
using System.Windows.Forms;
using System;

namespace SymulatorLotniska.Planes
{
    /*
        Klasa abstrakcyjna, poniewaz samolot musi miec jakis typ.
    */
    public abstract class Plane : PlaneImage
    {
        public static int IDcounter = 0;

        //---parametry techniczne
        private int maxFuelLevel;
        private int takeoffTime;           //w tickach
        private int technicalInspectionTime;         //w tickach
        private int fuelUsage;         // co ile tickow spala 1l
        private string model;
        private int ID;        
        //-----------------------

        //---zmienne okreslajace stan
        private State currentState;
        private int currentFuelLevel;
        private int currentTechnicalInspectionProgress;
        private bool afterTechnicalInspection;
        //---------------------------

        //---gettery i settery
        public int getMaxFuelLevel()  { return maxFuelLevel; }
        public void setMaxFuelLevel(int maxFuelLevel) { this.maxFuelLevel = maxFuelLevel; }
        public int getTakeoffTime() { return takeoffTime; }
        public void setTakeoffTime(int takeoffTime) { this.takeoffTime = takeoffTime; }
        public int getID() { return ID; }
        public string getModel() { return model; }
        public void setModel(string model) { this.model = model; }
        public string getModelID() { return model + " (ID: " + ID + ")"; }
        public int getCurrentTechnicalInspectionProgress() { return currentTechnicalInspectionProgress; }
        public void setAfterTechnicalInspection(bool afterTechnicalInspection)
        {
            this.afterTechnicalInspection = afterTechnicalInspection;
        }
        public int getTechnicalInspectionTime() { return technicalInspectionTime; }
        public State getCurrentState() { return currentState; }
        public void setCurrentState(State newState)
        {
                currentState = newState;
                setStateImage(newState);
                handleAirportManager.uaktualnijPrzyciskiJezeliZaznaczony(this);
                handleAirportManager.oswiezInformacjeJezeliZaznaczony(this);
        }
        public int getCurrentFuelLevel() { return currentFuelLevel; }
        public void setCurrentFuelLevel(int fuelLevel) {
            currentFuelLevel = fuelLevel;
            handleAirportManager.oswiezInformacjeJezeliZaznaczony(this);
        }
        public void setCurrentTechnicalInspectionProgress(int progress)
        {
            currentTechnicalInspectionProgress = progress;
            handleAirportManager.oswiezInformacjeJezeliZaznaczony(this);
        }
        public int getFuelUsage() { return fuelUsage; }
        public bool isTanked()
        {
            if (maxFuelLevel == currentFuelLevel) return true;
            return false;
        }
        public bool isAfterTechnicalInspection() { return afterTechnicalInspection; }
        //---------------------------

        //--Konstruktory
        public Plane(AirportManager uchwytMenedzerSamolotow, Control parent)
            : base(uchwytMenedzerSamolotow, parent)
        {
            ID = IDcounter++;
        }
        


        public Plane(AirportManager uchwytMenedzerSamolotow, Control parent, int maksIloscPaliwa, int czasStartu, int czasKontroli, int spalanie, string model)
            : base(uchwytMenedzerSamolotow, parent)
        {
            ID = IDcounter++;

            this.takeoffTime = czasStartu;
            this.model = model;
            this.maxFuelLevel = maksIloscPaliwa;
            this.technicalInspectionTime = czasKontroli;
            this.fuelUsage = spalanie;
            this.currentFuelLevel = 0;
            this.afterTechnicalInspection = false;
       }
       //--------------
         
        abstract public string getInformation();  
    }

}
