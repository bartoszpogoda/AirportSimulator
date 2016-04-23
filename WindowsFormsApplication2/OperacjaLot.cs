using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class OperacjaLot : IOperacja
    {
        public OperacjaLot(Samolot samolot) : base(samolot, 0) // 0 - pierwsze wykonanie
        {

        }
        public override bool wykonajTick()
        {
            if (pamiec == 0)
            {
                if (samolot.getStan() == Stan.WPowietrzu) {
                    pamiec = 1;
                }
                //if (samolot.getAktualnePaliwo() == 0) return false;
                if (samolot.getStan() == Stan.Spoczynek)  // operacje prawdopodobnie beda sie zbierac i wykonywac dopiero jak bedzie stan spoczynku
                {
                    samolot.zmienStan(Stan.WPowietrzu);
                    pamiec = 1;
                }
                return true;

            }

            if (pamiec % 10 == 0)
            {
                samolot.setAktualnePaliwo(samolot.getAktualnePaliwo() - 1);
            }

            pamiec++;
            if (pamiec > 10) pamiec = 1;

            if (samolot.getStan() == Stan.WPowietrzu)
            {
                if (samolot.getAktualnePaliwo() <= 0) // było == sprobuje >
                {
                    samolot.zmienStan(Stan.Zniszczony);
                    return false;
                }

                return true;
            }
            return false;

        }
    }
}
