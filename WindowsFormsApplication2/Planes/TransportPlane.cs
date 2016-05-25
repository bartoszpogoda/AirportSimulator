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
        public void setCurrentStorageContent(int storageContent) { currentStorageContent = storageContent; }



        public override string getInformation() // do ogarniecia bo za duzo kodu sie powtarza
        {
            string budowanyString = "";

            budowanyString += "Model: " + getModel() + " (ID: " + getID() + ")\n";
            budowanyString += "Typ: Samolot transportowy\n";

            switch (getCurrentState())
            {
                case State.Hangar:
                    budowanyString += "Stan: " + "W hangarze\n";
                    break;
                case State.Fueling:
                    budowanyString += "Stan: " + "Tankowanie\n";
                    break;
                case State.TechnicalInspection:
                    budowanyString += "Stan: " + "Podczas kontroli technicznej\n";
                    break;
                case State.InAir:
                    budowanyString += "Stan: " + "W locie nad lotniskiem\n";
                    break;
                case State.Landing:
                    budowanyString += "Stan: " + "Lądowanie\n";
                    break;
                case State.OnRunwayAftLanding:
                    budowanyString += "Stan: " + "Po wylądowaniu\n";
                    break;
                case State.OnRunwayBefTakeoff:
                    budowanyString += "Stan: " + "Przed startem\n";
                    break;
                case State.Takeoff:
                    budowanyString += "Stan: " + "Startowanie\n";
                    break;

            }

            budowanyString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
            budowanyString += "Po kontroli technicznej: " + (isAfterTechnicalInspection() ? "Tak" : "Nie") + "\n";
            budowanyString += "Stan załadunku: " + currentStorageContent + "/" + maxStorageCapacity + "kg\n";

            return budowanyString;
        }
    }
}
