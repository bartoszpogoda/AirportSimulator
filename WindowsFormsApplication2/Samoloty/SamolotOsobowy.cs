using SymulatorLotniska.ZarzadzanieSamolotami;
using System.Windows.Forms;

namespace SymulatorLotniska.Samoloty
{
    class SamolotOsobowy : Samolot
    {
        private int maksIloscPasazerow;
        private int aktualnaIloscPasazerow;

       public int getAktualnaIloscPasazerow() { return aktualnaIloscPasazerow; }
        public int getMaksIloscPasazerow() { return maksIloscPasazerow; }
        
        public void setAktualnaIloscPasazerow(int aktualnaIloscPasazerow) {
            this.aktualnaIloscPasazerow = aktualnaIloscPasazerow;
            uchwytMenedzerSamolotow.oswiezInformacjeJezeliZaznaczony(this);
        }
        
        public SamolotOsobowy(MenedzerSamolotow uchwytMenedzerSamolotow, Control parent)
        : base(uchwytMenedzerSamolotow, parent) { }


        public SamolotOsobowy(MenedzerSamolotow uchwytMenedzerSamolotow, Control parent, int maxPaliwo, int maksIloscPasazerow, int czasStartu, int czasKontroli, int spalanie, string model)
        : base(uchwytMenedzerSamolotow, parent, maxPaliwo, czasStartu, czasKontroli, spalanie, model)
        {
            this.maksIloscPasazerow = maksIloscPasazerow;


            aktualnaIloscPasazerow = 0;
        }


        public override string wypiszInformacje()
        {
            string budowanyString = "";         // timer.Interval = 100;
/*
            
            budowanyString += "Czas startu: " + getCzasStartu() * 0.1 + "s\n";
            budowanyString += "Stan: " + getAktualnyStan() + "\n";
            budowanyString += "Kontrola techniczna: " + (czyPoKontroli() ? "Tak" : "Nie") + "\n";
            budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "/" + getMaksIloscPaliwa() + "\n";
            budowanyString += "Pasazerow: " + AktualnaIloscPasazerow + "/" + MaksIloscPasazerow + "\n";
*/
            budowanyString += "Model: " + getModel() + " (ID: " + getID() + ")\n";
            budowanyString += "Typ: Samolot osobowy \n";

            switch (getAktualnyStan())
            {
                case Stan.Hangar:
                    budowanyString += "Stan: " + "W hangarze\n";
                    budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "l/" + getMaksIloscPaliwa() + "l\n";
                    budowanyString += "Po kontroli technicznej: " + (czyPoKontroli() ? "Tak" : "Nie") + "\n";
                    break;
                case Stan.Tankowanie:
                    budowanyString += "Stan: " + "Tankowanie\n";
                    budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "l/" + getMaksIloscPaliwa() + "l\n";
                    break;
                case Stan.KontrolaTechniczna:
                    budowanyString += "Stan: " + "Podczas kontroli technicznej\n";
                    budowanyString += "Postep: " + (int)(100*(double)getAktualnyPostepKontroliTechnicznej() / getCzasKontroliTechnicznej()) + "%\n";
                    break;
                case Stan.WPowietrzu:
                    budowanyString += "Stan: " + "W locie nad lotniskiem\n";
                    budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "l/" + getMaksIloscPaliwa() + "l\n";
                    break;
                case Stan.Ladowanie:
                    budowanyString += "Stan: " + "Lądowanie\n";
                    budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "l/" + getMaksIloscPaliwa() + "l\n";
                    break;
                case Stan.PoLadowaniu:
                    budowanyString += "Stan: " + "Na pasie startowym\n";
                    budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "l/" + getMaksIloscPaliwa() + "l\n";
                    break;
                case Stan.PrzedStartem:
                    budowanyString += "Stan: " + "Na pasie startowym\n";
                    budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "l/" + getMaksIloscPaliwa() + "l\n";
                    budowanyString += "Pasazerow: " + aktualnaIloscPasazerow + "/" + maksIloscPasazerow + "\n";
                    break;
                case Stan.Startowanie:
                    budowanyString += "Stan: " + "Startowanie\n";
                    budowanyString += "Paliwo: " + AktualnaIloscPaliwa + "l/" + getMaksIloscPaliwa() + "l\n";
                    budowanyString += "Pasazerow: " + aktualnaIloscPasazerow + "/" + maksIloscPasazerow + "\n";
                    break;

            }

            return budowanyString;
        }
    }
}
