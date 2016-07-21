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
        bool operationModeOn;
        public AppWindow()
        {
            InitializeComponent();
            operationModeOn = true;

            peopleCount.Text = "50";
            cargoCount.Text = "400";
            ammoCount.Text = "200";

            NotificationManager.getInstance().setPanel(groupBox1);

            labelTekstInformacje.Parent = panelInformacji;
            labelTekstInformacje.AutoSize = false;
            labelTekstInformacje.Size = new Size(labelTekstInformacje.Parent.Size.Width, labelTekstInformacje.Size.Height);

            labelSamolotyPowietrze.Parent = panelSamolotyWPowietrzu;
            labelSamolotyPowietrze.AutoSize = false;
            labelSamolotyPowietrze.Size = new Size(labelSamolotyPowietrze.Parent.Size.Width, labelSamolotyPowietrze.Size.Height);
            
            labelInformacje.Parent = panelInformacji;

            labelHangar.Parent = panelSamolotow;
            labelHangar.AutoSize = false;
            labelHangar.Size = new Size(labelHangar.Parent.Size.Width, labelHangar.Size.Height);

            panelPasStartowy1.Size = new Size(panelPasStartowy1.Size.Width,2*Constants.interspaceSize+Constants.imageSize+30); // wznoszenie 0 do 30 pikseli
            panelPasStartowy1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("passtartowy");
            panelPasStartowy1.BackColor = Color.Transparent;

            panelPasStartowy2.Size = new Size(panelPasStartowy1.Size.Width, 2 * Constants.interspaceSize + Constants.imageSize + 30); // wznoszenie 0 do 30 pikseli
            panelPasStartowy2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("passtartowy");
            panelPasStartowy2.BackColor = Color.Transparent;

            hideAllButtons();
        }

        public Panel getPanelSamolotowPowietrze() { return panelSamolotyWPowietrzu; }
        public Panel getPanelSamolotow() { return panelSamolotow;  }
        public Label getLabelInformacje() { return labelInformacje;  }
        public Panel getPasStartowy1() { return panelPasStartowy1; }
        public Panel getPasStartowy2() { return panelPasStartowy2; }

        public TextBox getPeopleCount() { return peopleCount; }
        public TextBox getCargoCount() { return cargoCount; }
        public TextBox getAmmoCount() { return ammoCount; }

        public void refreshButtonPanel(PlaneImage currrentSelected)
        {
            hideAllButtons();

            if (!(currrentSelected is Plane) )
                return;
            
            Plane currentSelectedPlane = (Plane)currrentSelected;
            
            State currentSelectedPlaneState = currentSelectedPlane.getCurrentState();
            
            if (currentSelectedPlaneState == State.Fueling || currentSelectedPlaneState == State.TechnicalInspection
                || currentSelectedPlaneState == State.Loading || currentSelectedPlaneState == State.Unloading )
            {
                btnCancelOperation.Visible = true;
            }
            else if(currentSelectedPlaneState == State.Hangar)
            {
                btnTechnicalInspection.Visible = true;
                btnOnRunway.Visible = true;
                btnFuel.Visible = true;

                if (currentSelectedPlane.isTanked())
                    btnFuel.BackColor = Color.YellowGreen;
                else
                    btnFuel.BackColor = Color.White;

                if (currentSelectedPlane.isAfterTechnicalInspection())
                    btnTechnicalInspection.BackColor = Color.YellowGreen;
                else
                    btnTechnicalInspection.BackColor = Color.White;

            }
            else if (currentSelectedPlaneState == State.InAir)
            {
                btnLand.Visible = true;
                btnSendAway.Visible = true;
            }
            else if (currentSelectedPlaneState == State.OnRunwayBefTakeoff)
            {
                btnStartowanie.Visible = true;
                btnToHangar.Visible = true;
                btnUnload.Visible = true;
            }
            else if(currentSelectedPlaneState == State.OnRunwayAftLanding)
            {
                btnToHangar.Visible = true;
                btnUnload.Visible = true;
            }
            else if (currentSelectedPlaneState == State.Destroyed)
            {
                btnDelete.Visible = true;
            }
        }

        private void hideAllButtons()
        {
            btnTechnicalInspection.Visible = false;
            btnOnRunway.Visible = false;
            btnFuel.Visible = false;
            btnCancelOperation.Visible = false;
            btnStartowanie.Visible = false;
            btnToHangar.Visible = false;
            btnLand.Visible = false;
            btnSendAway.Visible = false;
            btnUnload.Visible = false;
            btnDelete.Visible = false;
        }

        
        private void btnFuel_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().fuel();
        }
       
        private void btnCancelOperation_click(object sender, EventArgs e)
        {
           if(AirportManager.getInstance().getSelectedPlane() is Plane)
                OperationManager.getInstance().stopOperation((Plane)AirportManager.getInstance().getSelectedPlane());
        }

        private void btnTechnicalInspection_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().inspectTechnically();
        }
        
        private void btnOnRunway_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().placeOnRunway();
        }

        private void btnLand_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().land();
        }

        private void btnTakeoff_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().takeOff();
        }

        private void btnSendAway_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().sendAway();
        }
        
        private void btnToHangar_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().placeInHangar();
        }

   
        private void btnLeft_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getAirspace().scrollLeft();
        }

        private void btnRight_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getAirspace().scrollRight();
        }

        private void btnDown_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getHangar().scrollDown();
        }

        private void btnUp_click(object sender, EventArgs e)
        {
            AirportManager.getInstance().getHangar().scrollUp();
        }

        private void btnClearNotificationList_click(object sender, EventArgs e)
        {
            NotificationManager.getInstance().clear();
        }
        
        private void btnShowFactoryPanel(object sender, EventArgs e)
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

        public void refreshBtnPlaneFactory()
        {
            button6.Parent = this;
            button6.Location = new Point(0, 0);
            button6.BackColor = SystemColors.MenuHighlight;
        }
        
        private void peoplePanel_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(peopleCount.Text) < 1)
            {
                NotificationManager.getInstance().addNotification("Nie ma już pasażerów na lotnisku", NotificationType.Negative);
                return;
            }

            if (!operationModeOn)
            {
                if (AirportManager.getInstance().addSinglePerson())
                    peopleCount.Text = (Int32.Parse(peopleCount.Text) - 1).ToString();
            }
            else
                AirportManager.getInstance().loadPeopleOperation();
        }
        private void cargoPanel_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(cargoCount.Text) < 1)
            {
                NotificationManager.getInstance().addNotification("Nie ma już towaru w magazynie", NotificationType.Negative);
                return;
            }

            if (!operationModeOn)
            {
                if (AirportManager.getInstance().addSingleCargo())
                    cargoCount.Text = (Int32.Parse(cargoCount.Text) - 1).ToString();
            }
            else
                AirportManager.getInstance().loadCargoOperation();
        }
        private void ammoPanel_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(ammoCount.Text) < 1)
            {
                NotificationManager.getInstance().addNotification("Nie ma już amunicji w magazynie", NotificationType.Negative);
                return;
            }

            if (!operationModeOn)
            {
                if (AirportManager.getInstance().addSingleAmmo())
                    ammoCount.Text = (Int32.Parse(ammoCount.Text) - 1).ToString();
            }
            else
                AirportManager.getInstance().loadAmmoOperation();
        }
        
        private void btnUnload_Click(object sender, EventArgs e)
        {
            Plane selectedPlane = (Plane)AirportManager.getInstance().getSelectedPlane();

            if(selectedPlane is PassengerPlane)
            {
                AirportManager.getInstance().unloadPeopleOperation();
            }
            else if(selectedPlane is MilitaryPlane)
            {
                AirportManager.getInstance().unloadAmmoOperation();
            }
            else if(selectedPlane is TransportPlane)
            {
                AirportManager.getInstance().unloadCargoOperation();
            }
        }
        
        private void switchAcceptingIncomingPlanes_click(object sender, EventArgs e)
        {
            if (AirportManager.getInstance().isAcceptingIncommingPlanes())
            {
                AirportManager.getInstance().setAcceptingIncomingPlanes(false);
                switchAcceptingIncomingPlanes.BackColor = Color.FromArgb(252, 113, 113);
            }
            else
            {
                AirportManager.getInstance().setAcceptingIncomingPlanes(true);
                switchAcceptingIncomingPlanes.BackColor = Color.FromArgb(162, 252, 140);
            }
        }

        private void notificationListClear_Click(object sender, EventArgs e)
        {
            NotificationManager.getInstance().clear();
        }

        private void switchOperationSingle_Click(object sender, EventArgs e)
        {
            if (operationModeOn)
            {
                operationModeOn = false;
                switchOperationSingle.Text = "Pojedyńczo";
                switchOperationSingle.BackColor = Color.Bisque;

            }
            else
            {
                operationModeOn = true;
                switchOperationSingle.Text = "Operacja";
                switchOperationSingle.BackColor = Color.Aquamarine;
            }
                
        }

        private void switchAssistant_click(object sender, EventArgs e)
        {
            if (AirportManager.getInstance().isAssistantOn())
            {
                AirportManager.getInstance().setAsistant(false);
                switchAssistant.BackColor = Color.FromArgb(252, 113, 113);
            }
            else
            {
                AirportManager.getInstance().setAsistant(true);
                switchAssistant.BackColor = Color.FromArgb(162, 252, 140);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AirportManager.getInstance().delete();
        }
    }
}
