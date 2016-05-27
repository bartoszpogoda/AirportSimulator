using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymulatorLotniska.Planes;
using SymulatorLotniska.AirportManagement;
using SymulatorLotniska.NotificationManagement;
using SymulatorLotniska.OperationManagement;

namespace SymulatorLotniska.Operations
{
    class OperationIncommingPlanes : IOperation
    {
        private int intervalTimer;

        public OperationIncommingPlanes()
        { }

        public override bool execute()
        {
            Console.WriteLine(intervalTimer);
            if (++intervalTimer < Constants.intervalCommingPlane) return true;
            intervalTimer = 0;

            Random random = new Random();

            Plane incommingPlane = Program.readFromFile(random.Next(Program.howManyInFile()));

            incommingPlane.setAfterTechnicalInspection(false);

            // pozostale losowe zmienne stanu
            Double d;

            while ((d = random.NextDouble()) < 0.4) ;
            incommingPlane.setCurrentFuelLevel((int)(d*incommingPlane.getMaxFuelLevel()));

            if(incommingPlane is PassengerPlane)
            {
                ((PassengerPlane)incommingPlane).setCurrentNumberOfPassengers((int)(d * ((PassengerPlane)incommingPlane).getMaxNumberOfPassengers()));
            }
            else if(incommingPlane is TransportPlane)
            {
                ((TransportPlane)incommingPlane).setCurrentStorageContent((int)(d * ((TransportPlane)incommingPlane).getMaxStorageCapacity()));
            }
            else if(incommingPlane is MilitaryPlane)
            {
                ((MilitaryPlane)incommingPlane).setCurrentAmmo((int)(d * ((MilitaryPlane)incommingPlane).getMaxAmmo()));
            }

            NotificationManager.getInstance().addNotification("Samolot " + incommingPlane.getModelID() + " zawitał w przestrzeni powietrznej nad lotniskiem", NotificationType.Positive);
           
            AirportManager.getInstance().getAirspace().addToAirspace(incommingPlane);

            return true;
        }

        public override Plane getPlane()
        {
            return null;
        }

        public override void stop()
        {

        }
    }
}
