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
        private const string adresImgZaznaczony = "znacznik.png";
        //----------------------------------------------
        private int aktualnyRzadStartowy = 0; // na potrzeby scrollowania

        private Miniatura zaznaczony;
        private ListaSamolotow listaSamolotow; // w hangarze
        private Form uchwytForma;

        private Panel panelSamolotow;
        private Panel panelInformacji;
        private Label labelHangar;
        private Label labelInformacje;
        private PictureBox znacznikZaznaczonego;

      

        public MenedzerSamolotow(Form uchwytForma) {
            this.uchwytForma = uchwytForma;
            listaSamolotow = new ListaSamolotow();

            panelSamolotow = new Panel();
            panelInformacji = new Panel();
            labelHangar = new Label();
            labelInformacje = new Label();
            znacznikZaznaczonego = new PictureBox();

            zainicjujZnacznikZaznaczonego();
            zainicjujPanelSamolotow();
            zainicjujPanelInformacji();
            zainicjujLabelHangar();
            zainicjujLabelInformacje();
        }

        public void dbgDodajSamolot() { // debugFunkcja do usuniecia jak bedzie kreator
            listaSamolotow.dodajSamolot(new SamolotOsobowy("samolot1", this.uchwytForma, this, 50,20));
            narysujSamolotyZListy();
        }
        public Panel getPanelSamolotow() { return panelSamolotow; }
        private void zainicjujZnacznikZaznaczonego()
        {
            if (znacznikZaznaczonego == null || uchwytForma == null) return;

            znacznikZaznaczonego.Image = Image.FromFile(adresImgZaznaczony);
            znacznikZaznaczonego.BackColor = Color.Transparent;
            znacznikZaznaczonego.Location = new Point(0, 0);
            znacznikZaznaczonego.Enabled = false;
            znacznikZaznaczonego.Visible = false;
            znacznikZaznaczonego.Size = new Size(50, 50);
            uchwytForma.Controls.Add(znacznikZaznaczonego);
        }

        private void zainicjujPanelSamolotow()
        {
            if (panelSamolotow == null || uchwytForma == null) return;

            panelSamolotow.BackColor = SystemColors.ControlDark;
            panelSamolotow.Location = new Point(10, 15);
            panelSamolotow.Name = "panel1";
            panelSamolotow.Size = new Size(250, 200);
            panelSamolotow.MouseWheel += new MouseEventHandler(this.mouseWheelEvent);
            uchwytForma.Controls.Add(panelSamolotow);
        }

        private void zainicjujPanelInformacji()
        {
            if (panelInformacji == null || uchwytForma == null) return;
            panelInformacji.BackColor = Color.AntiqueWhite;
            panelInformacji.Location = new Point(270, 0);
            panelInformacji.Name = "panel1";
            panelInformacji.Size = new Size(200, 210);
            panelInformacji.TabIndex = 1;
            uchwytForma.Controls.Add(panelInformacji);
        }

        private void zainicjujLabelHangar()
        {
            if (labelHangar == null || panelSamolotow == null) return;
            labelHangar.Text = "Samoloty w hangarze:";
            labelHangar.ForeColor = Color.White;
            labelHangar.Location = new Point(0, 0);
            labelHangar.AutoSize = true;
            labelHangar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelHangar.Parent = panelSamolotow;
        }

        private void zainicjujLabelInformacje()
        {
            if (labelInformacje == null || panelInformacji == null) return;
            labelInformacje.Text = "Wybierz samolot";
            labelInformacje.ForeColor = Color.Black;
            labelInformacje.Location = new Point(0, 0);
            labelInformacje.AutoSize = true;
            labelInformacje.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelInformacje.Parent = panelInformacji;
        }
        private void mouseWheelEvent(object sender, MouseEventArgs e)
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
            if (samolot is Samolot) labelInformacje.Text = ((Samolot)samolot).wypiszInformacje();
        }

        public Miniatura getZaznaczony()
        {
            return zaznaczony;
        }

        public void odswiez()
        {
            if(zaznaczony is Samolot) labelInformacje.Text = ((Samolot)zaznaczony).wypiszInformacje();
            // rysowanie nowe?
        }

    }
}
