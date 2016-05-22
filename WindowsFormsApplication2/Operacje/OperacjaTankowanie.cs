using SymulatorLotniska.Samoloty;
using SymulatorLotniska.ZarzadzaniePowiadomieniami;

namespace SymulatorLotniska.Operacje
{
    class OperacjaTankowanie : IOperacja
    {
        private Samolot samolot;
        private int pamiec;
        public OperacjaTankowanie(Samolot samolot) // -1 - pierwsze wykonanie
        {
            this.samolot = samolot;
            this.pamiec = -1;
        }
        public override bool wykonajTick()
        {
            if (pamiec == -1 )
            {
                if (samolot.AktualnaIloscPaliwa == samolot.getMaksIloscPaliwa()) return false;
                if(samolot.getAktualnyStan() == Stan.Hangar)  // operacje prawdopodobnie beda sie zbierac i wykonywac dopiero jak bedzie stan spoczynku
                {
                    samolot.setAktualnyStan(Stan.Tankowanie);
                    pamiec = 0;
                }
                return true;
                
            }
            
            if (samolot.getAktualnyStan() == Stan.Tankowanie)
            {
                pamiec++;
                if (pamiec >= StaleKonfiguracyjne.interwalTankowanie) {
                    pamiec = 0;
                    
                     samolot.AktualnaIloscPaliwa = samolot.AktualnaIloscPaliwa + 1;

                if (samolot.AktualnaIloscPaliwa >= samolot.getMaksIloscPaliwa()) // było == sprobuje >
                {
                    samolot.AktualnaIloscPaliwa = samolot.getMaksIloscPaliwa();
                    samolot.setAktualnyStan(Stan.Hangar);
                    return false;
                }

                return true;
                }

                return true;
                
            }
            return false;
        
        }

        public override void zatrzymaj()
        {
            MenedzerPowiadomien.getInstance().dodajPowiadomienie("Samolot " + samolot.getModelID() + " zostal zatankowany.", CharakterPowiadomienia.Pozytywne);
            samolot.setAktualnyStan(Stan.Hangar);
        }

        public override Samolot getSamolot()
        {
            return samolot;
        }
    }
}
