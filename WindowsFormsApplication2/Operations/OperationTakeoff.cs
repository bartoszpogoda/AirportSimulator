using SymulatorLotniska.Planes;
using SymulatorLotniska.AirportManagement;
using SymulatorLotniska.NotificationManagement;
using SymulatorLotniska.OperationManagement;

namespace SymulatorLotniska.Operations
{
    class OperationTakeoff : IOperation
    {
        private Plane plane;
        private Runway runway;

        private int fuelUsageInterval;
        private int fuelUsageIntervalTimer;

        public OperationTakeoff(Plane plane, Runway runway)
        {
            this.plane = plane;
            this.runway = runway;

            if(plane.getCurrentState() == State.OnRunwayBefTakeoff) 
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " startuje z pasa startowego nr " + runway.getID(), NotificationType.Neutral);
                plane.setCurrentState(State.Takeoff);
                plane.setAfterTechnicalInspection(false);
            }

            fuelUsageIntervalTimer = 0;
            fuelUsageInterval = plane.getFuelUsage();
        }

        public override Plane getPlane() { return plane; }

        public override bool execute()
        {
            if (plane.getCurrentState() != State.Takeoff) return false;

            if (++fuelUsageIntervalTimer >= fuelUsageInterval)
            {
                plane.setCurrentFuelLevel(plane.getCurrentFuelLevel() - 1);
                fuelUsageIntervalTimer = 0;
            }
            
            if (plane.getCurrentFuelLevel() <= 0)
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " rozbił się przy próbie startu z pasa startowego nr. " + runway.getID() + ".", NotificationType.Negative);
                plane.setCurrentState(State.Destroyed);
                return false;
            }

            if (runway.tick())
            {
                return true;
            }
            else
            {
                AirportManager.getInstance().getAirspace().addToAirspace(plane);

                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " wzniósł się w powietrze. Teraz znajduje się w przestrzeni powietrznej nad lotniskiem", NotificationType.Positive);
            }
            return false;
                    
        }

        public override void stop() { }
    }
}
