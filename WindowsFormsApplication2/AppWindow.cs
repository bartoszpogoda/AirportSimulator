using System;
using System.Windows.Forms;
using SymulatorLotniska.Planes;
using SymulatorLotniska.OperationManagement;
using SymulatorLotniska.AirportManagement;
using System.Drawing;
using SymulatorLotniska.NotificationManagement;

namespace SymulatorLotniska
{
    public partial class AppWindow : Form
    {
        private AirportManager menedzerSamolotow;
        private OperationManager menedzerOperacji;

        public AppWindow()
        {
            InitializeComponent();
            ImageColections.init();

            menedzerOperacji = new OperationManager(this);
            NotificationManager.getInstance().setPanel(groupBox1);
            menedzerSamolotow = new AirportManager(this, menedzerOperacji);

            FabrykaSamolotow.init(this, menedzerSamolotow);

            //panelSamolotow.MouseWheel += new MouseEventHandler(menedzerSamolotow.mouseWheelEventHangar);
            //panelSamolotyWPowietrzu.MouseWheel += new MouseEventHandler(menedzerSamolotow.mouseWheelEventPowietrze); // do zaprogramowania

            this.labelTekstInformacje.Parent = panelInformacji;
            this.labelTekstInformacje.AutoSize = false;
            this.labelTekstInformacje.Size = new System.Drawing.Size(labelTekstInformacje.Parent.Size.Width, this.labelTekstInformacje.Size.Height);

            this.labelSamolotyPowietrze.Parent = panelSamolotyWPowietrzu;
            this.labelSamolotyPowietrze.AutoSize = false;
            this.labelSamolotyPowietrze.Size = new System.Drawing.Size(this.labelSamolotyPowietrze.Parent.Size.Width, this.labelSamolotyPowietrze.Size.Height);

           
            this.labelInformacje.Parent = panelInformacji;

            this.labelHangar.Parent = panelSamolotow;
            this.labelHangar.AutoSize = false;
            this.labelHangar.Size = new System.Drawing.Size(labelHangar.Parent.Size.Width, this.labelHangar.Size.Height);

            this.panelPasStartowy1.Size = new System.Drawing.Size(this.panelPasStartowy1.Size.Width,2*ConfigurationConstants.interspaceSize+ConfigurationConstants.imageSize+30); // wznoszenie 0 do 30 pikseli
            this.panelPasStartowy1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("passtartowy");
            this.panelPasStartowy1.BackColor = Color.Transparent;

            this.panelPasStartowy2.Size = new System.Drawing.Size(this.panelPasStartowy1.Size.Width, 2 * ConfigurationConstants.interspaceSize + ConfigurationConstants.imageSize + 30); // wznoszenie 0 do 30 pikseli
            this.panelPasStartowy2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("passtartowy");
            this.panelPasStartowy2.BackColor = Color.Transparent;

            schowajWszystkiePrzyciskiPanelu();

        }
        public Panel getPanelSamolotowPowietrze() { return this.panelSamolotyWPowietrzu; }
        public Panel getPanelSamolotow() { return this.panelSamolotow;  }
        public Label getLabelInformacje() { return this.labelInformacje;  }
        public Panel getPasStartowy1() { return this.panelPasStartowy1; }
        public Panel getPasStartowy2() { return this.panelPasStartowy2; }

       public void uaktualnijPrzyciskiPanelu(PlaneImage aktualnieZaznaczony)
        {

            // bedziemy potem wyłapywac też typ samolotu

            schowajWszystkiePrzyciskiPanelu();

            if (!(aktualnieZaznaczony is Plane) )
                return;
            
            Plane aktualnieZaznaczonySamolot = (Plane)aktualnieZaznaczony;
            

            State stanZaznaczonegoSamolotu = aktualnieZaznaczonySamolot.getCurrentState();
            

            if (stanZaznaczonegoSamolotu == State.Fueling)
            {
                operationCancel.Enabled = true;
                operationCancel.Visible = true;
            }
            else if(stanZaznaczonegoSamolotu == State.Hangar)
            {
                kontrola.Enabled = true;
                kontrola.Visible = true;
                naPasStartowy.Enabled = true;
                naPasStartowy.Visible = true;
                tankowanie.Enabled = true;
                tankowanie.Visible = true;

                if (aktualnieZaznaczonySamolot.isTanked())
                    tankowanie.BackColor = System.Drawing.Color.YellowGreen;
                else
                    tankowanie.BackColor = System.Drawing.Color.White;

                if (aktualnieZaznaczonySamolot.isAfterTechnicalInspection())
                    kontrola.BackColor = System.Drawing.Color.YellowGreen;
                else
                    kontrola.BackColor = System.Drawing.Color.White;
            }
            else if(stanZaznaczonegoSamolotu == State.TechnicalInspection)
            {
                //operationCancel.Text = "Zatrzymaj kontrole";
                operationCancel.Enabled = true;
                operationCancel.Visible = true;
            }
            else if (stanZaznaczonegoSamolotu == State.InAir)
            {
                btnLanding.Enabled = true;
                btnLanding.Visible = true;
                btnSendAway.Enabled = true;
                btnSendAway.Visible = true;
            }
            else if (stanZaznaczonegoSamolotu == State.OnRunwayBefTakeoff && aktualnieZaznaczonySamolot is PassengerPlane)
            {
                btnStartowanie.Enabled = true;
                btnStartowanie.Visible = true;
                doHangaru.Visible = true;
                doHangaru.Enabled = true;
                btnD1C.Enabled = true;
                btnD1C.Visible = true;
                btnD5C.Enabled = true;
                btnD5C.Visible = true;
                btnM1C.Enabled = true;
                btnM1C.Visible = true;
                btnM5C.Enabled = true;
                btnM5C.Visible = true;
            } else if (stanZaznaczonegoSamolotu == State.OnRunwayBefTakeoff && aktualnieZaznaczonySamolot is PassengerPlane)
            {
                btnStartowanie.Enabled = true;
                btnStartowanie.Visible = true;
                doHangaru.Visible = true;
                doHangaru.Enabled = true;
                btnD1C.Enabled = true;
                btnD1C.Visible = true;
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
            btnStartowanie.Enabled = false;
            btnStartowanie.Visible = false;
            doHangaru.Visible = false;
            doHangaru.Enabled = false;
            btnD1C.Enabled = false;
            btnD1C.Visible = false;
            btnD5C.Enabled = false;
            btnD5C.Visible = false;
            btnM1C.Enabled = false;
            btnM1C.Visible = false;
            btnM5C.Enabled = false;
            btnM5C.Visible = false;
            btnLanding.Enabled = false;
            btnLanding.Visible = false;
            btnSendAway.Enabled = false;
            btnSendAway.Visible = false;

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
            menedzerSamolotow.fuel();
        }
        // ugololnic nazwe
        private void tankowanieCancel_Click(object sender, EventArgs e)
        {
           if(menedzerSamolotow.getZaznaczony() is Plane) menedzerOperacji.stopOperation((Plane)menedzerSamolotow.getZaznaczony());
        }

        private void kontrola_Click(object sender, EventArgs e)
        {

            menedzerSamolotow.inspectTechnically();
        }
        
        private void naPasStartowy_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.placeSelectedOnRunway();
        }

        private void wyladuj_Click(object sender, EventArgs e)
        {
           menedzerSamolotow.landSelectedPlane();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.takeoffSelectedPlane();
        }

        private void odeslij_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.odeslijZaznaczonySamolot();
        }
        
        private void wprowadzenieLudzi_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.wprowadzLudzi(1);
        }

        private void doHangaru_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.umiescZaznaczonyWHangarze();
        }

        private void btnD5C_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.wprowadzLudzi(5);
        }

        private void btnM1C_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.wyprowadzLudzi(1);
        }

        private void btnM5C_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.wyprowadzLudzi(5);
        }

        private void btnLewo_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.getAirspace().scrollLeft();
        }

        private void btnPrawo_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.getAirspace().scrollRight();
        }

        private void btnDol_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.getHangar().scrollDown();
        }

        private void btnGora_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.getHangar().scrollUp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NotificationManager.getInstance().clear();
        }
        
        private void btnLanding_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.landSelectedPlane();
        }

        private void btnSendAway_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.odeslijZaznaczonySamolot();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FabrykaSamolotow.getInstance().showFactoryPanel();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (FabrykaSamolotow.getInstance().Visible)
            {
                FabrykaSamolotow.getInstance().hideFactoryPanel();
                ((Button)sender).Parent = this;
                ((Button)sender).Location = new Point(0, 0);
                ((Button)sender).BackColor = SystemColors.MenuHighlight;
            }
            else
            {
                FabrykaSamolotow.getInstance().showFactoryPanel();
                ((Button)sender).Parent = FabrykaSamolotow.getInstance();
                ((Button)sender).Location = new Point(0, FabrykaSamolotow.getInstance().Size.Height - ((Button)sender).Size.Height);
               // ((Button)sender).BackColor = Color.IndianRed;
            }
        }

        public void planeFactoryButtonToTop()
        {
            button6.Parent = this;
            button6.Location = new Point(0, 0);
            button6.BackColor = SystemColors.MenuHighlight;
        }

        private void AppWindow_Load(object sender, EventArgs e)
        {

        }

        private void labelSamolotyPowietrze_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            menedzerSamolotow.dbgDodajSamolot(0);
        }
    }
}
