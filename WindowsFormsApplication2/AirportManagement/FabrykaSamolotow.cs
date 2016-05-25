using SymulatorLotniska.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SymulatorLotniska.AirportManagement
{// moze singleton?
    class FabrykaSamolotow : Panel
    {
        private static FabrykaSamolotow instance;

        public static void init(AppWindow handleAppWindow, AirportManager handleAirportManager)
        {
            instance = new FabrykaSamolotow(handleAppWindow, handleAirportManager);
        }

        public static FabrykaSamolotow getInstance()
        {
            return instance;
        }

        private PlaneType currentFactoring = PlaneType.Passenger;

        private RadioButton rbMilitary;
        private RadioButton rbTransport;
        private RadioButton rbPassenger;

        private Panel parameterChoosePanel;
        private Panel imageChoosePanel;
        private Panel panel2;
        private Panel panel1;

        private TextBox textBoxSpecific;
        private TextBox textBoxTakeoffInterval;
        private TextBox textBoxMaxFuelLevel;
        private TextBox textBoxFuelUsage;
        private TextBox textBoxModel;
        private TextBox textBoxWeaponType;

        private Label label1;
        private Label labelModel;
        private Label labelTakeoffInterval;
        private Label labelFuelUsage;
        private Label labelMaxFuelLevel;
        private Label labelSpecific;
        private Label labelWeaponType;

        private Button buttonCreateInHangar;
        private Button cancelButton;

        private PictureBox chosenImageHandle;
        private PictureBox chosenImageMark;
        private PictureBox chosenImage;
        private string chosenImageName;

        private AirportManager handleAirportManager;
        private AppWindow handleAppWindow;

        private PictureBox[] images;
        
        enum PlaneType { Passenger, Military, Transport }

        private FabrykaSamolotow(AppWindow handleAppWindow,AirportManager handleAirportManager)
        {
            this.handleAppWindow = handleAppWindow;
            Parent = handleAppWindow;
            Visible = false;
            this.handleAirportManager = handleAirportManager;

            images = new PictureBox[6];

            chosenImageMark = new PictureBox();

            chosenImageMark.Image = (Image)Properties.Resources.ResourceManager.GetObject(ConfigurationConstants.adresZnacznik);
            chosenImageMark.BackColor = Color.Transparent;
            chosenImageMark.Location = new Point(0, 0);
            chosenImageMark.Enabled = false;
            chosenImageMark.Visible = false;
            chosenImageMark.Size = new Size(ConfigurationConstants.imageSize, ConfigurationConstants.imageSize);


            rbPassenger = new RadioButton();
            rbTransport = new RadioButton();
            rbMilitary = new RadioButton();

            imageChoosePanel = new Panel();
            parameterChoosePanel = new Panel();

            buttonCreateInHangar = new System.Windows.Forms.Button();
            this.chosenImage = new PictureBox();

            this.panel2 = new Panel();
            this.panel1 = new Panel();
            this.labelModel = new Label();
            this.label1 = new Label();
            this.textBoxModel = new TextBox();
            this.textBoxFuelUsage = new TextBox();
            this.textBoxMaxFuelLevel = new TextBox();
            this.textBoxTakeoffInterval = new TextBox();
            this.textBoxSpecific = new TextBox();
            this.labelFuelUsage = new Label();
            this.labelTakeoffInterval = new Label();
            this.labelMaxFuelLevel = new Label();
            this.labelSpecific = new Label();
            this.textBoxWeaponType = new TextBox();
            this.labelWeaponType = new Label();
            this.cancelButton = new Button();

            BackColor = System.Drawing.SystemColors.ControlLightLight;
            Controls.Add(this.cancelButton);
            Controls.Add(this.panel2);
            Controls.Add(this.buttonCreateInHangar);
            Controls.Add(this.parameterChoosePanel);
            Controls.Add(this.imageChoosePanel);
            Controls.Add(this.rbMilitary);
            Controls.Add(this.rbTransport);
            Controls.Add(this.rbPassenger);
            Controls.Add(this.panel1);
            //Location = new System.Drawing.Point(10, 12);
            // Location = new System.Drawing.Point(10, 0);
            Location = new System.Drawing.Point(0, 0);
            Name = "mainPlaneFactoryPanel";
            // Size = new System.Drawing.Size(682, 230);
            Size = new System.Drawing.Size(Parent.Size.Width, 230);
            TabIndex = 8;

           //
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 27);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tworzenie nowego samolotu";
            // 
            // rbPassenger
            // 
            this.rbPassenger.AutoSize = true;
            this.rbPassenger.Location = new System.Drawing.Point(7, 41);
            this.rbPassenger.Name = "rbPassenger";
            this.rbPassenger.Size = new System.Drawing.Size(116, 17);
            this.rbPassenger.TabIndex = 1;
            this.rbPassenger.TabStop = true;
            this.rbPassenger.Text = "Samolot pasażerski";
            this.rbPassenger.UseVisualStyleBackColor = true;
            this.rbPassenger.CheckedChanged += new System.EventHandler(this.rbPassenger_CheckedChanged);
            // 
            // rbTransport
            // 
            this.rbTransport.AutoSize = true;
            this.rbTransport.Location = new System.Drawing.Point(7, 64);
            this.rbTransport.Name = "rbTransport";
            this.rbTransport.Size = new System.Drawing.Size(126, 17);
            this.rbTransport.TabIndex = 2;
            this.rbTransport.TabStop = true;
            this.rbTransport.Text = "Samolot transportowy";
            this.rbTransport.UseVisualStyleBackColor = true;
            this.rbTransport.CheckedChanged += new System.EventHandler(this.rbTransport_CheckedChanged);
            // 
            // rbMilitary
            // 
            this.rbMilitary.AutoSize = true;
            this.rbMilitary.Location = new System.Drawing.Point(7, 87);
            this.rbMilitary.Name = "rbMilitary";
            this.rbMilitary.Size = new System.Drawing.Size(112, 17);
            this.rbMilitary.TabIndex = 3;
            this.rbMilitary.TabStop = true;
            this.rbMilitary.Text = "Samolot wojskowy";
            this.rbMilitary.UseVisualStyleBackColor = true;
            this.rbMilitary.CheckedChanged += new System.EventHandler(this.rbMilitary_CheckedChanged);
            // 
            // imageChoosePanel
            // 
            this.imageChoosePanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.imageChoosePanel.Location = new System.Drawing.Point(169, 33);
            this.imageChoosePanel.Name = "imageChoosePanel";
            this.imageChoosePanel.Size = new System.Drawing.Size(170, 115);
            this.imageChoosePanel.TabIndex = 4;
            // 
            // parameterChoosePanel
            // 
            this.parameterChoosePanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.parameterChoosePanel.Controls.Add(this.labelWeaponType);
            this.parameterChoosePanel.Controls.Add(this.textBoxWeaponType);
            this.parameterChoosePanel.Controls.Add(this.labelSpecific);
            this.parameterChoosePanel.Controls.Add(this.labelMaxFuelLevel);
            this.parameterChoosePanel.Controls.Add(this.labelTakeoffInterval);
            this.parameterChoosePanel.Controls.Add(this.labelFuelUsage);
            this.parameterChoosePanel.Controls.Add(this.textBoxSpecific);
            this.parameterChoosePanel.Controls.Add(this.textBoxTakeoffInterval);
            this.parameterChoosePanel.Controls.Add(this.textBoxMaxFuelLevel);
            this.parameterChoosePanel.Controls.Add(this.textBoxFuelUsage);
            this.parameterChoosePanel.Controls.Add(this.textBoxModel);
            this.parameterChoosePanel.Controls.Add(this.labelModel);
            this.parameterChoosePanel.Location = new System.Drawing.Point(359, 6);
            this.parameterChoosePanel.Name = "parameterChoosePanel";
            this.parameterChoosePanel.Size = new System.Drawing.Size(255, 180);
            this.parameterChoosePanel.TabIndex = 5;
            // 
            // buttonCreateInHangar
            // 
            buttonCreateInHangar.Image = (Image)Properties.Resources.btnTick;
            this.buttonCreateInHangar.BackColor = System.Drawing.Color.White;
            this.buttonCreateInHangar.Location = new System.Drawing.Point(200, 150);
            this.buttonCreateInHangar.Name = "buttonCreateInHangar";
            this.buttonCreateInHangar.Size = new System.Drawing.Size(50, 50);
            this.buttonCreateInHangar.TabIndex = 6;
            this.buttonCreateInHangar.UseVisualStyleBackColor = false;
            this.buttonCreateInHangar.Click += new System.EventHandler(this.buttonCreateInHangar_Click);

            // 
            // pictureBox1
            // 
            

            for (int i = 0; i < 6; i++)
            {
                images[i] = new PictureBox();
                images[i].BackColor = System.Drawing.Color.Transparent;
                images[i].Size = new System.Drawing.Size(50, 50);
                images[i].Visible = false;
                images[i].Click += image_onClick;
                images[i].Parent = imageChoosePanel;
            }
            
            images[0].Location = new System.Drawing.Point(3, 3);
            images[1].Location = new System.Drawing.Point(59, 3);
            images[2].Location = new System.Drawing.Point(115, 3);
            images[3].Location = new System.Drawing.Point(3, 59);
            images[4].Location = new System.Drawing.Point(59, 59);
            images[5].Location = new System.Drawing.Point(115, 59);

            // 
            // chosenImage
            // 
            this.chosenImage.BackColor = System.Drawing.SystemColors.Desktop;
            this.chosenImage.Location = new System.Drawing.Point(5, 5);
            this.chosenImage.Name = "chosenImage";
            this.chosenImage.Size = new System.Drawing.Size(50, 50);
            this.chosenImage.TabIndex = 7;
            this.chosenImage.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.chosenImage);
            this.panel2.Location = new System.Drawing.Point(37, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 60);
            this.panel2.TabIndex = 8;
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelModel.Location = new System.Drawing.Point(63, 6);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(42, 15);
            this.labelModel.TabIndex = 0;
            this.labelModel.Text = "Model";
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(117, 5);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(100, 20);
            this.textBoxModel.TabIndex = 1;
            // 
            // textBoxFuelUsage
            // 
            this.textBoxFuelUsage.Location = new System.Drawing.Point(117, 30);
            this.textBoxFuelUsage.Name = "textBoxFuelUsage";
            this.textBoxFuelUsage.Size = new System.Drawing.Size(100, 20);
            this.textBoxFuelUsage.TabIndex = 2;
            // 
            // textBoxMaxFuelLevel
            // 
            this.textBoxMaxFuelLevel.Location = new System.Drawing.Point(117, 55);
            this.textBoxMaxFuelLevel.Name = "textBoxMaxFuelLevel";
            this.textBoxMaxFuelLevel.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaxFuelLevel.TabIndex = 3;
            // 
            // textBoxTakeoffInterval
            // 
            this.textBoxTakeoffInterval.Location = new System.Drawing.Point(117, 81);
            this.textBoxTakeoffInterval.Name = "textBoxTakeoffInterval";
            this.textBoxTakeoffInterval.Size = new System.Drawing.Size(100, 20);
            this.textBoxTakeoffInterval.TabIndex = 4;
            // 
            // textBoxSpecific
            // 
            this.textBoxSpecific.Location = new System.Drawing.Point(69, 157);
            this.textBoxSpecific.Name = "textBoxSpecific";
            this.textBoxSpecific.Size = new System.Drawing.Size(100, 20);
            this.textBoxSpecific.TabIndex = 5;
            // 
            // labelFuelUsage
            // 
            this.labelFuelUsage.AutoSize = true;
            this.labelFuelUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFuelUsage.Location = new System.Drawing.Point(49, 31);
            this.labelFuelUsage.Name = "labelFuelUsage";
            this.labelFuelUsage.Size = new System.Drawing.Size(56, 15);
            this.labelFuelUsage.TabIndex = 6;
            this.labelFuelUsage.Text = "Spalanie";
            // 
            // labelTakeoffInterval
            // 
            this.labelTakeoffInterval.AutoSize = true;
            this.labelTakeoffInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTakeoffInterval.Location = new System.Drawing.Point(38, 82);
            this.labelTakeoffInterval.Name = "labelTakeoffInterval";
            this.labelTakeoffInterval.Size = new System.Drawing.Size(67, 15);
            this.labelTakeoffInterval.TabIndex = 7;
            this.labelTakeoffInterval.Text = "Czas startu";
            // 
            // labelMaxFuelLevel
            // 
            this.labelMaxFuelLevel.AutoSize = true;
            this.labelMaxFuelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMaxFuelLevel.Location = new System.Drawing.Point(6, 56);
            this.labelMaxFuelLevel.Name = "labelMaxFuelLevel";
            this.labelMaxFuelLevel.Size = new System.Drawing.Size(99, 15);
            this.labelMaxFuelLevel.TabIndex = 8;
            this.labelMaxFuelLevel.Text = "Pojemnosc baku";
            // 
            // labelSpecific
            // 
            this.labelSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpecific.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSpecific.Location = new System.Drawing.Point(30, 139);
            this.labelSpecific.Name = "labelSpecific";
            this.labelSpecific.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSpecific.Size = new System.Drawing.Size(177, 15);
            this.labelSpecific.TabIndex = 9;
            this.labelSpecific.Text = "Maksymalna ilość pasażerow";
            this.labelSpecific.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxWeaponType
            // 
            this.textBoxWeaponType.Location = new System.Drawing.Point(117, 107);
            this.textBoxWeaponType.Name = "textBoxWeaponType";
            this.textBoxWeaponType.Size = new System.Drawing.Size(100, 20);
            this.textBoxWeaponType.TabIndex = 10;
            // 
            // labelWeaponType
            // 
            this.labelWeaponType.AutoSize = true;
            this.labelWeaponType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWeaponType.Location = new System.Drawing.Point(32, 108);
            this.labelWeaponType.Name = "labelWeaponType";
            this.labelWeaponType.Size = new System.Drawing.Size(73, 15);
            this.labelWeaponType.TabIndex = 11;
            this.labelWeaponType.Text = "Model broni";
            // 
            // cancelButton
            // 
            cancelButton.Image = (Image)Properties.Resources.buttonZatrzymanie;
            this.cancelButton.BackColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(260, 150);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(50, 50);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            labelModel.Visible = true;
            textBoxModel.Visible = true;

            labelFuelUsage.Visible = true;
            textBoxFuelUsage.Visible = true;

            labelMaxFuelLevel.Visible = true;
            textBoxMaxFuelLevel.Visible = true;

            labelTakeoffInterval.Visible = true;
            textBoxTakeoffInterval.Visible = true;

            rbPassenger.Checked = true;

        }

        private void image_onClick(object sender, EventArgs e)
        {
            for(int i = 0; i < 6; i++)
            {
                if(images[i] == sender)
                {
                    chosenImageName = getCurrentImageName(i);
                    chosenImage.Image = (Image)Properties.Resources.ResourceManager.GetObject(chosenImageName);
                    chosenImage.Visible = true;

                    chosenImageHandle = images[i];
                    updateImages();

                    return;
                }
            }
        }

        private string getCurrentImageName(int i)
        {
            switch(currentFactoring)
            {
                case PlaneType.Passenger:
                    return ImageColections.passengerPlaneNames[i];
                case PlaneType.Military:
                    return ImageColections.militaryPlaneNames[i];
                case PlaneType.Transport:
                    return ImageColections.transportPlaneNames[i];
                default:
                    return "error";
            }
        }
        

        public void showFactoryPanel()
        {
            Visible = true;
            Enabled = true;
            BringToFront();
        }

        public void hideFactoryPanel()
        {
            Visible = false;
            Enabled = false;
        }

        public void resetControls()
        {
            textBoxModel.ResetText();
            textBoxFuelUsage.ResetText();
            textBoxMaxFuelLevel.ResetText();
            textBoxTakeoffInterval.ResetText();
            textBoxWeaponType.ResetText();
            textBoxSpecific.ResetText();

            chosenImageHandle = null;
            chosenImage.Visible = false;
            chosenImageMark.Parent = null;
            chosenImageName = null;
        }

        public void updateImages()
        {
            for(int i=0; i<6;i++)
            {
                images[i].Visible = false;
            }

            if(currentFactoring == PlaneType.Passenger)
            {
                for(int i=0; i<ImageColections.passengerPlaneNames.Count; i++)
                {
                    images[i].Image = (Image)Properties.Resources.ResourceManager.GetObject(ImageColections.passengerPlaneNames[i]);
                    images[i].Visible = true;
                    images[i].Enabled = true;

                    if (images[i] == chosenImageHandle)
                    {
                        chosenImageMark.Parent = images[i];
                        chosenImageMark.Visible = true;
                    }

                }
                return;
            }
            if(currentFactoring == PlaneType.Transport)
            {
                for (int i = 0; i < ImageColections.transportPlaneNames.Count; i++)
                {
                    images[i].Image = (Image)Properties.Resources.ResourceManager.GetObject(ImageColections.transportPlaneNames[i]);
                    images[i].Visible = true;
                    images[i].Enabled = true;

                    if (images[i] == chosenImageHandle)
                    {
                        chosenImageMark.Parent = images[i];
                        chosenImageMark.Visible = true;
                    }

                }
                return;
            }
        }

        public void updateControls()
        {
            resetControls();

            switch (currentFactoring)
            {
                case PlaneType.Passenger:

                    labelSpecific.Text = "Maksymalna ilość pasażerow";
                    labelSpecific.Visible = true;
                    textBoxSpecific.Visible = true;

                    labelWeaponType.Visible = false;
                    textBoxWeaponType.Visible = false;

                    break;
                case PlaneType.Transport:
                    labelSpecific.Text = "Maksymalna ładowność (kg)";
                    labelSpecific.Visible = true;
                    textBoxSpecific.Visible = true;

                    labelWeaponType.Visible = false;
                    textBoxWeaponType.Visible = false;

                    break;
                case PlaneType.Military:

                    labelSpecific.Text = "Maksymalna ilość amunicji";
                    labelSpecific.Visible = true;
                    textBoxSpecific.Visible = true;

                    labelWeaponType.Visible = true;
                    textBoxWeaponType.Visible = true;

                    break;


            }
            
        }


        private void rbPassenger_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPassenger.Checked == true)
            {
                currentFactoring = PlaneType.Passenger;
                updateControls();
                updateImages();
            }
        }

        private void rbTransport_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTransport.Checked == true)
            {
                currentFactoring = PlaneType.Transport;
                updateControls();
                updateImages();
            }
        }

        private void rbMilitary_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMilitary.Checked == true)
            {
                currentFactoring = PlaneType.Military;
                updateControls();
                updateImages();
            }
        }

        private bool validateData()
        {
            if (chosenImageName == null)
            {
                MessageBox.Show("Wybierz miniaturę");
                return false;
            }
            if (textBoxModel.Text == "")
            {
                MessageBox.Show("Podaj model samolotu");
                return false;
            }
            if (textBoxFuelUsage.Text == "")
            {
                MessageBox.Show("Określ spalanie samolotu");
                return false;
            }
            if (textBoxMaxFuelLevel.Text == "")
            {
                MessageBox.Show("Określ pojemność baku samolotu");
                return false;
            }
            if (textBoxTakeoffInterval.Text == "")
            {
                MessageBox.Show("Określ czas startu samolotu");
                return false;
            }
            if(!textBoxFuelUsage.Text.All(char.IsDigit))
            {
                MessageBox.Show("Spalanie samolotu musi być liczbą całkowitą");
                return false;
            }
            if (!textBoxMaxFuelLevel.Text.All(char.IsDigit))
            {
                MessageBox.Show("Pojemność baku samolotu musi być liczbą całkowitą");
                return false;
            }
            if (!textBoxTakeoffInterval.Text.All(char.IsDigit))
            {
                MessageBox.Show("Czas startu samolotu musi być liczbą całkowitą");
                return false;
            }

            if(currentFactoring == PlaneType.Passenger)
            {
                if (textBoxSpecific.Text == "")
                {
                    MessageBox.Show("Określ maksymalna ilość pasażerów");
                    return false;
                }
                if (!textBoxSpecific.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Maksymalna ilość pasażerów musi być liczbą całkowitą");
                    return false;
                }
            }
            else if(currentFactoring == PlaneType.Transport)
            {
                if (textBoxSpecific.Text == "")
                {
                    MessageBox.Show("Określ maksymalna pojemność samolotu");
                    return false;
                }
                if (!textBoxSpecific.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Maksymalna pojemność samolotu musi być liczbą całkowitą");
                    return false;
                }
            }
            else if(currentFactoring == PlaneType.Military)
            {
               
                if (textBoxWeaponType.Text == "")
                {
                    MessageBox.Show("Określ typ broni");
                    return false;
                }

                if (textBoxSpecific.Text == "")
                {
                    MessageBox.Show("Określ maksymalną ilość amunicji");
                    return false;
                }
                if (!textBoxSpecific.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Maksymalna ilość amunicji musi być liczbą całkowitą");
                    return false;
                }
            }

            return true;
        }

        private void buttonCreateInHangar_Click(object sender, EventArgs e)
        {
            if (!validateData()) return;

            Plane factoriedPlane;

            if (currentFactoring == PlaneType.Passenger)
            {
                factoriedPlane = new PassengerPlane(handleAirportManager);
                ((PassengerPlane)factoriedPlane).setMaxNumberOfPassengers(Int32.Parse(textBoxSpecific.Text));
            }
            else if (currentFactoring == PlaneType.Transport)
            {
                factoriedPlane = new TransportPlane(handleAirportManager);
                ((TransportPlane)factoriedPlane).setMaxStorageCapacity(Int32.Parse(textBoxSpecific.Text));
            }
            else
            {
                factoriedPlane = new MilitaryPlane(handleAirportManager);
                ((MilitaryPlane)factoriedPlane).setWeaponType(textBoxWeaponType.Text);
                ((MilitaryPlane)factoriedPlane).setMaxAmmo(Int32.Parse(textBoxSpecific.Text));
            }

            factoriedPlane.setPlaneImage(chosenImageName);
            factoriedPlane.setModel(textBoxModel.Text);
            factoriedPlane.setFuelUsage(Int32.Parse(textBoxFuelUsage.Text));
            factoriedPlane.setMaxFuelLevel(Int32.Parse(textBoxMaxFuelLevel.Text));
            factoriedPlane.setTakeoffTime(Int32.Parse(textBoxTakeoffInterval.Text));
            factoriedPlane.setAfterTechnicalInspection(false);
            
            handleAirportManager.getHangar().addToHangar(factoriedPlane);
            hideFactoryPanel();
            resetControls();
            handleAppWindow.planeFactoryButtonToTop();

        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            resetControls();
        }
        
    }
}
