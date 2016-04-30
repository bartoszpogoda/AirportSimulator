using SymulatorLotniska.Samoloty;
using System;
using System.Windows.Forms;

namespace SymulatorLotniska.Operacje
{
    class OperacjaKontrolaTechniczna : IOperacja
    {
        Samolot samolot;
        int statusKontroli; // -1 oznacza pierwsze wykonanie, nastepnie przypisany jest czas kontroli samolotu, ktory zmniejsza sie do zera co tick

        public OperacjaKontrolaTechniczna(Samolot samolot) // -1 - pierwsze wykonanie
        {
            this.samolot = samolot;
            statusKontroli = -1;
        }

        public override bool wykonajTick()
        {
            if (statusKontroli == -1) // pierwsze wykonanie
            {
                if (samolot.PoKontroli)
                    return false;
                if (samolot.getAktualnyStan() == Stan.Hangar) // operacja rozpocznie sie dopiero, gdy samolot bedzie w Hangarze.
                {
                    samolot.setAktualnyStan(Stan.KontrolaTechniczna);
                    statusKontroli = 1;
                }
                return true;
            }

            if (samolot.getAktualnyStan() == Stan.KontrolaTechniczna)
            {
                samolot.setAktualnyPostepKontroliTechnicznej(samolot.getAktualnyPostepKontroliTechnicznej() + 1);
              
                 
                
                if(samolot.getAktualnyPostepKontroliTechnicznej() >= samolot.getCzasKontroliTechnicznej())
                {
                    samolot.setAktualnyPostepKontroliTechnicznej(0);
                    if (samolot.czyZatankowany()) samolot.PoKontroli = true;

                    samolot.setAktualnyStan(Stan.Hangar);
                    return false;
                }

                return true;
            }

            return false;
        }

        public override void zatrzymaj()
        {
            samolot.setAktualnyPostepKontroliTechnicznej(0);
            samolot.setAktualnyStan(Stan.Hangar);
        }

        public override Samolot getSamolot()
        {
            return samolot;
        }
    }
}
