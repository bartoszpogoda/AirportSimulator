using System;
using SymulatorLotniska.AirportManagement;

namespace SymulatorLotniska.Planes
{
    class TransportPlane : Plane
    {
        private int maxStorageCapacity;
        private int currentStorageContent;
        

        public TransportPlane()
        { }

        public int getMaxStorageCapacity() { return maxStorageCapacity; }
        public void setMaxStorageCapacity(int maxStorageCapacity) { this.maxStorageCapacity = maxStorageCapacity; }

        public int getCurrentStorageContent() { return currentStorageContent;}
        public void setCurrentStorageContent(int storageContent) {
            currentStorageContent = storageContent;
            AirportManager.getInstance().refreshInformationPanelIfSelected(this);
        }

        
        public override string getInformation()
        {
            string builtString = "";

            builtString += "Model: " + getModel() + " (ID: " + getID() + ")\n";
            builtString += "Typ: Samolot transportowy\n";

            switch (getCurrentState())
            {
                case State.Hangar:
                    builtString += "Stan: " + "W hangarze\n";
                    break;
                case State.Fueling:
                    builtString += "Stan: " + "Tankowanie\n";
                    break;
                case State.TechnicalInspection:
                    builtString += "Stan: " + "Podczas kontroli technicznej\n";
                    break;
                case State.InAir:
                    builtString += "Stan: " + "W locie nad lotniskiem\n";
                    break;
                case State.Landing:
                    builtString += "Stan: " + "Lądowanie\n";
                    break;
                case State.OnRunwayAftLanding:
                    builtString += "Stan: " + "Po wylądowaniu\n";
                    break;
                case State.OnRunwayBefTakeoff:
                    builtString += "Stan: " + "Przed startem\n";
                    break;
                case State.Takeoff:
                    builtString += "Stan: " + "Startowanie\n";
                    break;
                case State.Loading:
                    builtString += "Stan: " + "Załadunek towaru\n";
                    break;
                case State.Unloading:
                    builtString += "Stan: " + "Rozładunek towaru\n";
                    break;
                case State.Destroyed:
                    builtString += "Stan: " + "Zniszczony\n";
                    break;
            }

            builtString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
            builtString += "Po kontroli technicznej: " + (isAfterTechnicalInspection() ? "Tak" : "Nie") + "\n";
            builtString += "Stan załadunku: " + currentStorageContent + "/" + maxStorageCapacity + "kg\n";

            return builtString;
        }

        public override bool isEmpty()
        {
            if (currentStorageContent == 0) return true;
            else return false;
        }
    }
}
