using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymulatorLotniska.Planes;
using SymulatorLotniska.AirportManagement;
using SymulatorLotniska.NotificationManagement;

namespace SymulatorLotniska.Operations
{
    class OperationInAir : IOperation
    {
        private Plane plane;

        private int fuelUsageInterval;
        private int fuelUsageIntervalTimer;

        public OperationInAir(Plane plane)
        {
            this.plane = plane;
            fuelUsageIntervalTimer = 0;
            fuelUsageInterval = plane.getFuelUsage();

            plane.setCurrentState(State.InAir);
        }
        
        public override Plane getPlane() { return plane; }

        public override bool execute()
        {
            if (plane.getCurrentState() != State.InAir) return false;

            if (++fuelUsageIntervalTimer >= fuelUsageInterval)
            {
                plane.setCurrentFuelLevel(plane.getCurrentFuelLevel() - 1);
                fuelUsageIntervalTimer = 0;
            }
            
            if (plane.getCurrentFuelLevel() <= 0)
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " rozbił się w przestrzeni powietrznej nad lotniskiem.", NotificationType.Negative);
                plane.setCurrentState(State.Destroyed);
                return false;
            }

            return true;
         }

        public override void stop() { }
    }
}
