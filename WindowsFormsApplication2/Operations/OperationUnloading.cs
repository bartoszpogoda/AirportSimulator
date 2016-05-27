using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymulatorLotniska.Planes;
using System.Windows.Forms;
using SymulatorLotniska.NotificationManagement;

namespace SymulatorLotniska.Operations
{
    class OperationUnloading : IOperation
    {
        private Plane plane;
        private TextBox containerCount;
        private State previousState;
        private int intervalTimer;

        public OperationUnloading(Plane plane, TextBox containerCount)
        {
            this.plane = plane;
            this.containerCount = containerCount;
            previousState = plane.getCurrentState();
            intervalTimer = 0;


            if (plane is PassengerPlane)
            {
                if (!(plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.OnRunwayAftLanding))
                {
                    NotificationManager.getInstance().addNotification("Pasażerowie do samolotu mogą wchodzić tylko na pasie startowym", NotificationType.Negative);
                    return;
                }

                if (((PassengerPlane)plane).getCurrentNumberOfPassengers() == 0)
                {
                    NotificationManager.getInstance().addNotification("Samolot " + plane.getModelID() + " jest już pusty", NotificationType.Neutral);
                    return;
                }

                plane.setCurrentState(State.Unloading);
                NotificationManager.getInstance().addNotification("Pasażerowie opuszczają pokład samolotu " + plane.getModelID(), NotificationType.Neutral);
            }
            else if (plane is TransportPlane)
            {
                if (!(plane.getCurrentState() == State.Hangar || plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.OnRunwayAftLanding))
                {
                    NotificationManager.getInstance().addNotification("Teraz nie można wyładować towaru", NotificationType.Negative);
                    return;
                }

                if (((TransportPlane)plane).getCurrentStorageContent() == 0)
                {
                    NotificationManager.getInstance().addNotification("Samolot jest rozładowany", NotificationType.Neutral);
                    return;
                }

                plane.setCurrentState(State.Unloading);
                NotificationManager.getInstance().addNotification("Rozpoczęto rozładunek samolotu " + plane.getModelID(), NotificationType.Neutral);
            }
            else
            {
                if (!(plane.getCurrentState() == State.Hangar || plane.getCurrentState() == State.OnRunwayBefTakeoff || plane.getCurrentState() == State.OnRunwayAftLanding))
                {
                    NotificationManager.getInstance().addNotification("Teraz nie można rozbroić samolotu " + plane.getModelID(), NotificationType.Negative);
                    return;
                }

                if (((MilitaryPlane)plane).getCurrentAmmo() == 0)
                {
                    NotificationManager.getInstance().addNotification("Samolot " + plane.getModel() + " jest już rozbrojony", NotificationType.Neutral);
                    return;
                }

                plane.setCurrentState(State.Unloading);
                NotificationManager.getInstance().addNotification("Rozpoczęto rozbrajanie samolotu " + plane.getModelID(), NotificationType.Neutral);
            }
        }


        public override bool execute()
        {
            if (plane.getCurrentState() != State.Unloading) return false;

            if (++intervalTimer < Constants.intervalLoading) return true;

            intervalTimer = 0;

            if (plane is PassengerPlane)
            {
                if (((PassengerPlane)plane).getCurrentNumberOfPassengers() == 0)
                {
                    NotificationManager.getInstance().addNotification("Samolot osobowy " + plane.getModelID() + " został opuszczony przez pasażerów", NotificationType.Positive);
                    plane.setCurrentState(previousState);
                    return false;
                }
                
                ((PassengerPlane)plane).setCurrentNumberOfPassengers(((PassengerPlane)plane).getCurrentNumberOfPassengers() - 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) + 1).ToString();
            }
            else if (plane is TransportPlane)
            {
                if (((TransportPlane)plane).getCurrentStorageContent() == 0)
                {
                    NotificationManager.getInstance().addNotification("Samolot transportowy " + plane.getModelID() + "został rozładowany", NotificationType.Positive);
                    plane.setCurrentState(previousState);
                    return false;
                }
                
                ((TransportPlane)plane).setCurrentStorageContent(((TransportPlane)plane).getCurrentStorageContent() - 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) + 1).ToString();
            }
            else if (plane is MilitaryPlane)
            {
                if (((MilitaryPlane)plane).getCurrentAmmo() == 0)
                {
                    NotificationManager.getInstance().addNotification("Samolot bojowy " + plane.getModelID() + " został rozbrojony", NotificationType.Positive);
                    plane.setCurrentState(previousState);
                    return false;
                }
                
                ((MilitaryPlane)plane).setCurrentAmmo(((MilitaryPlane)plane).getCurrentAmmo() - 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) + 1).ToString();
            }

            return true;
        }

        public override Plane getPlane()
        {
            return plane;
        }

        public override void stop()
        {
            plane.setCurrentState(previousState);
        }
    }
}
