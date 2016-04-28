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
        private int maksIloscPasazerow;
        private int aktualnaIloscPasazerow;

        public int AktualnaIloscPasazerow
        {
            get
            {
                return aktualnaIloscPasazerow;
            }

            set
            {
                aktualnaIloscPasazerow = value;
            }
        }

        public int MaksIloscPasazerow
        {
            get
            {
                return maksIloscPasazerow;
            }

            set
            {
                maksIloscPasazerow = value;
            }
        }

        public SamolotOsobowy(string adresBazowy, Form uchwytFormy, MenedzerSamolotow uchwytMenedzerSamolotow, Control parent, int maxPaliwo, int maksIloscPasazerow, int czasStartu, int czasKontroli, string model)
        : base(adresBazowy, uchwytFormy, uchwytMenedzerSamolotow, parent, maxPaliwo, czasStartu, czasKontroli, model)
        {
            this.maksIloscPasazerow = maksIloscPasazerow;


            aktualnaIloscPasazerow = 0;
        }


        public override string wypiszInformacje()
        {
            string budowanyString = "";         // timer.Interval = 100;

            budowanyString += "Typ: Samolot osobowy \n";
            budowanyString += "Model: " + Model + "\n";
            budowanyString += "Czas startu: " + CzasStartu * 0.1 + "s\n";
            budowanyString += "Stan: " + AktualnyStan + "\n";
            budowanyString += "Kontrola techniczna: " + (czyPoKontroli() ? "Tak" : "Nie") + "\n";
            budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "/" + MaksIloscPaliwa + "\n";
            budowanyString += "Pasazerow: " + AktualnaIloscPasazerow + "/" + MaksIloscPasazerow + "\n";

            return budowanyString;
        }
    }
}
