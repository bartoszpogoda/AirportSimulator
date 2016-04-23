using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class OperacjaTankowanie : IOperacja
    {
        public OperacjaTankowanie(Samolot samolot) : base(samolot,1) // 1 - pierwsze wykonanie
        {

        }
        public override bool wykonajTick()
        {
            if (pamiec == 1 )
            {
                if (samolot.getAktualnePaliwo() == samolot.getMaxPaliwo()) return false;
                if(samolot.getStan() == Stan.Spoczynek)  // operacje prawdopodobnie beda sie zbierac i wykonywac dopiero jak bedzie stan spoczynku
                {
                    samolot.zmienStan(Stan.Tankowanie);
                    pamiec = 0;
                }
                return true;
                
            }

            samolot.setAktualnePaliwo(samolot.getAktualnePaliwo() + 1);
            if (samolot.getStan() == Stan.Tankowanie)
            {
                if (samolot.getAktualnePaliwo() >= samolot.getMaxPaliwo()) // było == sprobuje >
                {
                    samolot.setAktualnePaliwo(samolot.getMaxPaliwo());
                    samolot.zmienStan(Stan.Spoczynek);
                    return false;
                }

                return true;
            }
            return false;
        
        }
    }
}
