using SymulatorLotniska.Operacje;
using SymulatorLotniska.Samoloty;
using SymulatorLotniska.ZarzadzanieOperacjami;
using System.Drawing;
using System.Windows.Forms;

namespace SymulatorLotniska.ZarzadzanieSamolotami
{
    public class MenedzerSamolotow
    {
       
        private int aktualnyRzadStartowy = 0; // na potrzeby scrollowania
        private int aktualnyRzadStartowyPowietrze = 0; 

        private Miniatura zaznaczony;
        private ListaSamolotow listaSamolotow; // w hangarze
        private ListaSamolotow listaSamolotowPowietrze; // w powietrzu

        private OknoAplikacji uchwytOknoAplikacji;
        private MenedzerOperacji uchwytMenedzerOperacji;
        
        private PictureBox pbZaznaczony;
        
       

        public MenedzerSamolotow(OknoAplikacji uchwytOknoAplikacji, MenedzerOperacji uchwytMenedzerOperacji) {
            this.uchwytOknoAplikacji = uchwytOknoAplikacji;
            this.uchwytMenedzerOperacji = uchwytMenedzerOperacji;

            listaSamolotow = new ListaSamolotow();
            listaSamolotowPowietrze = new ListaSamolotow();

            
            pbZaznaczony = new PictureBox();

            zainicjujZnacznikZaznaczonego();
        }

        public void dbgDodajSamolot(int i) { // debugFunkcja do usuniecia jak bedzie kreator
            if (i == 1) wygenerujLosowySamolotWPowietrzu();
            else
            {
                listaSamolotow.dodajSamolot(new SamolotOsobowy("samolot1", this, uchwytOknoAplikacji.getPanelSamolotow(), 30, 20, 500, 30, "Boening707"));
                narysujSamolotyZListy();
                narysujSamolotyZListyPowietrze();
            }
        }

        public void wygenerujLosowySamolotWPowietrzu() { // prototyp
            Samolot samolot = new SamolotOsobowy("samolot1", this, uchwytOknoAplikacji.getPanelSamolotowPowietrze(), 20, 20, 500, 30, "Tupolew");
            samolot.setAktualnyStan(Stan.WPowietrzu);
            samolot.AktualnaIloscPaliwa = samolot.getMaksIloscPaliwa(); // to pozniej bedzie losowe
            listaSamolotowPowietrze.dodajSamolot(samolot);
            uchwytMenedzerOperacji.dodajOperacje(new OperacjaLot(samolot));
            narysujSamolotyZListyPowietrze();
        }


        public MenedzerOperacji getMenedzerOperacji() { return uchwytMenedzerOperacji; }

        private void zainicjujZnacznikZaznaczonego()
        {
            if (pbZaznaczony == null || uchwytOknoAplikacji == null) return;

            pbZaznaczony.Image = (Image)Properties.Resources.ResourceManager.GetObject(StaleKonfiguracyjne.adresZnacznik);
            pbZaznaczony.BackColor = Color.Transparent;
            pbZaznaczony.Location = new Point(0, 0);
            pbZaznaczony.Enabled = false;
            pbZaznaczony.Visible = false;
            pbZaznaczony.Size = new Size(StaleKonfiguracyjne.rozmiarObrazka, StaleKonfiguracyjne.rozmiarObrazka);
            uchwytOknoAplikacji.Controls.Add(pbZaznaczony);
        }


        public void mouseWheelEventHangar(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) // scrollowanie w dół
            {
                if (listaSamolotow.getLength() / 4 - 2 > aktualnyRzadStartowy) aktualnyRzadStartowy++;
            }
            else // scrollowanie w górę
            {
                if (aktualnyRzadStartowy > 0) aktualnyRzadStartowy--;
            }
            narysujSamolotyZListy();
        }

        public void mouseWheelEventPowietrze(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) // scrollowanie w dół
            {
                if (listaSamolotowPowietrze.getLength()  - 5 > aktualnyRzadStartowyPowietrze) aktualnyRzadStartowyPowietrze++;
            }
            else // scrollowanie w górę
            {
                if (aktualnyRzadStartowyPowietrze > 0) aktualnyRzadStartowyPowietrze--;
            }
            narysujSamolotyZListyPowietrze();
        }


        public void narysujSamolotyZListy()
        {
            int i = aktualnyRzadStartowy;
            listaSamolotow.iteratorNaStart();
            if (listaSamolotow.aktualnyPodIteratorem() == null) return; // wychwytuje pusta listaSamolotow

            while (--i >= 0) // pomija elementy ktore zostaly przescrollowane
            {
                for (int k = 0; k < StaleKonfiguracyjne.iloscKolumn; k++)
                {
                    listaSamolotow.aktualnyPodIteratorem().schowaj();
                    listaSamolotow.iteratorNastepny();
                }
            }

            for (i = 0; i < StaleKonfiguracyjne.iloscRzedow; i++) 
            {
                for(int j=0; j < StaleKonfiguracyjne.iloscKolumn; j++)
                {
                    listaSamolotow.aktualnyPodIteratorem().getObrazekSamolotu().Location = new Point(
                        StaleKonfiguracyjne.rozmiarOdstepu * (j + 1) + j * StaleKonfiguracyjne.rozmiarObrazka,
                           10 + StaleKonfiguracyjne.rozmiarOdstepu * (i + 1) + i * StaleKonfiguracyjne.rozmiarObrazka
                           );
                    listaSamolotow.aktualnyPodIteratorem().pokaz();

                    if (listaSamolotow.aktualnyPodIteratorem().Equals(zaznaczony)){
                        pbZaznaczony.Parent = zaznaczony.getAktualnyNaGorze();
                        pbZaznaczony.Location = new System.Drawing.Point(0, 0);
                        pbZaznaczony.Visible = true;
                    }

                    if (listaSamolotow.iteratorMaNastepny()) listaSamolotow.iteratorNastepny();
                    else
                    {
                        return;
                    }
                }

            }
        }  // hangar

        public void narysujSamolotyZListyPowietrze() // powietrze
        {
            int i = aktualnyRzadStartowyPowietrze;
            listaSamolotowPowietrze.iteratorNaStart();
            if (listaSamolotowPowietrze.aktualnyPodIteratorem() == null) return; // wychwytuje pusta listaSamolotow

            while (--i >= 0) // pomija elementy ktore zostaly przescrollowane
            {
                
                    listaSamolotowPowietrze.aktualnyPodIteratorem().schowaj();
                    listaSamolotowPowietrze.iteratorNastepny();
                
            }

            for (i = 0; i < 5; i++)
            {

                listaSamolotowPowietrze.aktualnyPodIteratorem().getObrazekSamolotu().Location = new Point(25,
                           10 + StaleKonfiguracyjne.rozmiarOdstepu + i * StaleKonfiguracyjne.rozmiarObrazka);
                listaSamolotowPowietrze.aktualnyPodIteratorem().pokaz();

                    if (listaSamolotowPowietrze.aktualnyPodIteratorem().Equals(zaznaczony))
                    {
                        pbZaznaczony.Parent = zaznaczony.getObrazekSamolotu();
                        pbZaznaczony.Location = new System.Drawing.Point(0, 0);
                        pbZaznaczony.Visible = true;
                    }

                    if (listaSamolotowPowietrze.iteratorMaNastepny()) listaSamolotowPowietrze.iteratorNastepny();
                    else
                    {
                        return;
                    }
                

            }
        }

        public void zaznaczSamolot(Miniatura samolot) {
            if (zaznaczony == null)
                zaznaczony = samolot;
            else if (zaznaczony == samolot) ;
            else
            {
                zaznaczony = samolot;
            }
            
            pbZaznaczony.Parent = samolot.getAktualnyNaGorze();
            pbZaznaczony.Location = new Point(0, 0);
            if (samolot.czyJestPokazany()) pbZaznaczony.Visible = true;

            // zmiana informacji
            //if (samolot is Samolot) uchwytForma.getLabelInformacje().Text = ((Samolot)samolot).wypiszInformacje();
            odswiezInformacje();
            uaktualnijPrzyciski();
        }

        public void uaktualnijPrzyciski()
        {
            
                uchwytOknoAplikacji.uaktualnijPrzyciskiPanelu(zaznaczony);
        }
        public void uaktualnijPrzyciskiJezeliZaznaczony(Samolot samolot)
        {
            if (zaznaczony is Samolot && ((Samolot)zaznaczony) == samolot)
            {
                uchwytOknoAplikacji.uaktualnijPrzyciskiPanelu(zaznaczony);
            }
        }

        public void tankujZaznaczonySamolot()
        {
            if(zaznaczony is Samolot) getMenedzerOperacji().dodajOperacje(new OperacjaTankowanie((Samolot)zaznaczony));
        }
        public void kontrolujZaznaczonySamolot(ProgressBar pasekPostepu)
        {
            if (zaznaczony is Samolot) getMenedzerOperacji().dodajOperacje(new OperacjaKontrolaTechniczna((Samolot)zaznaczony, pasekPostepu));
        }
        public Miniatura getZaznaczony()
        {
            return zaznaczony;
        }

        public void odswiezInformacje()
        {
            if (zaznaczony is Samolot)
            {
                uchwytOknoAplikacji.getLabelInformacje().Text = ((Samolot)zaznaczony).wypiszInformacje();
            }// rysowanie nowe?
        }

        public void oswiezInformacjeJezeliZaznaczony(Samolot samolot)
        {
            if (zaznaczony is Samolot && zaznaczony == samolot)
            {
                uchwytOknoAplikacji.getLabelInformacje().Text = ((Samolot)zaznaczony).wypiszInformacje();
            }
        }

    }
}
