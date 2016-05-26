using SymulatorLotniska.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SymulatorLotniska.AirportManagement
{
    class PlaneCreationManager : Panel
    {
        private static PlaneCreationManager instance;

        public static void init(AppWindow handleAppWindow)
        {
            instance = new PlaneCreationManager(handleAppWindow);
        }

        public static PlaneCreationManager getInstance()
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
        
        private AppWindow handleAppWindow;

        private PictureBox[] images;
        
        enum PlaneType { Passenger, Military, Transport }

        private PlaneCreationManager(AppWindow handleAppWindow)
        {
            this.handleAppWindow = handleAppWindow;
            Parent = handleAppWindow;
            Visible = false;

            images = new PictureBox[6];

            chosenImageMark = new PictureBox();

            chosenImageMark.Image = (Image)Properties.Resources.ResourceManager.GetObject(Constants.adresZnacznik);
            chosenImageMark.BackColor = Color.Transparent;
            chosenImageMark.Location = new Point(0, 0);
            chosenImageMark.Size = new Size(Constants.imageSize, Constants.imageSize);
            
            rbPassenger = new RadioButton();
            rbTransport = new RadioButton();
            rbMilitary = new RadioButton();
            imageChoosePanel = new Panel();
            parameterChoosePanel = new Panel();
            buttonCreateInHangar = new Button();
            chosenImage = new PictureBox();
            panel2 = new Panel();
            panel1 = new Panel();
            labelModel = new Label();
            label1 = new Label();
            textBoxModel = new TextBox();
            textBoxFuelUsage = new TextBox();
            textBoxMaxFuelLevel = new TextBox();
            textBoxTakeoffInterval = new TextBox();
            textBoxSpecific = new TextBox();
            labelFuelUsage = new Label();
            labelTakeoffInterval = new Label();
            labelMaxFuelLevel = new Label();
            labelSpecific = new Label();
            textBoxWeaponType = new TextBox();
            labelWeaponType = new Label();
            cancelButton = new Button();

            BackColor = System.Drawing.SystemColors.ControlLightLight;
            Controls.Add(cancelButton);
            Controls.Add(panel2);
            Controls.Add(buttonCreateInHangar);
            Controls.Add(parameterChoosePanel);
            Controls.Add(imageChoosePanel);
            Controls.Add(rbMilitary);
            Controls.Add(rbTransport);
            Controls.Add(rbPassenger);
            Controls.Add(panel1);
            Location = new System.Drawing.Point(0, 0);
            Name = "mainPlaneFactoryPanel";
            Size = new System.Drawing.Size(Parent.Size.Width, 230);
            //TabIndex = 8;

            //
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            panel1.Controls.Add(label1);
            panel1.Location = new System.Drawing.Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(230, 27);
            panel1.Visible = false;
            //panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(200, 18);
            label1.TabIndex = 0;
            label1.Text = "Tworzenie nowego samolotu";
            // 
            // rbPassenger
            // 
            rbPassenger.AutoSize = true;
            rbPassenger.Location = new System.Drawing.Point(7, 41);
            rbPassenger.Name = "rbPassenger";
            rbPassenger.Size = new System.Drawing.Size(116, 17);
            rbPassenger.TabIndex = 1;
            rbPassenger.TabStop = true;
            rbPassenger.Text = "Samolot pasażerski";
            rbPassenger.UseVisualStyleBackColor = true;
            rbPassenger.CheckedChanged += new System.EventHandler(rbPassenger_CheckedChanged);
            // 
            // rbTransport
            // 
            rbTransport.AutoSize = true;
            rbTransport.Location = new System.Drawing.Point(7, 64);
            rbTransport.Name = "rbTransport";
            rbTransport.Size = new System.Drawing.Size(126, 17);
            rbTransport.TabIndex = 2;
            rbTransport.TabStop = true;
            rbTransport.Text = "Samolot transportowy";
            rbTransport.UseVisualStyleBackColor = true;
            rbTransport.CheckedChanged += new System.EventHandler(rbTransport_CheckedChanged);
            // 
            // rbMilitary
            // 
            rbMilitary.AutoSize = true;
            rbMilitary.Location = new System.Drawing.Point(7, 87);
            rbMilitary.Name = "rbMilitary";
            rbMilitary.Size = new System.Drawing.Size(112, 17);
            rbMilitary.TabIndex = 3;
            rbMilitary.TabStop = true;
            rbMilitary.Text = "Samolot wojskowy";
            rbMilitary.UseVisualStyleBackColor = true;
            rbMilitary.CheckedChanged += new System.EventHandler(rbMilitary_CheckedChanged);
            // 
            // imageChoosePanel
            // 
            imageChoosePanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            imageChoosePanel.Location = new System.Drawing.Point(169, 33);
            imageChoosePanel.Name = "imageChoosePanel";
            imageChoosePanel.Size = new System.Drawing.Size(170, 115);
            imageChoosePanel.TabIndex = 4;
            // 
            // parameterChoosePanel
            // 
            parameterChoosePanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            parameterChoosePanel.Controls.Add(labelWeaponType);
            parameterChoosePanel.Controls.Add(textBoxWeaponType);
            parameterChoosePanel.Controls.Add(labelSpecific);
            parameterChoosePanel.Controls.Add(labelMaxFuelLevel);
            parameterChoosePanel.Controls.Add(labelTakeoffInterval);
            parameterChoosePanel.Controls.Add(labelFuelUsage);
            parameterChoosePanel.Controls.Add(textBoxSpecific);
            parameterChoosePanel.Controls.Add(textBoxTakeoffInterval);
            parameterChoosePanel.Controls.Add(textBoxMaxFuelLevel);
            parameterChoosePanel.Controls.Add(textBoxFuelUsage);
            parameterChoosePanel.Controls.Add(textBoxModel);
            parameterChoosePanel.Controls.Add(labelModel);
            parameterChoosePanel.Location = new System.Drawing.Point(359, 6);
            parameterChoosePanel.Name = "parameterChoosePanel";
            parameterChoosePanel.Size = new System.Drawing.Size(255, 180);
            parameterChoosePanel.TabIndex = 5;
            // 
            // buttonCreateInHangar
            // 
            buttonCreateInHangar.Image = (Image)Properties.Resources.btnTick;
            buttonCreateInHangar.BackColor = System.Drawing.Color.White;
            buttonCreateInHangar.Location = new System.Drawing.Point(200, 150);
            buttonCreateInHangar.Name = "buttonCreateInHangar";
            buttonCreateInHangar.Size = new System.Drawing.Size(50, 50);
            buttonCreateInHangar.TabIndex = 6;
            buttonCreateInHangar.UseVisualStyleBackColor = false;
            buttonCreateInHangar.Click += new System.EventHandler(buttonCreateInHangar_Click);

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
            chosenImage.BackColor = System.Drawing.SystemColors.Desktop;
            chosenImage.Location = new System.Drawing.Point(5, 5);
            chosenImage.Name = "chosenImage";
            chosenImage.Size = new System.Drawing.Size(50, 50);
            chosenImage.TabIndex = 7;
            chosenImage.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            panel2.Controls.Add(chosenImage);
            panel2.Location = new System.Drawing.Point(37, 124);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(60, 60);
            panel2.TabIndex = 8;
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelModel.Location = new System.Drawing.Point(63, 6);
            labelModel.Name = "labelModel";
            labelModel.Size = new System.Drawing.Size(42, 15);
            labelModel.TabIndex = 0;
            labelModel.Text = "Model";
            // 
            // textBoxModel
            // 
            textBoxModel.Location = new System.Drawing.Point(117, 5);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.Size = new System.Drawing.Size(100, 20);
            textBoxModel.TabIndex = 1;
            // 
            // textBoxFuelUsage
            // 
            textBoxFuelUsage.Location = new System.Drawing.Point(117, 30);
            textBoxFuelUsage.Name = "textBoxFuelUsage";
            textBoxFuelUsage.Size = new System.Drawing.Size(100, 20);
            textBoxFuelUsage.TabIndex = 2;
            // 
            // textBoxMaxFuelLevel
            // 
            textBoxMaxFuelLevel.Location = new System.Drawing.Point(117, 55);
            textBoxMaxFuelLevel.Name = "textBoxMaxFuelLevel";
            textBoxMaxFuelLevel.Size = new System.Drawing.Size(100, 20);
            textBoxMaxFuelLevel.TabIndex = 3;
            // 
            // textBoxTakeoffInterval
            // 
            textBoxTakeoffInterval.Location = new System.Drawing.Point(117, 81);
            textBoxTakeoffInterval.Name = "textBoxTakeoffInterval";
            textBoxTakeoffInterval.Size = new System.Drawing.Size(100, 20);
            textBoxTakeoffInterval.TabIndex = 4;
            // 
            // textBoxSpecific
            // 
            textBoxSpecific.Location = new System.Drawing.Point(69, 157);
            textBoxSpecific.Name = "textBoxSpecific";
            textBoxSpecific.Size = new System.Drawing.Size(100, 20);
            textBoxSpecific.TabIndex = 5;
            // 
            // labelFuelUsage
            // 
            labelFuelUsage.AutoSize = true;
            labelFuelUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelFuelUsage.Location = new System.Drawing.Point(49, 31);
            labelFuelUsage.Name = "labelFuelUsage";
            labelFuelUsage.Size = new System.Drawing.Size(56, 15);
            labelFuelUsage.TabIndex = 6;
            labelFuelUsage.Text = "Spalanie";
            // 
            // labelTakeoffInterval
            // 
            labelTakeoffInterval.AutoSize = true;
            labelTakeoffInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelTakeoffInterval.Location = new System.Drawing.Point(38, 82);
            labelTakeoffInterval.Name = "labelTakeoffInterval";
            labelTakeoffInterval.Size = new System.Drawing.Size(67, 15);
            labelTakeoffInterval.TabIndex = 7;
            labelTakeoffInterval.Text = "Czas startu";
            // 
            // labelMaxFuelLevel
            // 
            labelMaxFuelLevel.AutoSize = true;
            labelMaxFuelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelMaxFuelLevel.Location = new System.Drawing.Point(6, 56);
            labelMaxFuelLevel.Name = "labelMaxFuelLevel";
            labelMaxFuelLevel.Size = new System.Drawing.Size(99, 15);
            labelMaxFuelLevel.TabIndex = 8;
            labelMaxFuelLevel.Text = "Pojemnosc baku";
            // 
            // labelSpecific
            // 
            labelSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelSpecific.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelSpecific.Location = new System.Drawing.Point(30, 139);
            labelSpecific.Name = "labelSpecific";
            labelSpecific.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelSpecific.Size = new System.Drawing.Size(177, 15);
            labelSpecific.TabIndex = 9;
            labelSpecific.Text = "Maksymalna ilość pasażerow";
            labelSpecific.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxWeaponType
            // 
            textBoxWeaponType.Location = new System.Drawing.Point(117, 107);
            textBoxWeaponType.Name = "textBoxWeaponType";
            textBoxWeaponType.Size = new System.Drawing.Size(100, 20);
            textBoxWeaponType.TabIndex = 10;
            // 
            // labelWeaponType
            // 
            labelWeaponType.AutoSize = true;
            labelWeaponType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelWeaponType.Location = new System.Drawing.Point(32, 108);
            labelWeaponType.Name = "labelWeaponType";
            labelWeaponType.Size = new System.Drawing.Size(73, 15);
            labelWeaponType.TabIndex = 11;
            labelWeaponType.Text = "Model broni";
            // 
            // cancelButton
            // 
            cancelButton.Image = (Image)Properties.Resources.buttonZatrzymanie;
            cancelButton.BackColor = System.Drawing.Color.White;
            cancelButton.Location = new System.Drawing.Point(260, 150);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(50, 50);
            cancelButton.TabIndex = 10;
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += new System.EventHandler(cancelButton_Click);

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
                    return PlaneImagesCollection.passengerPlaneNames[i];
                case PlaneType.Military:
                    return PlaneImagesCollection.militaryPlaneNames[i];
                case PlaneType.Transport:
                    return PlaneImagesCollection.transportPlaneNames[i];
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
                for(int i=0; i<PlaneImagesCollection.passengerPlaneNames.Count; i++)
                {
                    images[i].Image = (Image)Properties.Resources.ResourceManager.GetObject(PlaneImagesCollection.passengerPlaneNames[i]);
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
                for (int i = 0; i < PlaneImagesCollection.transportPlaneNames.Count; i++)
                {
                    images[i].Image = (Image)Properties.Resources.ResourceManager.GetObject(PlaneImagesCollection.transportPlaneNames[i]);
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
                factoriedPlane = new PassengerPlane();
                ((PassengerPlane)factoriedPlane).setMaxNumberOfPassengers(Int32.Parse(textBoxSpecific.Text));
            }
            else if (currentFactoring == PlaneType.Transport)
            {
                factoriedPlane = new TransportPlane();
                ((TransportPlane)factoriedPlane).setMaxStorageCapacity(Int32.Parse(textBoxSpecific.Text));
            }
            else
            {
                factoriedPlane = new MilitaryPlane();
                ((MilitaryPlane)factoriedPlane).setWeaponType(textBoxWeaponType.Text);
                ((MilitaryPlane)factoriedPlane).setMaxAmmo(Int32.Parse(textBoxSpecific.Text));
            }

            factoriedPlane.setPlaneImage(chosenImageName);
            factoriedPlane.setModel(textBoxModel.Text);
            factoriedPlane.setFuelUsage(Int32.Parse(textBoxFuelUsage.Text));
            factoriedPlane.setMaxFuelLevel(Int32.Parse(textBoxMaxFuelLevel.Text));
            factoriedPlane.setTakeoffTime(Int32.Parse(textBoxTakeoffInterval.Text));
            factoriedPlane.setAfterTechnicalInspection(false);
            
            AirportManager.getInstance().getHangar().addToHangar(factoriedPlane);
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
