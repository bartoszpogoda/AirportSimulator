using SymulatorLotniska.Samoloty;
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
        private Samolot aktualnySamolot;
        private int polozenieSamolotuX;
        private int polozenieSamolotuY;
        private double dx;
        private double dy;
        private int maxX;
        private int maxY;
        private Control uchwytPanel;

        public PasStartowy(Control panel)
        {
            uchwytPanel = panel;
            maxX = uchwytPanel.Size.Width - StaleKonfiguracyjne.rozmiarObrazka;
            maxY = 40;
        }

        public void ustawSamolot(Samolot samolot)
        {
            if (samolot.getAktualnyStan() == Stan.PrzedStartem)
            {
                polozenieSamolotuX = 0;
                polozenieSamolotuY = 0;
            }
            else if(samolot.getAktualnyStan() == Stan.Ladowanie)
            {

                polozenieSamolotuX = 0;
                polozenieSamolotuY = 40;
            }

            dx = 0;
            dy = 0;

            this.aktualnySamolot = samolot;

            aktualnySamolot.setParent(uchwytPanel);
            aktualnySamolot.getObrazekSamolotu().Location = new System.Drawing.Point(polozenieSamolotuX, 40 - polozenieSamolotuY);
            aktualnySamolot.pokaz();
        }

        public void zdejmijAktualnySamolot()
        {
            aktualnySamolot = null;
        }
        
        public bool tick()
        {
            // taki sposob narzuca tez ograniczenie na max speed
            // chyba jest zle wyskalowane
            dx += (double)maxX / (double)aktualnySamolot.getCzasStartu();
            dy += 1 * (double)maxY / (double)aktualnySamolot.getCzasStartu(); // albo 2*

            if(dx > 1)
            {
                dx = 0;
                if (polozenieSamolotuX + 1 <= maxX)
                {
                    polozenieSamolotuX += 1;
                }
                else
                {
                    if(aktualnySamolot.getAktualnyStan() == Stan.Startowanie)  zdejmijAktualnySamolot();
                    return false;
                }
            }

            if(dy > 1)
            {
                if(aktualnySamolot.getAktualnyStan() == Stan.Startowanie)
                    if (polozenieSamolotuX >= maxX / 2 && polozenieSamolotuY + 1 <= maxY)
                        polozenieSamolotuY += 1; 

                if(aktualnySamolot.getAktualnyStan() == Stan.Ladowanie)
                    if (polozenieSamolotuX >= maxX / 2 && polozenieSamolotuY - 1 >= 0)
                        polozenieSamolotuY -= 1;
               

                dy = 0; 
            }

            //if(dx == 0 && dy==0)
             odswiezPolozenieSamolotu();

            return true;
        }

        public Samolot getAktualnySamolot() { return aktualnySamolot; }

        private void odswiezPolozenieSamolotu()
        {
            aktualnySamolot.getObrazekSamolotu().Location = new System.Drawing.Point(polozenieSamolotuX, 40 - polozenieSamolotuY);
        }

        public bool czyWolny()
        {
            if (aktualnySamolot == null) return true;
            else return false;
        }


    }
}
