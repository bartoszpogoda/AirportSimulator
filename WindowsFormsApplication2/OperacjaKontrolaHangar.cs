using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class OperacjaKontrolaHangar : IOperacja
    {
        public OperacjaKontrolaHangar(Samolot samolot, Object o) : base(samolot, -1,o) // -1 - pierwsze wykonanie
        {

        }
        public override bool wykonajTick()
        {
            if (pamiec == -1)
            {
                if (samolot.PoKontroli) return false;
                if (samolot.AktualnyStan == Stan.Hangar) 
                {
                    samolot.AktualnyStan = Stan.KontrolaHangar;
                    pamiec = samolot.CzasKontroli;
                }
                return true;

            }

            if (samolot.AktualnyStan == Stan.KontrolaHangar)
            {
                pamiec--;

                int progress = (int)(100 - ((double)pamiec / samolot.CzasKontroli)*100);

                if (pamiec2 is ProgressBar) ((ProgressBar)pamiec2).Value = progress;

                if(pamiec < 1)
                {
                    if (pamiec2 is ProgressBar) ((ProgressBar)pamiec2).Value = 0;

                    if (samolot.czyZatankowany()) samolot.PoKontroli = true;

                    samolot.AktualnyStan = Stan.Hangar;
                    return false;
                }

                return true;
            }
            return false;

        }

        public override void zatrzymaj()
        {
            if (pamiec2 is ProgressBar) ((ProgressBar)pamiec2).Value = 0;
            samolot.AktualnyStan = Stan.Hangar;
        }
    }
}
