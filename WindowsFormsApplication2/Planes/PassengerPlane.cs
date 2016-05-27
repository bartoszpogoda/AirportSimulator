using SymulatorLotniska.AirportManagement;
using System;
using System.Windows.Forms;

namespace SymulatorLotniska.Planes
{
    class PassengerPlane : Plane
    {
        private int maxNumberOfPassengers;
        private int currentNumberOfPassengers;

        public PassengerPlane( )
        {
            maxNumberOfPassengers = 0;
            currentNumberOfPassengers = 0;
        }
        
        public int getCurrentNumberOfPassengers() { return currentNumberOfPassengers; }
        public int getMaxNumberOfPassengers() { return maxNumberOfPassengers; }
        public void setCurrentNumberOfPassengers(int newNumberOfPassengers) {
            this.currentNumberOfPassengers = newNumberOfPassengers;
            AirportManager.getInstance().refreshInformationPanelIfSelected(this);
        }
        public void setMaxNumberOfPassengers(int maxNumberOfPassengers) { this.maxNumberOfPassengers = maxNumberOfPassengers; }
       
        public override string getInformation() // do ogarniecia bo za duzo kodu sie powtarza
        {
            string builtString = "";
            builtString += "Model: " + getModel() + " (ID: " + getID() + ")\n";
            builtString += "Typ: Samolot osobowy \n";

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
                    builtString += "Stan: " + "Wprowadzanie pasażerów\n";
                    break;
                case State.Unloading:
                    builtString += "Stan: " + "Wyprowadzanie pasażerów\n";
                    break;

            }

            builtString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
            builtString += "Po kontroli technicznej: " + (isAfterTechnicalInspection() ? "Tak" : "Nie") + "\n";
            builtString += "Pasazerow: " + currentNumberOfPassengers + "/" + maxNumberOfPassengers + "\n";

            return builtString;
        }
    }
}
