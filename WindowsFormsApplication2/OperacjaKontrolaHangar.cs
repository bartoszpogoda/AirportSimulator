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
        ProgressBar uchwytPasekPostepu;
        Samolot samolot;
        int pamiec;
        public OperacjaKontrolaHangar(Samolot samolot, ProgressBar uchwytPasekPostepu) // -1 - pierwsze wykonanie
        {
            this.uchwytPasekPostepu = uchwytPasekPostepu;
            this.samolot = samolot;
            pamiec = -1;
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

                uchwytPasekPostepu.Value = progress;

                if(pamiec < 1)
                {
                    uchwytPasekPostepu.Value = 0;

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
            uchwytPasekPostepu.Value = 0;
            samolot.AktualnyStan = Stan.Hangar;
        }

        public override Samolot getSamolot()
        {
            return samolot;
        }
    }
}
