using System;
using SymulatorLotniska.AirportManagement;

namespace SymulatorLotniska.Planes
{
    class TransportPlane : Plane
    {
        private int maxStorageCapacity;
        private int currentStorageContent;
        

        public TransportPlane(AirportManager handleAirportManager) : base(handleAirportManager)
        { }

        public int getMaxStorageCapacity() { return maxStorageCapacity; }
        public void setMaxStorageCapacity(int maxStorageCapacity) { this.maxStorageCapacity = maxStorageCapacity; }

        public int getCurrentStorageContent() { return currentStorageContent;}
        public void setCurrentStorageContent(int storageContent) { currentStorageContent = storageContent; }

      

        public override string getInformation()
        {
            throw new NotImplementedException();
        }
    }
}
