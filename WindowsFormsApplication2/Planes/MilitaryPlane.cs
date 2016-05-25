using System;
using SymulatorLotniska.AirportManagement;

namespace SymulatorLotniska.Planes
{
    class MilitaryPlane : Plane
    {
        private string weaponType;
        private int maxAmmo;
        private int currentAmmo;

        public MilitaryPlane(AirportManager handleAirportManager): base(handleAirportManager)
        { }

        public string getWeaponType() { return weaponType; }
        public void setWeaponType(string weaponType) { this.weaponType = weaponType; }

        public int getMaxAmmo() { return maxAmmo; }
        public void setMaxAmmo(int maxAmmo) { this.maxAmmo = maxAmmo; }

        public int getCurrentAmmo() { return currentAmmo; }
        public void setCurrentAmmo(int currentAmmo) { this.currentAmmo = currentAmmo; }


        public override string getInformation() // do ogarniecia bo za duzo kodu sie powtarza
        {
            string budowanyString = "";

            budowanyString += "Model: " + getModel() + " (ID: " + getID() + ")\n";
            budowanyString += "Typ: Samolot wojskowy\n";

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
            budowanyString += "Rodzaj broni: " + weaponType + "\n";
            budowanyString += "Ilość amunicji: " + currentAmmo + "/" + maxAmmo + "\n";

            return budowanyString;
        }
    }
}
