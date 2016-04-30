using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class OperacjaKontrolaTechniczna : IOperacja
    {
        ProgressBar uchwytPasekPostepu;
        Samolot samolot;
        int statusKontroli; // -1 oznacza pierwsze wykonanie, nastepnie przypisany jest czas kontroli samolotu, ktory zmniejsza sie do zera co tick

        public OperacjaKontrolaTechniczna(Samolot samolot, ProgressBar uchwytPasekPostepu) // -1 - pierwsze wykonanie
        {
            this.uchwytPasekPostepu = uchwytPasekPostepu;
            this.samolot = samolot;
            statusKontroli = -1;
        }

        public override bool wykonajTick()
        {
            if (statusKontroli == -1) // pierwsze wykonanie
            {
                if (samolot.PoKontroli)
                    return false;
                if (samolot.AktualnyStan == Stan.Hangar) // operacja rozpocznie sie dopiero, gdy samolot bedzie w Hangarze.
                {
                    samolot.AktualnyStan = Stan.KontrolaTechniczna;
                    statusKontroli = samolot.CzasKontroliTechnicznej;
                }
                return true;
            }

            if (samolot.AktualnyStan == Stan.KontrolaTechniczna)
            {
                statusKontroli--;

                int progress = (int)(100 - ((double)statusKontroli / samolot.CzasKontroliTechnicznej)*100);

                uchwytPasekPostepu.Value = progress;

                if(statusKontroli < 1)
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
