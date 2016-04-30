using System;
using System.Windows.Forms;
using SymulatorLotniska.Samoloty;
using SymulatorLotniska.ZarzadzanieOperacjami;
using SymulatorLotniska.ZarzadzanieSamolotami;
using System.Drawing;

namespace SymulatorLotniska
{
    public partial class OknoAplikacji : Form
    {
        private MenedzerSamolotow menedzerSamolotow;
        private MenedzerOperacji menedzerOperacji;

        public OknoAplikacji()
        {
            InitializeComponent();
            menedzerOperacji = new MenedzerOperacji(this);
            menedzerSamolotow = new MenedzerSamolotow(this, menedzerOperacji);
            panelSamolotow.MouseWheel += new MouseEventHandler(menedzerSamolotow.mouseWheelEventHangar);
            panelSamolotyWPowietrzu.MouseWheel += new MouseEventHandler(menedzerSamolotow.mouseWheelEventPowietrze); // do zaprogramowania

            this.labelTekstInformacje.Parent = panelInformacji;
            this.labelTekstInformacje.AutoSize = false;
            this.labelTekstInformacje.Size = new System.Drawing.Size(labelTekstInformacje.Parent.Size.Width, this.labelTekstInformacje.Size.Height);

            this.labelWPowietrzu.Parent = panelSamolotyWPowietrzu;
            this.labelWPowietrzu.AutoSize = false;
            this.labelWPowietrzu.Size = new System.Drawing.Size(this.labelWPowietrzu.Size.Width, this.labelWPowietrzu.Parent.Size.Height/2);

            this.labelInformacje.Parent = panelInformacji;

            this.labelHangar.Parent = panelSamolotow;
            this.labelHangar.AutoSize = false;
            this.labelHangar.Size = new System.Drawing.Size(labelHangar.Parent.Size.Width, this.labelHangar.Size.Height);

            this.panelPasStartowy1.Size = new System.Drawing.Size(this.panelPasStartowy1.Size.Width,2*StaleKonfiguracyjne.rozmiarOdstepu+StaleKonfiguracyjne.rozmiarObrazka+30); // wznoszenie 0 do 30 pikseli
            this.panelPasStartowy1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("passtartowy");
            this.panelPasStartowy1.BackColor = Color.Transparent;

            this.panelPasStartowy2.Size = new System.Drawing.Size(this.panelPasStartowy1.Size.Width, 2 * StaleKonfiguracyjne.rozmiarOdstepu + StaleKonfiguracyjne.rozmiarObrazka + 30); // wznoszenie 0 do 30 pikseli
            this.panelPasStartowy2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("passtartowy");
            this.panelPasStartowy2.BackColor = Color.Transparent;

            schowajWszystkiePrzyciskiPanelu();
        }
        public Panel getPanelSamolotowPowietrze() { return this.panelSamolotyWPowietrzu; }
        public Panel getPanelSamolotow() { return this.panelSamolotow;  }
        public Label getLabelInformacje() { return this.labelInformacje;  }
        public Panel getPasStartowy1() { return this.panelPasStartowy1; }
        public Panel getPasStartowy2() { return this.panelPasStartowy2; }


        public void uaktualnijPrzyciskiPanelu(Miniatura aktualnieZaznaczony)
        {

            // bedziemy potem wyłapywac też typ samolotu

            schowajWszystkiePrzyciskiPanelu();

            if (!(aktualnieZaznaczony is Samolot) )
                return;
            
            Samolot aktualnieZaznaczonySamolot = (Samolot)aktualnieZaznaczony;
            

            Stan stanZaznaczonegoSamolotu = aktualnieZaznaczonySamolot.getAktualnyStan();
            

            if (stanZaznaczonegoSamolotu == Stan.Tankowanie)
            {
                operationCancel.Text = "Zatrzymaj tankowanie";
                operationCancel.Enabled = true;
                operationCancel.Visible = true;
            
            }
            else if(stanZaznaczonegoSamolotu == Stan.Hangar)
            {
                kontrola.Enabled = true;
                kontrola.Visible = true;
                naPasStartowy.Enabled = true;
                naPasStartowy.Visible = true;
                tankowanie.Enabled = true;
                tankowanie.Visible = true;

                if (aktualnieZaznaczonySamolot.czyZatankowany())
                    tankowanie.BackColor = System.Drawing.Color.YellowGreen;
                else
                    tankowanie.BackColor = System.Drawing.Color.White;

                if (aktualnieZaznaczonySamolot.PoKontroli)
                    kontrola.BackColor = System.Drawing.Color.YellowGreen;
                else
                    kontrola.BackColor = System.Drawing.Color.White;
            }
            else if(stanZaznaczonegoSamolotu == Stan.KontrolaTechniczna)
            {
                operationCancel.Text = "Zatrzymaj kontrole";
                operationCancel.Enabled = true;
                operationCancel.Visible = true;
                pasekPostepu.Visible = true;
                pasekPostepu.Enabled = true;
            }
            else if (stanZaznaczonegoSamolotu == Stan.WPowietrzu)
            {
                wyladuj.Enabled = true;
                wyladuj.Visible = true;
            }
            else if (stanZaznaczonegoSamolotu == Stan.PrzedStartem && aktualnieZaznaczonySamolot is SamolotOsobowy)
            {
                start.Enabled = true;
                start.Visible = true;
                doHangaru.Visible = true;
                doHangaru.Enabled = true;
                wprowadzenieLudzi.Enabled = true;
                wprowadzenieLudzi.Visible = true;
                wyprowadzLudzi.Enabled = true;
                wyprowadzLudzi.Visible = true;
            }

        }

        private void schowajWszystkiePrzyciskiPanelu()
        {
            // mozna potem to na tablice przerobic
            kontrola.Enabled = false;
            kontrola.Visible = false;
            naPasStartowy.Enabled = false;
            naPasStartowy.Visible = false;
            tankowanie.Enabled = false;
            tankowanie.Visible = false;
            operationCancel.Enabled = false;
            operationCancel.Visible = false;
            pasekPostepu.Visible = false;
            pasekPostepu.Enabled = false;
            wyladuj.Enabled = false;
            wyladuj.Visible = false;
            start.Enabled = false;
            start.Visible = false;
            doHangaru.Visible = false;
            doHangaru.Enabled = false;
            wprowadzenieLudzi.Enabled = false;
            wprowadzenieLudzi.Visible = false;
            wyprowadzLudzi.Enabled = false;
            wyprowadzLudzi.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.dbgDodajSamolot(0);
        }
   
        private void button2_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.dbgDodajSamolot(1);
        }

        private void tankowanie_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.tankujZaznaczonySamolot();
        }
        // ugololnic nazwe
        private void tankowanieCancel_Click(object sender, EventArgs e)
        {
           if(menedzerSamolotow.getZaznaczony() is Samolot) menedzerOperacji.zatrzymajOperacje((Samolot)menedzerSamolotow.getZaznaczony());
        }

        private void kontrola_Click(object sender, EventArgs e)
        {

            menedzerSamolotow.kontrolujZaznaczonySamolot(pasekPostepu);
        }
        

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void naPasStartowy_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.wystawZaznaczonyNaWolnyPas();
        }

        private void wyladuj_Click(object sender, EventArgs e)
        {
           // menedzerSamolotow.wyladujZaznaczonySamolot();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.wystartujZaznaczonySamolot();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
