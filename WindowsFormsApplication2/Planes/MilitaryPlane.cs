using System;
using SymulatorLotniska.AirportManagement;

namespace SymulatorLotniska.Planes
{
    class MilitaryPlane : Plane
    {
        private string weaponType;
        private int maxAmmo;
        private int currentAmmo;

        public MilitaryPlane()
        { }

        public string getWeaponType() { return weaponType; }
        public void setWeaponType(string weaponType) { this.weaponType = weaponType; }

        public int getMaxAmmo() { return maxAmmo; }
        public void setMaxAmmo(int maxAmmo) { this.maxAmmo = maxAmmo; }

        public int getCurrentAmmo() { return currentAmmo; }
        public void setCurrentAmmo(int currentAmmo) {
            this.currentAmmo = currentAmmo;
            AirportManager.getInstance().refreshInformationPanelIfSelected(this);
        }


        public override string getInformation() // do ogarniecia bo za duzo kodu sie powtarza
        {
            string builtString = "";

            builtString += "Model: " + getModel() + " (ID: " + getID() + ")\n";
            builtString += "Typ: Samolot wojskowy\n";

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
                    builtString += "Stan: " + "Zbrojenie\n";
                    break;
                case State.Unloading:
                    builtString += "Stan: " + "Rozbrajanie\n";
                    break;

            }

            builtString += "Paliwo: " + getCurrentFuelLevel() + "/" + getMaxFuelLevel() + "l\n";
            builtString += "Po kontroli technicznej: " + (isAfterTechnicalInspection() ? "Tak" : "Nie") + "\n";
            builtString += "Rodzaj broni: " + weaponType + "\n";
            builtString += "Ilość amunicji: " + currentAmmo + "/" + maxAmmo + "\n";

            return builtString;
        }
    }
}
