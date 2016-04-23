using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class MenedzerSamolotow
    {
        //STAŁE KONFIGURACYJNE--------------------------
        const int rozmiarObrazka = 50;
        const int rozmiarOdstepu = 10;
        const int iloscKolumn = 4;
        const int iloscRzedow = 3;
        private const string adresImgZaznaczony = "znacznik";
        //----------------------------------------------
        private int aktualnyRzadStartowy = 0; // na potrzeby scrollowania
        private int aktualnyRzadStartowyPowietrze = 0; 

        private Miniatura zaznaczony;
        private ListaSamolotow listaSamolotow; // w hangarze
        private ListaSamolotow listaSamolotowPowietrze; // w powietrzu
        private Lotnisko uchwytForma;

        private MenedzerOperacji uchwytMenedzerOperacji;
        
        private PictureBox znacznikZaznaczonego;

       

        public MenedzerSamolotow(Lotnisko uchwytForma, MenedzerOperacji uchwytMenedzerOperacji) {
            this.uchwytForma = uchwytForma;
            this.uchwytMenedzerOperacji = uchwytMenedzerOperacji;
            listaSamolotow = new ListaSamolotow();
            listaSamolotowPowietrze = new ListaSamolotow();

            
            znacznikZaznaczonego = new PictureBox();

            zainicjujZnacznikZaznaczonego();
        }

        public void dbgDodajSamolot(int i) { // debugFunkcja do usuniecia jak bedzie kreator
            if (i == 1) wygenerujLosowySamolotWPowietrzu();
            else
            {
                listaSamolotow.dodajSamolot(new SamolotOsobowy("samolot1", this.uchwytForma, this, uchwytForma.getPanelSamolotow(), 200, 20, 500, "Boening707"));
                narysujSamolotyZListy();
                narysujSamolotyZListyPowietrze();
            }
        }

        public void wygenerujLosowySamolotWPowietrzu() { // prototyp
            Samolot samolot = new SamolotOsobowy("samolot1", this.uchwytForma, this, uchwytForma.getPanelSamolotowPowietrze(), 20, 20, 500, "Tupolew");
            samolot.zmienStan(Stan.WPowietrzu);
            samolot.setAktualnePaliwo(samolot.getMaxPaliwo()); // to pozniej bedzie losowe
            listaSamolotowPowietrze.dodajSamolot(samolot);
            uchwytMenedzerOperacji.dodajOperacje(new OperacjaLot(samolot));
            narysujSamolotyZListyPowietrze();
        }


        public MenedzerOperacji getMenedzerOperacji() { return uchwytMenedzerOperacji; }

        private void zainicjujZnacznikZaznaczonego()
        {
            if (znacznikZaznaczonego == null || uchwytForma == null) return;

            znacznikZaznaczonego.Image = (Image)Properties.Resources.ResourceManager.GetObject(adresImgZaznaczony);
            znacznikZaznaczonego.BackColor = Color.Transparent;
            znacznikZaznaczonego.Location = new Point(0, 0);
            znacznikZaznaczonego.Enabled = false;
            znacznikZaznaczonego.Visible = false;
            znacznikZaznaczonego.Size = new Size(50, 50);
            uchwytForma.Controls.Add(znacznikZaznaczonego);
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
                if (listaSamolotowPowietrze.getLength()  - 2 > aktualnyRzadStartowyPowietrze) aktualnyRzadStartowyPowietrze++;
            }
            else // scrollowanie w górę
            {
                if (aktualnyRzadStartowyPowietrze > 0) aktualnyRzadStartowyPowietrze--;
            }
            narysujSamolotyZListyPowietrze();
        }


        private void narysujSamolotyZListy()
        {
            int i = aktualnyRzadStartowy;
            listaSamolotow.iteratorNaStart();
            if (listaSamolotow.aktualnyPodIteratorem() == null) return; // wychwytuje pusta listaSamolotow

            while (--i >= 0) // pomija elementy ktore zostaly przescrollowane
            {
                for (int k = 0; k < iloscKolumn; k++)
                {
                    listaSamolotow.aktualnyPodIteratorem().schowaj();
                    listaSamolotow.iteratorNastepny();
                }
            }

            for (i = 0; i < iloscRzedow; i++) 
            {
                for(int j=0; j < iloscKolumn; j++)
                {
                    listaSamolotow.aktualnyPodIteratorem().Location = new Point(
                        rozmiarOdstepu * (j + 1) + j * rozmiarObrazka,
                           10 + rozmiarOdstepu * (i + 1) + i * rozmiarObrazka
                           );
                    listaSamolotow.aktualnyPodIteratorem().pokaz();

                    if (listaSamolotow.aktualnyPodIteratorem().Equals(zaznaczony)){
                        znacznikZaznaczonego.Parent = zaznaczony;
                        znacznikZaznaczonego.Location = new System.Drawing.Point(0, 0);
                        znacznikZaznaczonego.Visible = true;
                    }

                    if (listaSamolotow.iteratorMaNastepny()) listaSamolotow.iteratorNastepny();
                    else
                    {
                        return;
                    }
                }

            }
        }  // hangar

        private void narysujSamolotyZListyPowietrze() // powietrze
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

                listaSamolotowPowietrze.aktualnyPodIteratorem().Location = new Point(25,
                           10 + rozmiarOdstepu  + i * rozmiarObrazka);
                listaSamolotowPowietrze.aktualnyPodIteratorem().pokaz();

                    if (listaSamolotowPowietrze.aktualnyPodIteratorem().Equals(zaznaczony))
                    {
                        znacznikZaznaczonego.Parent = zaznaczony;
                        znacznikZaznaczonego.Location = new System.Drawing.Point(0, 0);
                        znacznikZaznaczonego.Visible = true;
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
            
            znacznikZaznaczonego.Parent = samolot;
            znacznikZaznaczonego.Location = new Point(0, 0);
            if (samolot.czyJestPokazany()) znacznikZaznaczonego.Visible = true;

            // zmiana informacji
            if (samolot is Samolot) uchwytForma.getLabelInformacje().Text = ((Samolot)samolot).wypiszInformacje();
        }

        public Miniatura getZaznaczony()
        {
            return zaznaczony;
        }

        public void odswiez()
        {
            if(zaznaczony is Samolot) uchwytForma.getLabelInformacje().Text = ((Samolot)zaznaczony).wypiszInformacje();
            // rysowanie nowe?
        }

    }
}
