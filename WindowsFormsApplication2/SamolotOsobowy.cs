using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class SamolotOsobowy : Samolot
    {
        private int maxOsob;
        private int aktualnieOsob;

        public SamolotOsobowy(string adresBazowy, Form uchwytFormy, MenedzerSamolotow uchwytMenedzerSamolotow, int maxPaliwo, int maxOsob)
        : base(adresBazowy,uchwytFormy,uchwytMenedzerSamolotow,maxPaliwo)
        {
            this.maxOsob = maxOsob;
        }


      

        public override void operacja2()
        {
            throw new NotImplementedException();
        }

        public override void operacja3()
        {
            throw new NotImplementedException();
        }

        public override string wypiszInformacje()
        {
            string budowanyString = "";

            budowanyString += "Typ: Samolot osobowy \n";
            budowanyString += "Stan: " + getStan() + "\n";
            budowanyString += "Paliwo: " + getAktualnePaliwo() + "/" + getMaxPaliwo() + "\n";
            budowanyString += "Osob: " + aktualnieOsob + "/" + maxOsob + "\n";

            return budowanyString;
        }
    }
}
