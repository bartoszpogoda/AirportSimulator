using SymulatorLotniska.AirportManagement;
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
            string budowanyString = "";       

            budowanyString += "Model: " + getModel() + " (ID: " + getID() + ")\n";
            budowanyString += "Typ: Samolot osobowy \n";

            switch (getCurrentState())
            {
                case State.Hangar:
                    budowanyString += "Stan: " + "W hangarze\n";
                    budowanyString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
                    budowanyString += "Po kontroli technicznej: " + (isAfterTechnicalInspection() ? "Tak" : "Nie") + "\n";
                    break;
                case State.Fueling:
                    budowanyString += "Stan: " + "Tankowanie\n";
                    budowanyString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
                    break;
                case State.TechnicalInspection:
                    budowanyString += "Stan: " + "Podczas kontroli technicznej\n";
                    budowanyString += "Postep: " + (int)(100*(double)getCurrentTechnicalInspectionProgress() / getTechnicalInspectionTime()) + "%\n";
                    break;
                case State.InAir:
                    budowanyString += "Stan: " + "W locie nad lotniskiem\n";
                    budowanyString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
                    budowanyString += "Pasazerow: " + currentNumberOfPassengers + "/" + maxNumberOfPassengers + "\n";
                    break;
                case State.Landing:
                    budowanyString += "Stan: " + "Lądowanie\n";
                    budowanyString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
                    budowanyString += "Pasazerow: " + currentNumberOfPassengers + "/" + maxNumberOfPassengers + "\n";
                    break;
                case State.OnRunwayAftLanding:
                    budowanyString += "Stan: " + "Po wylądowaniu\n";
                    budowanyString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
                    budowanyString += "Pasazerow: " + currentNumberOfPassengers + "/" + maxNumberOfPassengers + "\n";
                    break;
                case State.OnRunwayBefTakeoff:
                    budowanyString += "Stan: " + "Przed startem\n";
                    budowanyString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
                    budowanyString += "Pasazerow: " + currentNumberOfPassengers + "/" + maxNumberOfPassengers + "\n";
                    break;
                case State.Takeoff:
                    budowanyString += "Stan: " + "Startowanie\n";
                    budowanyString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
                    budowanyString += "Pasazerow: " + currentNumberOfPassengers + "/" + maxNumberOfPassengers + "\n";
                    break;

            }

            return budowanyString;
        }
    }
}
