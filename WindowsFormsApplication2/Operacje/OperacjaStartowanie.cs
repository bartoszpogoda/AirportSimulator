using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymulatorLotniska.Samoloty;
using SymulatorLotniska.ZarzadzanieSamolotami;
using SymulatorLotniska.ZarzadzaniePowiadomieniami;

namespace SymulatorLotniska.Operacje
{
    class OperacjaStartowanie : IOperacja
    {
        private Samolot startujacySamolot;
        private PasStartowy pasStartowy;
        private MenedzerSamolotow uchwytMenedzerSamolotow;

        int spalanie;
        int timerSpalanie;

        public OperacjaStartowanie(Samolot startujacySamolot, PasStartowy pasStartowy, MenedzerSamolotow uchwytMenedzerSamolotow)
        {
            this.startujacySamolot = startujacySamolot;
            this.pasStartowy = pasStartowy;
            this.uchwytMenedzerSamolotow = uchwytMenedzerSamolotow;

            timerSpalanie = 1;
            spalanie = startujacySamolot.getSpalanie();
        }

        public override Samolot getSamolot()
        {
            return startujacySamolot;
        }

        public override bool wykonajTick()
        {
            if (startujacySamolot.getAktualnyStan() == Stan.Startowanie)
            {
                if (timerSpalanie >= spalanie)
                {
                    startujacySamolot.AktualnaIloscPaliwa = startujacySamolot.AktualnaIloscPaliwa - 1;
                    timerSpalanie = 1;
                }
                else
                    timerSpalanie++;


                if (startujacySamolot.AktualnaIloscPaliwa <= 0)
                {
                    // tutaj sie zrobi cos ciekawszego ;)
                    startujacySamolot.setAktualnyStan(Stan.Zniszczony);
                    return false;
                }

                if (pasStartowy.tick())
                {
                    return true;
                }
                else
                {
                    uchwytMenedzerSamolotow.umiescWPowietrzu(startujacySamolot);
                    return false;
                }
            }
            else return false;
        }

        public override void zatrzymaj()
        {
            MenedzerPowiadomien.getInstance().dodajPowiadomienie("Samolot " + startujacySamolot.getModelID() + " wzniósł się w powietrze. Teraz znajduje się w przestrzeni powietrznej nad lotniskiem", CharakterPowiadomienia.Pozytywne);
        }
    }
}
