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

        public SamolotOsobowy(string adresBazowy, Form uchwytFormy, MenedzerSamolotow uchwytMenedzerSamolotow, Control parent, int maxPaliwo, int maxOsob, int czasStartu, string model)
        : base(adresBazowy,uchwytFormy,uchwytMenedzerSamolotow,parent, maxPaliwo,czasStartu, model)
        {
            this.maxOsob = maxOsob;
        }
        

        public override string wypiszInformacje()
        {
            string budowanyString = "";         // timer.Interval = 100;

            budowanyString += "Typ: Samolot osobowy \n";
            budowanyString += "Model: " + getModel() + "\n";
            budowanyString += "Czas startu: " + getCzasStartu()*0.1 + "s\n";
            budowanyString += "Stan: " + getStan() + "\n";
            budowanyString += "Paliwo: " + getAktualnePaliwo() + "/" + getMaxPaliwo() + "\n";
            budowanyString += "Pasazerow: " + aktualnieOsob + "/" + maxOsob + "\n";

            return budowanyString;
        }
    }
}
