using SymulatorLotniska.Planes;
using SymulatorLotniska.ZarzadzanieSamolotami;
using SymulatorLotniska.ZarzadzaniePowiadomieniami;

namespace SymulatorLotniska.Operacje
{
    class OperationTakeoff : IOperation
    {
        private Plane plane;
        private PasStartowy runway;
        private AirportManager handleAirportManager;

        private int fuelUsageInterval;
        private int fuelUsageIntervalTimer;

        public OperationTakeoff(Plane plane, PasStartowy runway, AirportManager handleAirportManager)
        {
            this.plane = plane;
            this.runway = runway;
            this.handleAirportManager = handleAirportManager;

            if(plane.getCurrentState() == State.OnRunwayBefTakeoff) 
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " startuje z pasa startowego nr " + runway.getID(), NotificationType.Normal);
                plane.setCurrentState(State.Takeoff);
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
                plane.setCurrentState(State.Destroyed);
                return false;
            }

            if (runway.tick())
            {
                return true;
            }
            else
            {
                handleAirportManager.umiescWPowietrzu(plane);
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " wzniósł się w powietrze. Teraz znajduje się w przestrzeni powietrznej nad lotniskiem", NotificationType.Positive);
            }
            return false;
                    
        }

        public override void stop() { }
    }
}
