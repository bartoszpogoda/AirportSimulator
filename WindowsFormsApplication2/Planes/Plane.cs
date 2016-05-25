using SymulatorLotniska.AirportManagement;
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
        private int takeoffInterval;           //w tickach
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
        public void setFuelUsage(int fuelUsage) { this.fuelUsage = fuelUsage; }
        public int getMaxFuelLevel()  { return maxFuelLevel; }
        public void setMaxFuelLevel(int maxFuelLevel) { this.maxFuelLevel = maxFuelLevel; }
        public int getTakeoffInterval() { return takeoffInterval; }
        public void setTakeoffTime(int takeoffTime) { this.takeoffInterval = takeoffTime; }
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
                handleAirportManager.refreshButtonPanelIfSelected(this);
                handleAirportManager.refreshInformationPanelIfSelected(this);
        }
        public int getCurrentFuelLevel() { return currentFuelLevel; }
        public void setCurrentFuelLevel(int fuelLevel) {
            currentFuelLevel = fuelLevel;
            handleAirportManager.refreshInformationPanelIfSelected(this);
        }
        public void setCurrentTechnicalInspectionProgress(int progress)
        {
            currentTechnicalInspectionProgress = progress;
            handleAirportManager.refreshInformationPanelIfSelected(this);
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
        
        public Plane(AirportManager handleAirportManager) : base(handleAirportManager)
        {
            ID = IDcounter++;

        }

        public Plane(AirportManager uchwytMenedzerSamolotow, Control parent)
            : base(uchwytMenedzerSamolotow, parent)
        {
            ID = IDcounter++;
        }
        


        public Plane(AirportManager uchwytMenedzerSamolotow, Control parent, int maksIloscPaliwa, int czasStartu, int czasKontroli, int spalanie, string model)
            : base(uchwytMenedzerSamolotow, parent)
        {
            ID = IDcounter++;

            this.takeoffInterval = czasStartu;
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
