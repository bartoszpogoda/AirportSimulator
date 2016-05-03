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
        private PasStartowy pasStartowy;
        private MenedzerSamolotow uchwytMenedzerSamolotow;
        bool pierwszeWykonanie;
        int spalanie;
        int timerSpalanie;

        public OperacjaLot(Samolot samolot, PasStartowy pasStartowy, MenedzerSamolotow menedzerSamolotow)
        {
            this.samolot = samolot;
            this.pasStartowy = pasStartowy;
            uchwytMenedzerSamolotow = menedzerSamolotow;
            pierwszeWykonanie = true;
            timerSpalanie = 1;
            spalanie = samolot.getSpalanie();
        }

        public OperacjaLot(Samolot samolot, MenedzerSamolotow menedzerSamolotow)
        {
            this.samolot = samolot;
            uchwytMenedzerSamolotow = menedzerSamolotow;
            pierwszeWykonanie = true;
            timerSpalanie = 1;
            spalanie = samolot.getSpalanie();
        }

        public override Samolot getSamolot()
        {
            return samolot;
        }

        public override bool wykonajTick()
        {
            if (pierwszeWykonanie)
            {
                if (samolot.getAktualnyStan() == Stan.PrzedStartem)
                {
                    samolot.setAktualnyStan(Stan.Startowanie);
                    pierwszeWykonanie = false;

                    /*  if (uchwytMenedzerSamolotow.getZaznaczony() == samolot) // bez tego znika zaznaczenie
                      {
                          uchwytMenedzerSamolotow.zaznaczSamolot(samolot);
                      }*/

                    //uchwytMenedzerSamolotow.uaktualnijPbZaznaczony();

                    return true;
                }
                if (samolot.getAktualnyStan() == Stan.WPowietrzu)
                {
                    pierwszeWykonanie = false;
                    return true;
                }
                return false;
            }

            if (samolot.getAktualnyStan() == Stan.WPowietrzu || samolot.getAktualnyStan() == Stan.Startowanie || samolot.getAktualnyStan() == Stan.Ladowanie)
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

                if (samolot.getAktualnyStan() == Stan.WPowietrzu) return true;

                if(samolot.getAktualnyStan() == Stan.Startowanie)
                {
                    if (pasStartowy.tick())
                    {
                        return true;
                    }
                    else
                    {
                        uchwytMenedzerSamolotow.umiescWPowietrzu(samolot);
                    }
                }
                else if (samolot.getAktualnyStan() == Stan.Ladowanie)
                {
                    if (pasStartowy.tick())
                    {
                        return true;
                    }
                    else
                    {
                        // tutaj do przemyslenia jeszcze 
                        samolot.setAktualnyStan(Stan.PoLadowaniu); // do zaprogramowania jeszcze
                        return false;
                    }
                }

                return true;
                

            }
            return false;
            

        }

        public override void zatrzymaj()
        {
           
        }
    }
}
