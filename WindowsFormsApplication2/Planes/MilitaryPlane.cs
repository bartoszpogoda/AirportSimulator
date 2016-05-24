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

        

        public override string getInformation()
        {
            throw new NotImplementedException();
        }
    }
}
