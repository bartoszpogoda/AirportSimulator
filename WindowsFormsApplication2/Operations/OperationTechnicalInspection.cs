using SymulatorLotniska.Planes;
using SymulatorLotniska.NotificationManagement;

namespace SymulatorLotniska.Operations
{
    class OperationTechnicalInspection : IOperation
    {
        private Plane plane;
        
        public OperationTechnicalInspection(Plane plane) // -1 - pierwsze wykonanie
        {
            this.plane = plane;

            if (plane.isAfterTechnicalInspection())
            {
                NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " już jest po kontroli technicznej.", NotificationType.Normal);
                return;
            }
            if (plane.getCurrentState() == State.Hangar)
                plane.setCurrentState(State.TechnicalInspection);
        }

        public override bool execute()
        {
            if (plane.getCurrentState() != State.TechnicalInspection) return false;

            plane.setCurrentTechnicalInspectionProgress(plane.getCurrentTechnicalInspectionProgress() + 1);

            if (plane.getCurrentTechnicalInspectionProgress() >= plane.getTechnicalInspectionTime())
            {
                plane.setCurrentTechnicalInspectionProgress(0);

                if (plane.isTanked())
                {
                    plane.setAfterTechnicalInspection(true);
                    NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " przeszedł kontrolę techniczną.", NotificationType.Positive);
                }
                else
                {
                    plane.setAfterTechnicalInspection(false);
                    NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " nie przeszedł kontroli technicznej.", NotificationType.Negative);
                }

                plane.setCurrentState(State.Hangar);
                return false;
            }

            return true;
        }

        public override void stop()
        {
            plane.setCurrentTechnicalInspectionProgress(0);
            plane.setCurrentState(State.Hangar);
        }

        public override Plane getPlane() { return plane; }
    }
}
