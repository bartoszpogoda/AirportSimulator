using SymulatorLotniska.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymulatorLotniska.ZarzadzanieSamolotami
{
    public class PasStartowy
    {
        private Plane aktualnySamolot;
        private int polozenieSamolotuX;
        private int polozenieSamolotuY;
        private double dx;
        private double dy;
        private int maxX;
        private int maxY;
        private Control uchwytPanel;
        private int ID;

        public PasStartowy(Control panel, int ID)
        {
            uchwytPanel = panel;
            maxX = uchwytPanel.Size.Width - StaleKonfiguracyjne.rozmiarObrazka;
            maxY = 40;
            this.ID = ID;
        }

        public int getID() { return ID; }
        public void ustawSamolot(Plane samolot)
        {
            if (samolot.getCurrentState() == State.OnRunwayBefTakeoff)
            {
                polozenieSamolotuX = 0;
                polozenieSamolotuY = 0;
            }
            else if(samolot.getCurrentState() == State.Landing)
            {

                polozenieSamolotuX = 0;
                polozenieSamolotuY = 40;
            }

            dx = 0;
            dy = 0;

            this.aktualnySamolot = samolot;

            aktualnySamolot.setParent(uchwytPanel);
            aktualnySamolot.getPlaneImage().Location = new System.Drawing.Point(polozenieSamolotuX, 40 - polozenieSamolotuY);
            aktualnySamolot.show();
        }

        public void zdejmijAktualnySamolot()
        {
            aktualnySamolot = null;
        }
        
        public bool tick()
        {
            // taki sposob narzuca tez ograniczenie na max speed
            // chyba jest zle wyskalowane
            dx += (double)maxX / (double)aktualnySamolot.getTakeoffTime();
            dy += 1 * (double)maxY / (double)aktualnySamolot.getTakeoffTime(); // albo 2*

            if(dx > 1)
            {
                dx = 0;
                if (polozenieSamolotuX + 1 <= maxX)
                {
                    polozenieSamolotuX += 1;
                }
                else
                {
                    if(aktualnySamolot.getCurrentState() == State.Takeoff)  zdejmijAktualnySamolot();
                    return false;
                }
            }

            if(dy > 1)
            {
                if(aktualnySamolot.getCurrentState() == State.Takeoff)
                    if (polozenieSamolotuX >= maxX / 2 && polozenieSamolotuY + 1 <= maxY)
                        polozenieSamolotuY += 1; 

                if(aktualnySamolot.getCurrentState() == State.Landing)
                    if (polozenieSamolotuX >= maxX / 2 && polozenieSamolotuY - 1 >= 0)
                        polozenieSamolotuY -= 1;
               

                dy = 0; 
            }

            //if(dx == 0 && dy==0)
             odswiezPolozenieSamolotu();

            return true;
        }

        public Plane getAktualnySamolot() { return aktualnySamolot; }

        private void odswiezPolozenieSamolotu()
        {
            aktualnySamolot.getPlaneImage().Location = new System.Drawing.Point(polozenieSamolotuX, 40 - polozenieSamolotuY);
        }

        public bool czyWolny()
        {
            if (aktualnySamolot == null) return true;
            else return false;
        }


    }
}
