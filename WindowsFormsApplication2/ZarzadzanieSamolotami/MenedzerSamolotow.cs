using SymulatorLotniska.Operacje;
using SymulatorLotniska.Samoloty;
using SymulatorLotniska.ZarzadzanieOperacjami;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace SymulatorLotniska.ZarzadzanieSamolotami
{
    //TODO: Klase MenedzerSamolotow oraz MendzerOperacji mozna zrobic jako singleton.
    //TODO: SKoro odnalazlem ten bład moze jednak lepiej bedzie rozdzielic operacje lotu, startowania itp?
    //      ^ polaczenie tych 3 ze soba jest juz niewygodne gdy trzeba dodac informacje do operacji na temat wolnego
    //        pasa startowego.
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

        private PasStartowy pasStartowy1;
        private PasStartowy pasStartowy2;
        
        public MenedzerSamolotow(OknoAplikacji uchwytOknoAplikacji, MenedzerOperacji uchwytMenedzerOperacji) {
            this.uchwytOknoAplikacji = uchwytOknoAplikacji;
            this.uchwytMenedzerOperacji = uchwytMenedzerOperacji;

            listaSamolotow = new ListaSamolotow(uchwytOknoAplikacji.getPanelSamolotow());
            listaSamolotowPowietrze = new ListaSamolotow(uchwytOknoAplikacji.getPanelSamolotowPowietrze());

            pbZaznaczony = new PictureBox();
            zainicjujZnacznikZaznaczonego();

            pasStartowy1 = new PasStartowy(uchwytOknoAplikacji.getPasStartowy1());
            pasStartowy2 = new PasStartowy(uchwytOknoAplikacji.getPasStartowy2());
        }
        
        public Miniatura getZaznaczony() { return zaznaczony; }


        public void dbgDodajSamolot(int i) { // debugFunkcja do usuniecia jak bedzie kreator
            if (i == 1) wygenerujLosowySamolotWPowietrzu();
            else
            {
                listaSamolotow.dodajSamolot(new SamolotOsobowy(this, uchwytOknoAplikacji.getPanelSamolotow(), 250, 50, 100, 30, 100, "Boening707"));
                narysujSamolotyZListy();
                narysujSamolotyZListyPowietrze();
            }
        }

        public void wygenerujLosowySamolotWPowietrzu() { // prototyp
            Samolot samolot = new SamolotOsobowy(this, uchwytOknoAplikacji.getPanelSamolotowPowietrze(), 20, 20, 500, 30, 100, "Tupolew");
            samolot.setAktualnyStan(Stan.WPowietrzu);
            samolot.AktualnaIloscPaliwa = samolot.getMaksIloscPaliwa(); // to pozniej bedzie losowe
            listaSamolotowPowietrze.dodajSamolot(samolot);
            uchwytMenedzerOperacji.dodajOperacje(new OperacjaLot(samolot,this));
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
            if (e.Delta < 0) // scrollowanie w dol
                przesunListeHangarDol();
            else // scrollowanie w górę
                przesunListeHangarGora();
        }

        public void przesunListePowietrzeLewo()
        {
            if (aktualnyRzadStartowyPowietrze > 0)
            {
                aktualnyRzadStartowyPowietrze--;
                narysujSamolotyZListyPowietrze();
            }
        }
        public void przesunListePowietrzePrawo()
        {
            if (listaSamolotowPowietrze.getLength() - 8 > aktualnyRzadStartowyPowietrze)
            {
                aktualnyRzadStartowyPowietrze++;
                narysujSamolotyZListyPowietrze();
            }
        }

        public void przesunListeHangarGora()
        {
            if (aktualnyRzadStartowy > 0)
            {
                aktualnyRzadStartowy--;
                narysujSamolotyZListy();
            }
        }
        public void przesunListeHangarDol()
        {
            if (listaSamolotow.getLength() / StaleKonfiguracyjne.iloscKolumn - StaleKonfiguracyjne.iloscRzedow + 1 > aktualnyRzadStartowy) 
            {
                aktualnyRzadStartowy++;
                narysujSamolotyZListy();
            }
        }

        public void mouseWheelEventPowietrze(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) // scrollowanie w prawo
                przesunListePowietrzePrawo();
            else // scrollowanie w górę
                przesunListePowietrzeLewo();
        }

        //TODO: Raczej daloby sie to jakos ladniej zapisac. 
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
                for (int j = 0; j < StaleKonfiguracyjne.iloscKolumn; j++)
                {
                    listaSamolotow.aktualnyPodIteratorem().getObrazekSamolotu().Location = new Point(
                        StaleKonfiguracyjne.rozmiarOdstepu * (j + 1) + j * StaleKonfiguracyjne.rozmiarObrazka,
                           10 + StaleKonfiguracyjne.rozmiarOdstepu * (i + 1) + i * StaleKonfiguracyjne.rozmiarObrazka
                           );
                    listaSamolotow.aktualnyPodIteratorem().pokaz();

                    if (listaSamolotow.aktualnyPodIteratorem().Equals(zaznaczony)) {
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

            for (i = 0; i < 8; i++)
            {
                
                listaSamolotowPowietrze.aktualnyPodIteratorem().getObrazekSamolotu().Location = new Point(StaleKonfiguracyjne.rozmiarOdstepu * (i + 1) + i * StaleKonfiguracyjne.rozmiarObrazka,
                           10 + StaleKonfiguracyjne.rozmiarOdstepu);
                
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
            zaznaczony = samolot;
            
            pbZaznaczony.Parent = samolot.getAktualnyNaGorze();
            pbZaznaczony.Location = new Point(0, 0);

            if (samolot.czyJestPokazany()) pbZaznaczony.Visible = true;

            // zmiana informacji
            //if (samolot is Samolot) uchwytForma.getLabelInformacje().Text = ((Samolot)samolot).wypiszInformacje();
            odswiezInformacje();
            uaktualnijPrzyciski();
        }

        public void uaktualnijPbZaznaczonyJesliZaznaczony(Miniatura samolot)
        {
            if(zaznaczony == samolot)
            {
                pbZaznaczony.Parent = zaznaczony.getAktualnyNaGorze();
                if (zaznaczony.czyJestPokazany()) pbZaznaczony.Visible = true; // <razcej nie potrzebne
            }
        }
        public void uaktualnijPbZaznaczony()
        {
            pbZaznaczony.Parent = zaznaczony.getAktualnyNaGorze();
            if (zaznaczony.czyJestPokazany()) pbZaznaczony.Visible = true; // <raczej nie potrzebne
        }

       
        //--------------------------------------------------------------------
        //--------------------------------------------------------------------
        //--------   OPERACJE NA ZAZNACZONYM AKTUALNIE SAMOLOCIE -------------
        public void tankujZaznaczony()
        {
            if (zaznaczony is Samolot)
            {
                if (((Samolot)zaznaczony).czyZatankowany())
                {
                    // LOG --Samolot (zaznaczony) ma juz pelny bak--
                }
                else
                {
                    getMenedzerOperacji().dodajOperacje(new OperacjaTankowanie((Samolot)zaznaczony));
                    // LOG --Rozpoczecie tankowania samolotu (zaznaczony)--
                }
            }
        }

        public void kontrolujTechnicznieZaznaczony()
        {
            if (zaznaczony is Samolot)
            {
                if (((Samolot)zaznaczony).czyPoKontroli())
                {
                    // LOG --Samolot (zaznaczony) przeszedl juz kontrole techniczna--
                }
                else
                {
                    getMenedzerOperacji().dodajOperacje(new OperacjaKontrolaTechniczna((Samolot)zaznaczony));
                }

            }
        }

        public void odeslijZaznaczonySamolot()
        {
            if(zaznaczony is Samolot && ((Samolot)zaznaczony).getAktualnyStan() == Stan.WPowietrzu)
            {
                if (false) // warunek odeslania - np za mala ilosc paliwa
                {
                   // LOG --Nie mozna odeslac samolotu (zaznaczony) ze wzgledu na......--
                }
                else
                {
                    // LOG --Samolot (zaznazczony) zostal odeslany--
                    ((Samolot)zaznaczony).setAktualnyStan(Stan.Odeslany);
                    listaSamolotowPowietrze.usunSamolot((Samolot)zaznaczony);
                    ((Samolot)zaznaczony).schowaj();

                    zaznaczony.setParent(null);
                    zaznaczony = null;

                    odswiezInformacje();
                    uaktualnijPrzyciski();
                    narysujSamolotyZListyPowietrze();
                }
            }
        }

        public void wystawZaznaczonyNaWolnyPas()
        {
            if (!(zaznaczony is Samolot) || !((Samolot)zaznaczony).czyPoKontroli() || !(((Samolot)zaznaczony).getAktualnyStan() == Stan.Hangar))
            {
                // LOG--Informacje ze nie jest po kontroli technicznej.--
                return;
            }

            if (pasStartowy1.czyWolny())
            {
                // LOG--Informacja, ze Samolot (zaznaczony) zostal umieszczony na pasie nr 1.--
                ((Samolot)zaznaczony).setAktualnyStan(Stan.PrzedStartem);
                listaSamolotow.usunSamolot((Samolot)zaznaczony);
                pasStartowy1.ustawSamolot((Samolot)zaznaczony);
                narysujSamolotyZListy();
            }
            else if (pasStartowy2.czyWolny())
            {
                // LOG--Informacja, ze Samolot (zaznaczony) zostal umieszczony na pasie nr 1.--
                ((Samolot)zaznaczony).setAktualnyStan(Stan.PrzedStartem);
                listaSamolotow.usunSamolot((Samolot)zaznaczony);
                pasStartowy2.ustawSamolot((Samolot)zaznaczony);
                narysujSamolotyZListy();
            }
            else
            {
                // LOG--Informacja, ze nie ma wolnych pasów startowych.
            }
        }
        public void wystartujZaznaczonySamolot()
        {
            if(zaznaczony is Samolot && ((Samolot)zaznaczony).getAktualnyStan() == Stan.PrzedStartem)
            {
                if (false) // warunek  czy ludzi jest dobra ilosc i towarow
                {                    
                    // LOG --Samolotu (zaznaczony) nie przeszedl kontroli przed startem. Np jest przeludniony--
                }
                else
                {
                    if(!pasStartowy1.czyWolny() && pasStartowy1.getAktualnySamolot() == (Samolot)zaznaczony)
                    {
                        // LOG --Samolot (zaznaczony) startuje z pasa pierwszego.--
                        ((Samolot)zaznaczony).setAktualnyStan(Stan.Startowanie);
                        getMenedzerOperacji().dodajOperacje(new OperacjaStartowanie((Samolot)zaznaczony, pasStartowy1,this));
                    }
                    else if (!pasStartowy2.czyWolny() && pasStartowy2.getAktualnySamolot() == (Samolot)zaznaczony)
                    {
                        // LOG --Samolot (zaznaczony) startuje z pasa pierwszego.--
                        ((Samolot)zaznaczony).setAktualnyStan(Stan.Startowanie);
                        getMenedzerOperacji().dodajOperacje(new OperacjaStartowanie((Samolot)zaznaczony, pasStartowy2, this));
                    }
                }
            }
        }

        public void wyladujZaznaczonySamolot() // not fully implemented
        {
            if(zaznaczony is Samolot && ((Samolot)zaznaczony).getAktualnyStan() == Stan.WPowietrzu)
            {
                if (pasStartowy1.czyWolny())
                {
                    // LOG --Samolot (zaznaczony) podchodzi do ladowania na pasie 1--
                    ((Samolot)zaznaczony).setAktualnyStan(Stan.Ladowanie);
                    listaSamolotowPowietrze.usunSamolot((Samolot)zaznaczony);
                    pasStartowy1.ustawSamolot((Samolot)zaznaczony);
                    narysujSamolotyZListyPowietrze();
                    //getMenedzerOperacji().dodajOperacje(new OperacjaLadowanie((Samolot)zaznaczony, pasStartowy1,this));
                }
                else if (pasStartowy2.czyWolny())
                {
                    // LOG --Samolot (zaznaczony) podchodzi do ladowania na pasie 2--
                    ((Samolot)zaznaczony).setAktualnyStan(Stan.Ladowanie);
                    listaSamolotowPowietrze.usunSamolot((Samolot)zaznaczony);
                    pasStartowy2.ustawSamolot((Samolot)zaznaczony);
                    narysujSamolotyZListyPowietrze();
                    //getMenedzerOperacji().dodajOperacje(new OperacjaLadowanie((Samolot)zaznaczony, pasStartowy2, this));
                }
                else
                {
                    // LOG --Pasy startowe sa zajete--
                }
            }
        }

        public void umiescZaznaczonyWHangarze()
        {
            if(zaznaczony is Samolot && ((Samolot)zaznaczony).getAktualnyStan() == Stan.PrzedStartem)
            {
                if (zaznaczony is SamolotOsobowy)
                {
                    if (((SamolotOsobowy)zaznaczony).getAktualnaIloscPasazerow() != 0)
                    {
                        // LOG --Nie chcesz chyba zamknac pasazerow w hangarze
                        return;
                    }
                }
                // zaznaczony is SamolotTowarowy

                if(pasStartowy1.getAktualnySamolot() == zaznaczony)
                {
                    pasStartowy1.zdejmijAktualnySamolot();
                    listaSamolotow.dodajSamolot((Samolot)zaznaczony);
                    ((Samolot)zaznaczony).setAktualnyStan(Stan.Hangar);
                }
                else if(pasStartowy2.getAktualnySamolot() == zaznaczony)
                {
                    pasStartowy2.zdejmijAktualnySamolot();
                    listaSamolotow.dodajSamolot((Samolot)zaznaczony);
                    ((Samolot)zaznaczony).setAktualnyStan(Stan.Hangar);
                }
            }
        }

        public void wprowadzLudzi(int n)
        {
            if(zaznaczony is SamolotOsobowy)
            {
                ((SamolotOsobowy)zaznaczony).setAktualnaIloscPasazerow(((SamolotOsobowy)zaznaczony).getAktualnaIloscPasazerow() + n);
            }
        }
        public void wyprowadzLudzi(int n)
        {
            if (zaznaczony is SamolotOsobowy)
            {
                if(((SamolotOsobowy)zaznaczony).getAktualnaIloscPasazerow() - n < 0)
                {
                    // LOG --Nie ma tylu pasazerow
                    return;
                }

                ((SamolotOsobowy)zaznaczony).setAktualnaIloscPasazerow(((SamolotOsobowy)zaznaczony).getAktualnaIloscPasazerow() - n);
            }
        }

        //--------------------------------------------------------------------
        //--------------------------------------------------------------------
        //--------   OPERACJE NA SAMOLOTACH                      -------------

        public void umiescWPowietrzu(Samolot samolot)
        {
            listaSamolotowPowietrze.dodajSamolot(samolot);
            samolot.getObrazekSamolotu().Parent = uchwytOknoAplikacji.getPanelSamolotowPowietrze();
            samolot.setAktualnyStan(Stan.WPowietrzu);
            getMenedzerOperacji().dodajOperacje(new OperacjaLot(samolot, this));
            narysujSamolotyZListyPowietrze();
        }

      


        public void odswiezInformacje()
        {
            if (zaznaczony is Samolot)
            {
                uchwytOknoAplikacji.getLabelInformacje().Text = ((Samolot)zaznaczony).wypiszInformacje();
            }
            else
             uchwytOknoAplikacji.getLabelInformacje().Text = "Wybierz samolot";


        }
        public void oswiezInformacjeJezeliZaznaczony(Samolot samolot)
        {
            if (zaznaczony is Samolot && zaznaczony == samolot)
            {
                uchwytOknoAplikacji.getLabelInformacje().Text = ((Samolot)zaznaczony).wypiszInformacje();
            }
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
    }
}
