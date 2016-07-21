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
    class OperationLoading : IOperation
    {
        private Plane plane;
        private TextBox containerCount;
        private State previousState;
        private int intervalTimer;

        public OperationLoading(Plane plane, TextBox containerCount)
        {
            this.plane = plane;
            this.containerCount = containerCount;
            previousState = plane.getCurrentState();
            intervalTimer = 0;
            

            if(plane is PassengerPlane)
            {
                if(plane.getCurrentState() != State.OnRunwayBefTakeoff)
                {
                    NotificationManager.getInstance().addNotification("Pasażerowie do samolotu mogą wchodzić tylko na pasie startowym przed startem", NotificationType.Negative);
                    return;
                }

                if(((PassengerPlane)plane).getCurrentNumberOfPassengers() == ((PassengerPlane)plane).getMaxNumberOfPassengers())
                {
                    NotificationManager.getInstance().addNotification("Samolot jest już pełny", NotificationType.Negative);
                    return;
                }

                plane.setCurrentState(State.Loading);
                NotificationManager.getInstance().addNotification("Pasażerowie wchodzą na pokład samolotu " + plane.getModelID(), NotificationType.Neutral);
            }
            else if(plane is TransportPlane)
            {
                if(!(plane.getCurrentState() == State.Hangar || plane.getCurrentState() == State.OnRunwayBefTakeoff))
                {
                    NotificationManager.getInstance().addNotification("Teraz nie można załadować towaru", NotificationType.Negative);
                    return;
                }

                if (((TransportPlane)plane).getCurrentStorageContent() == ((TransportPlane)plane).getMaxStorageCapacity())
                {
                    NotificationManager.getInstance().addNotification("Samolot jest już załadowany do granic możliwości", NotificationType.Negative);
                    return;
                }

                plane.setCurrentState(State.Loading);
                NotificationManager.getInstance().addNotification("Rozpoczęto załadunek samolotu " + plane.getModelID(), NotificationType.Neutral);
            }
            else
            {
                if (!(plane.getCurrentState() == State.Hangar || plane.getCurrentState() == State.OnRunwayBefTakeoff))
                {
                    NotificationManager.getInstance().addNotification("Teraz nie można uzbroić samolotu " + plane.getModelID(), NotificationType.Negative);
                    return;
                }

                if (((MilitaryPlane)plane).getCurrentAmmo() == ((MilitaryPlane)plane).getMaxAmmo())
                {
                    NotificationManager.getInstance().addNotification("Samolot " + plane.getModel() + " jest już uzbrojony", NotificationType.Negative);
                    return;
                }

                plane.setCurrentState(State.Loading);
                NotificationManager.getInstance().addNotification("Rozpoczęto uzupełnianie amunicji samolotu " + plane.getModelID(), NotificationType.Neutral);
            }
        }


        public override bool execute()
        {
            if (plane.getCurrentState() != State.Loading) return false;

            if (++intervalTimer < Constants.intervalLoading) return true;

            intervalTimer = 0;

            if(plane is PassengerPlane)
            {
                if(((PassengerPlane)plane).getCurrentNumberOfPassengers() == ((PassengerPlane)plane).getMaxNumberOfPassengers())
                {
                    NotificationManager.getInstance().addNotification("Samolot osobowy " + plane.getModelID() + " nie ma już miejsc pasażerskich", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                if(Int32.Parse(containerCount.Text) < 1)
                {
                    NotificationManager.getInstance().addNotification("Nie ma już pasażerów na lotnisku", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                ((PassengerPlane)plane).setCurrentNumberOfPassengers(((PassengerPlane)plane).getCurrentNumberOfPassengers() + 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) - 1).ToString();
            }
            else if(plane is TransportPlane)
            {
                if (((TransportPlane)plane).getCurrentStorageContent() == ((TransportPlane)plane).getMaxStorageCapacity())
                {
                    NotificationManager.getInstance().addNotification("Samolot transportowy " + plane.getModelID() + "został zapełniony towarami", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                if (Int32.Parse(containerCount.Text) < 1)
                {
                    NotificationManager.getInstance().addNotification("Nie ma już towarów do załadunku", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                ((TransportPlane)plane).setCurrentStorageContent(((TransportPlane)plane).getCurrentStorageContent() + 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) - 1).ToString();
            }
            else if(plane is MilitaryPlane)
            {
                if (((MilitaryPlane)plane).getCurrentAmmo() == ((MilitaryPlane)plane).getMaxAmmo())
                {
                    NotificationManager.getInstance().addNotification("Samolot bojowy " + plane.getModelID() + " został uzbrojony", NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                if (Int32.Parse(containerCount.Text) < 1)
                {
                    NotificationManager.getInstance().addNotification("Nie ma już amunicji do uzbrojenia samolotu " + plane.getModelID(), NotificationType.Neutral);
                    plane.setCurrentState(previousState);
                    return false;
                }

                ((MilitaryPlane)plane).setCurrentAmmo(((MilitaryPlane)plane).getCurrentAmmo() + 1);
                containerCount.Text = (Int32.Parse(containerCount.Text) - 1).ToString();
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
