using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymulatorLotniska.Samoloty;
using SymulatorLotniska.ZarzadzanieSamolotami;

namespace SymulatorLotniska.Operacje
{
    class OperacjaLot : IOperacja
    {
        private Samolot samolot;
        private MenedzerSamolotow uchwytMenedzerSamolotow;

        int spalanie;
        int timerSpalanie;

        public OperacjaLot(Samolot samolot, MenedzerSamolotow uchwytMenedzerSamolotow)
        {
            this.samolot = samolot;
            this.uchwytMenedzerSamolotow = uchwytMenedzerSamolotow;
            timerSpalanie = 1;
            spalanie = samolot.getSpalanie();
        }
        
        public override Samolot getSamolot()
        {
            return samolot;
        }

        public override bool wykonajTick()
        {
           
            if (samolot.getAktualnyStan() == Stan.WPowietrzu)
            {

                if (timerSpalanie >= spalanie)
                {
                    samolot.AktualnaIloscPaliwa = samolot.AktualnaIloscPaliwa - 1;
                    timerSpalanie = 1;
                }
                else
                    timerSpalanie++;
                

                if (samolot.AktualnaIloscPaliwa <= 0) 
                {
                    // tutaj sie zrobi cos ciekawszego ;)
                        samolot.setAktualnyStan(Stan.Zniszczony);
                        return false;
                }
                
                return true;
                

            }
            else
                return false;
            

        }

        public override void zatrzymaj()
        {
           
        }
    }
}
