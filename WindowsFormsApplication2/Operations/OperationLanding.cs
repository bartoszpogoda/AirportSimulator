using SymulatorLotniska.Planes;
using SymulatorLotniska.AirportManagement;
using SymulatorLotniska.NotificationManagement;

namespace SymulatorLotniska.Operations
{
    class OperationLanding : IOperation
    {
        private Plane plane;
        private Runway runway;

        private int fuelUsageInterval;
        private int fuelUsageIntervalTimer;

        public OperationLanding(Plane plane, Runway runway)
        {
            this.plane = plane;
            this.runway = runway;

            if (plane.getCurrentState() == State.InAir)
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " podchodzi do lądowania na pasie startowym nr " + runway.getID() + ".", NotificationType.Neutral);
                plane.setCurrentState(State.Landing);
            }

            fuelUsageIntervalTimer = 0;
            fuelUsageInterval = plane.getFuelUsage();
        }

        public override Plane getPlane() { return plane; }

        public override bool execute()
        {
            if (plane.getCurrentState() != State.Landing) return false;

            if (++fuelUsageIntervalTimer >= fuelUsageInterval)
            {
                plane.setCurrentFuelLevel(plane.getCurrentFuelLevel() - 1);
                fuelUsageIntervalTimer = 0;
            }

            if (plane.getCurrentFuelLevel() <= 0)
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " rozbił się przy próbie lądowania na pasie startowym nr. " + runway.getID() + ".", NotificationType.Negative);
                plane.setCurrentState(State.Destroyed);
                return false;
            }

            if (runway.tick())
            {
                return true;
            }
            else
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " wylądował na pasie startowym nr " + runway.getID() + ".", NotificationType.Positive);
                plane.setCurrentState(State.OnRunwayAftLanding);
            }
            return false;

        }

        public override void stop() { }
    }
}
