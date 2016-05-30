using SymulatorLotniska.Planes;
using SymulatorLotniska.NotificationManagement;

namespace SymulatorLotniska.Operations
{
    class OperationFueling : IOperation
    {
        private Plane plane;
        private int intervalTimer;
        public OperationFueling(Plane plane)
        {
            this.plane = plane;
            intervalTimer = 0;

            if (plane.isTanked())
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " ma już pełny bak.", NotificationType.Neutral);
                return;
            }

            if (plane.getCurrentState() == State.Hangar)
                plane.setCurrentState(State.Fueling);
        }
   
        public override bool execute()
        {
            if (plane.getCurrentState() != State.Fueling) return false;
            
            if (++intervalTimer < Constants.interwalTankowanie) return true;

            intervalTimer = 0;
                    
            plane.setCurrentFuelLevel(plane.getCurrentFuelLevel() + 1);

            if (plane.getCurrentFuelLevel() == plane.getMaxFuelLevel()) // było >=
            {
                //plane.setCurrentFuelLevel(plane.getMaxFuelLevel());
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " zostal zatankowany.", NotificationType.Positive);
                plane.setCurrentState(State.Hangar);
                return false;
            }

            return true; 
        }

        public override void stop()
        {
            plane.setCurrentState(State.Hangar);
        }

        public override Plane getPlane() { return plane; }
    }
}
