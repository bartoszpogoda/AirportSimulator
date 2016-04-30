using SymulatorLotniska.ZarzadzanieSamolotami;
using System.Windows.Forms;

namespace SymulatorLotniska.Samoloty
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

        public SamolotOsobowy(MenedzerSamolotow uchwytMenedzerSamolotow, Control parent, string adresMiniaturki)
        : base(adresMiniaturki, uchwytMenedzerSamolotow, parent) { }


        public SamolotOsobowy(string adresBazowy, MenedzerSamolotow uchwytMenedzerSamolotow, Control parent, int maxPaliwo, int maksIloscPasazerow, int czasStartu, int czasKontroli, string model)
        : base(adresBazowy, uchwytMenedzerSamolotow, parent, maxPaliwo, czasStartu, czasKontroli, model)
        {
            this.maksIloscPasazerow = maksIloscPasazerow;


            aktualnaIloscPasazerow = 0;
        }


        public override string wypiszInformacje()
        {
            string budowanyString = "";         // timer.Interval = 100;

            budowanyString += "Typ: Samolot osobowy \n";
            budowanyString += "Model: " + getModel() + "\n";
            budowanyString += "Czas startu: " + getCzasStartu() * 0.1 + "s\n";
            budowanyString += "Stan: " + getAktualnyStan() + "\n";
            budowanyString += "Kontrola techniczna: " + (czyPoKontroli() ? "Tak" : "Nie") + "\n";
            budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "/" + getMaksIloscPaliwa() + "\n";
            budowanyString += "Pasazerow: " + AktualnaIloscPasazerow + "/" + MaksIloscPasazerow + "\n";

            return budowanyString;
        }
    }
}
