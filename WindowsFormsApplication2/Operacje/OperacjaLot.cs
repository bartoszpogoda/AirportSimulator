using SymulatorLotniska.Samoloty;
using System;

namespace SymulatorLotniska.Operacje
{
    class OperacjaLot : IOperacja
    {
        private Samolot samolot;
        private int pamiec;  // 0 - pierwsze wykonanie
        public OperacjaLot(Samolot samolot) 
        {
            pamiec = 0;
            this.samolot = samolot;
        }
        public override bool wykonajTick()
        {
            if (pamiec == 0)
            {
                if (samolot.getAktualnyStan() == Stan.WPowietrzu) {
                    pamiec = 1;
                }
                //if (samolot.getAktualnePaliwo() == 0) return false;
                if (samolot.getAktualnyStan() == Stan.Hangar) // to jest ogolnie do zmiany bo z hangaru nie moze od rauz leciec
                {
                    samolot.setAktualnyStan(Stan.WPowietrzu);
                    pamiec = 1;
                }
                return true;

            }

            if (pamiec % 10 == 0)
            {
                samolot.AktualnaIloscPaliwa = samolot.AktualnaIloscPaliwa - 1;
            }

            pamiec++;

            if (pamiec > 10) pamiec = 1;

            if (samolot.getAktualnyStan() == Stan.WPowietrzu)
            {
                if (samolot.AktualnaIloscPaliwa <= 0) // było == sprobuje >
                {
                    samolot.setAktualnyStan(Stan.Zniszczony);
                    return false;
                }

                return true;
            }
            return false;

        }

        public override void zatrzymaj()
        {
            throw new NotImplementedException();
        }

        public override Samolot getSamolot()
        {
            return samolot;
        }
    }
}
