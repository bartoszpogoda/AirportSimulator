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
        int pamiec;

        public OperacjaLot(Samolot samolot,PasStartowy pasStartowy,MenedzerSamolotow menedzerSamolotow)
        {
            this.samolot = samolot;
            this.pasStartowy = pasStartowy;
            uchwytMenedzerSamolotow = menedzerSamolotow;
            pamiec = -1;
        }

        public OperacjaLot(Samolot samolot, MenedzerSamolotow menedzerSamolotow)
        {
            this.samolot = samolot;
            uchwytMenedzerSamolotow = menedzerSamolotow;
            pamiec = -1;
        }

        public override Samolot getSamolot()
        {
            return samolot;
        }

        public override bool wykonajTick()
        {
            if (pamiec == -1)
            {
                if(samolot.getAktualnyStan() == Stan.PrzedStartem)
                {
                    samolot.setAktualnyStan(Stan.Startowanie);
                    pamiec = 1;

                    if (uchwytMenedzerSamolotow.getZaznaczony() == samolot) // bez tego znika zaznaczenie
                    {
                        uchwytMenedzerSamolotow.zaznaczSamolot(samolot);
                    }
                    return true;
                }
                if(samolot.getAktualnyStan() == Stan.WPowietrzu)
                {
                    pamiec = 1;
                    return true;
                }
                return false;
            }

            if(samolot.getAktualnyStan() == Stan.Startowanie || samolot.getAktualnyStan() == Stan.WPowietrzu)
            {

                if (pamiec % 10 == 0)
                {
                    samolot.AktualnaIloscPaliwa = samolot.AktualnaIloscPaliwa - 1;
                }

                pamiec++;

                if (pamiec > 10) pamiec = 1;

                if (samolot.AktualnaIloscPaliwa <= 0) 
                    {
                        samolot.setAktualnyStan(Stan.Zniszczony);
                        return false;
                    }
                
                if(samolot.getAktualnyStan() == Stan.Startowanie)
                {
                    if (pasStartowy.przesunSamolotWPrawo())
                    {
                        
                        // tutaj jeszcze przesuniecie w gore;
                        return true;
                    }
                    else
                    {
                        uchwytMenedzerSamolotow.umiescWPowietrzu(samolot, pasStartowy);
                        if (uchwytMenedzerSamolotow.getZaznaczony() == samolot)
                        {
                            uchwytMenedzerSamolotow.zaznaczSamolot(samolot);
                        }
                    }
                }

                return true;
                

            }
            return false;
            

        }

        public override void zatrzymaj()
        {
           
            samolot.setAktualnyStan(Stan.Zniszczony);
        }
    }
}
