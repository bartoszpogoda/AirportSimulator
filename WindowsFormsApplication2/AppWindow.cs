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
        public AppWindow()
        {
            InitializeComponent();
            singleMode.Checked = true;
            peopleCount.Text = "5";
            cargoCount.Text = "44";
            ammoCount.Text = "200";

            NotificationManager.getInstance().setPanel(groupBox1);
            

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

            this.panelPasStartowy1.Size = new System.Drawing.Size(this.panelPasStartowy1.Size.Width,2*Constants.interspaceSize+Constants.imageSize+30); // wznoszenie 0 do 30 pikseli
            this.panelPasStartowy1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("passtartowy");
            this.panelPasStartowy1.BackColor = Color.Transparent;

            this.panelPasStartowy2.Size = new System.Drawing.Size(this.panelPasStartowy1.Size.Width, 2 * Constants.interspaceSize + Constants.imageSize + 30); // wznoszenie 0 do 30 pikseli
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
            } else if (stanZaznaczonegoSamolotu == State.OnRunwayBefTakeoff && aktualnieZaznaczonySamolot is PassengerPlane)
            {
                btnStartowanie.Enabled = true;
                btnStartowanie.Visible = true;
                doHangaru.Visible = true;
                doHangaru.Enabled = true;
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
            btnLanding.Enabled = false;
            btnLanding.Visible = false;
            btnSendAway.Enabled = false;
            btnSendAway.Visible = false;

        }

        
        private void tankowanie_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().fuel();
        }
        // ugololnic nazwe
        private void tankowanieCancel_Click(object sender, EventArgs e)
        {
           if(AirportManager.getInstance().getSelectedPlane() is Plane) OperationManager.getInstance().stopOperation((Plane)AirportManager.getInstance().getSelectedPlane());
        }

        private void kontrola_Click(object sender, EventArgs e)
        {

            AirportManager.getInstance().inspectTechnically();
        }
        
        private void naPasStartowy_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().placeSelectedOnRunway();
        }

        private void wyladuj_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().landSelectedPlane();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().takeoffSelectedPlane();
        }

        private void odeslij_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().odeslijZaznaczonySamolot();
        }
        
       

        private void doHangaru_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().umiescZaznaczonyWHangarze();
        }

   
        private void btnM1C_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().wyprowadzLudzi(1);
        }

        private void btnM5C_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().wyprowadzLudzi(5);
        }

        private void btnLewo_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getAirspace().scrollLeft();
        }

        private void btnPrawo_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getAirspace().scrollRight();
        }

        private void btnDol_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getHangar().scrollDown();
        }

        private void btnGora_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getHangar().scrollUp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NotificationManager.getInstance().clear();
        }
        
        private void btnLanding_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().landSelectedPlane();
        }

        private void btnSendAway_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().odeslijZaznaczonySamolot();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PlaneCreationManager.getInstance().showFactoryPanel();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (PlaneCreationManager.getInstance().Visible)
            {
                PlaneCreationManager.getInstance().hideFactoryPanel();
                ((Button)sender).Parent = this;
                ((Button)sender).Location = new Point(0, 0);
                ((Button)sender).BackColor = SystemColors.MenuHighlight;
            }
            else
            {
                PlaneCreationManager.getInstance().showFactoryPanel();
                ((Button)sender).Parent = PlaneCreationManager.getInstance();
                ((Button)sender).Location = new Point(0, PlaneCreationManager.getInstance().Size.Height - ((Button)sender).Size.Height);
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

        private void peoplePanel_Click(object sender, EventArgs e)
        {
            if(singleMode.Checked == true)
            {
                peopleCount.Text = (Int32.Parse(peopleCount.Text) - AirportManager.getInstance().addPeople(Int32.Parse(peopleCount.Text), false)).ToString();
            }
            else
            {
                peopleCount.Text = (Int32.Parse(peopleCount.Text) - AirportManager.getInstance().addPeople(Int32.Parse(peopleCount.Text), true)).ToString();
            }
        }
        private void cargoPanel_Click(object sender, EventArgs e)
        {
            if (singleMode.Checked == true)
            {
                cargoCount.Text = (Int32.Parse(cargoCount.Text) - AirportManager.getInstance().addCargo(Int32.Parse(cargoCount.Text), false)).ToString();
            }
            else
            {
                cargoCount.Text = (Int32.Parse(cargoCount.Text) - AirportManager.getInstance().addCargo(Int32.Parse(cargoCount.Text), true)).ToString();
            }
        }
        private void ammoPanel_Click(object sender, EventArgs e)
        {
            if (singleMode.Checked == true)
            {
                ammoCount.Text = (Int32.Parse(ammoCount.Text) - AirportManager.getInstance().addAmmo(Int32.Parse(ammoCount.Text), false)).ToString();
            }
            else
            {
                ammoCount.Text = (Int32.Parse(ammoCount.Text) - AirportManager.getInstance().addAmmo(Int32.Parse(ammoCount.Text), true)).ToString();
            }
        }
    }
}
