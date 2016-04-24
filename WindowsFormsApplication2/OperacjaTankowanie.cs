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
                if (samolot.AktualnaIloscPaliwa == samolot.MaksIloscPaliwa) return false;
                if(samolot.AktualnyStan == Stan.Hangar)  // operacje prawdopodobnie beda sie zbierac i wykonywac dopiero jak bedzie stan spoczynku
                {
                    samolot.AktualnyStan = Stan.Tankowanie;
                    pamiec = 0;
                }
                return true;
                
            }

            samolot.AktualnaIloscPaliwa = samolot.AktualnaIloscPaliwa + 1;
            if (samolot.AktualnyStan == Stan.Tankowanie)
            {
                if (samolot.AktualnaIloscPaliwa >= samolot.MaksIloscPaliwa) // było == sprobuje >
                {
                    samolot.AktualnaIloscPaliwa = samolot.MaksIloscPaliwa;
                    samolot.AktualnyStan = Stan.Hangar;
                    return false;
                }

                return true;
            }
            return false;
        
        }

        public override void zatrzymaj()
        {
            samolot.AktualnyStan = Stan.Hangar;
        }
    }
}
