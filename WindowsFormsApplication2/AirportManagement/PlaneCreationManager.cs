using SymulatorLotniska.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SymulatorLotniska;

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
        private Panel panel1;

        private TextBox textBoxSpecific;
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


        private ComboBox comboBox1;

        private Button buttonCreate;
        private Button cancelButton;

        private PictureBox chosenImageHandle;
        private PictureBox chosenImageMark;
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

            chosenImageMark.Image = (Image)Properties.Resources.ResourceManager.GetObject(PlaneImagesCollection.adressSelectedMark);
            chosenImageMark.BackColor = Color.Transparent;
            chosenImageMark.Location = new Point(0, 0);
            chosenImageMark.Size = new Size(Constants.planeImageSizeX, Constants.planeImageSizeY);
            
            rbPassenger = new RadioButton();
            rbTransport = new RadioButton();
            rbMilitary = new RadioButton();
            imageChoosePanel = new Panel();
            parameterChoosePanel = new Panel();
            buttonCreate = new Button();
            panel1 = new Panel();
            labelModel = new Label();
            label1 = new Label();
            textBoxModel = new TextBox();
            textBoxFuelUsage = new TextBox();
            textBoxMaxFuelLevel = new TextBox();
            textBoxSpecific = new TextBox();
            labelFuelUsage = new Label();
            labelTakeoffInterval = new Label();
            labelMaxFuelLevel = new Label();
            labelSpecific = new Label();
            textBoxWeaponType = new TextBox();
            labelWeaponType = new Label();
            cancelButton = new Button();
            comboBox1 = new ComboBox();

            BackColor = System.Drawing.SystemColors.ControlLightLight;
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
            imageChoosePanel.Location = new System.Drawing.Point(169, 6);
            imageChoosePanel.Name = "imageChoosePanel";
            imageChoosePanel.Size = new System.Drawing.Size(212, 168);
            imageChoosePanel.TabIndex = 4;
            //comboBox1
            comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",});
            comboBox1.Location = new System.Drawing.Point(137, 81);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(100, 20);
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            
            
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
            parameterChoosePanel.Controls.Add(textBoxMaxFuelLevel);
            parameterChoosePanel.Controls.Add(textBoxFuelUsage);
            parameterChoosePanel.Controls.Add(textBoxModel);
            parameterChoosePanel.Controls.Add(labelModel);
            parameterChoosePanel.Controls.Add(buttonCreate);
            parameterChoosePanel.Controls.Add(cancelButton);
            parameterChoosePanel.Controls.Add(comboBox1);
            parameterChoosePanel.Location = new System.Drawing.Point(400, 6);
            parameterChoosePanel.Name = "parameterChoosePanel";
            parameterChoosePanel.Size = new System.Drawing.Size(350, 168);
            parameterChoosePanel.TabIndex = 5;
            // 
            // cancelButton
            // 
            cancelButton.Image = (Image)Properties.Resources.buttonZatrzymanie;
            cancelButton.BackColor = System.Drawing.Color.White;
            cancelButton.Location = new System.Drawing.Point(250, 25+50+3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(50, 50);
            cancelButton.TabIndex = 10;
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += new System.EventHandler(cancelButton_Click);
            // 
            // buttonCreate
            // 
            buttonCreate.Image = (Image)Properties.Resources.btnTick;
            buttonCreate.BackColor = System.Drawing.Color.White;
            buttonCreate.Location = new System.Drawing.Point(250, 25);
            buttonCreate.Name = "buttonCreateInHangar";
            buttonCreate.Size = new System.Drawing.Size(50, 50);
            buttonCreate.TabIndex = 6;
            buttonCreate.UseVisualStyleBackColor = false;
            buttonCreate.Click += new System.EventHandler(buttonCreateInHangar_Click);

            // 
            // pictureBox1
            // 
            

            for (int i = 0; i < 6; i++)
            {
                images[i] = new PictureBox();
                images[i].BackColor = System.Drawing.Color.Transparent;
                images[i].Size = new System.Drawing.Size(100, 50);
                images[i].Visible = false;
                images[i].Click += image_onClick;
                images[i].Parent = imageChoosePanel;
            }
            
            images[0].Location = new System.Drawing.Point(3, 3);
            images[1].Location = new System.Drawing.Point(109, 3);
            images[2].Location = new System.Drawing.Point(3, 59);
            images[3].Location = new System.Drawing.Point(109, 59);
            images[4].Location = new System.Drawing.Point(3, 115);
            images[5].Location = new System.Drawing.Point(109, 115);

            // 3 , 59 , 115         56 - diff   115 + 50 + 3  = 115 + 53 = 168  112 + 100 
            // 3 109 109 + 103

           
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelModel.Location = new System.Drawing.Point(83, 6);
            labelModel.Name = "labelModel";
            labelModel.Size = new System.Drawing.Size(42, 15);
            labelModel.TabIndex = 0;
            labelModel.Text = "Model";
            // 
            // textBoxModel
            // 
            textBoxModel.Location = new System.Drawing.Point(137, 5);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.Size = new System.Drawing.Size(100, 20);
            textBoxModel.TabIndex = 1;
            // 
            // textBoxFuelUsage
            // 
            textBoxFuelUsage.Location = new System.Drawing.Point(137, 30);
            textBoxFuelUsage.Name = "textBoxFuelUsage";
            textBoxFuelUsage.Size = new System.Drawing.Size(100, 20);
            textBoxFuelUsage.TabIndex = 2;
            // 
            // textBoxMaxFuelLevel
            // 
            textBoxMaxFuelLevel.Location = new System.Drawing.Point(137, 55);
            textBoxMaxFuelLevel.Name = "textBoxMaxFuelLevel";
            textBoxMaxFuelLevel.Size = new System.Drawing.Size(100, 20);
            textBoxMaxFuelLevel.TabIndex = 3;
            // 
            // 
            // textBoxSpecific
            // 
            textBoxSpecific.Location = new System.Drawing.Point(137, 107+25);
            textBoxSpecific.Name = "textBoxSpecific";
            textBoxSpecific.Size = new System.Drawing.Size(100, 20);
            textBoxSpecific.TabIndex = 5;
            // 
            // labelFuelUsage
            // 
            labelFuelUsage.AutoSize = true;
            labelFuelUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelFuelUsage.Location = new System.Drawing.Point(69, 31);
            labelFuelUsage.Name = "labelFuelUsage";
            labelFuelUsage.Size = new System.Drawing.Size(56, 15);
            labelFuelUsage.TabIndex = 6;
            labelFuelUsage.Text = "Spalanie";
            // 
            // labelTakeoffInterval
            // 
            labelTakeoffInterval.AutoSize = true;
            labelTakeoffInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelTakeoffInterval.Location = new System.Drawing.Point(58, 82);
            labelTakeoffInterval.Name = "labelTakeoffInterval";
            labelTakeoffInterval.Size = new System.Drawing.Size(67, 15);
            labelTakeoffInterval.TabIndex = 7;
            labelTakeoffInterval.Text = "Czas startu";
            // 
            // labelMaxFuelLevel
            // 
            labelMaxFuelLevel.AutoSize = true;
            labelMaxFuelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelMaxFuelLevel.Location = new System.Drawing.Point(26, 56);
            labelMaxFuelLevel.Name = "labelMaxFuelLevel";
            labelMaxFuelLevel.Size = new System.Drawing.Size(99, 15);
            labelMaxFuelLevel.TabIndex = 8;
            labelMaxFuelLevel.Text = "Pojemnosc baku";
            // 
            // labelSpecific
            // 
            labelSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelSpecific.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelSpecific.Location = new System.Drawing.Point(1, 133);
            labelSpecific.Name = "labelSpecific";
            labelSpecific.RightToLeft = System.Windows.Forms.RightToLeft.No;
            labelSpecific.Size = new System.Drawing.Size(177, 15);
            labelSpecific.AutoSize = true;
            labelSpecific.TabIndex = 9;
            labelSpecific.Text = "   Maks. pasażerow";
            // 
            // textBoxWeaponType
            // 
            textBoxWeaponType.Location = new System.Drawing.Point(137, 107);
            textBoxWeaponType.Name = "textBoxWeaponType";
            textBoxWeaponType.Size = new System.Drawing.Size(100, 20);
            textBoxWeaponType.TabIndex = 10;
            // 
            // labelWeaponType
            // 
            labelWeaponType.AutoSize = true;
            labelWeaponType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelWeaponType.Location = new System.Drawing.Point(52, 108);
            labelWeaponType.Name = "labelWeaponType";
            labelWeaponType.Size = new System.Drawing.Size(73, 15);
            labelWeaponType.TabIndex = 11;
            labelWeaponType.Text = "Model broni";
           

            labelModel.Visible = true;
            textBoxModel.Visible = true;

            labelFuelUsage.Visible = true;
            textBoxFuelUsage.Visible = true;

            labelMaxFuelLevel.Visible = true;
            textBoxMaxFuelLevel.Visible = true;

            labelTakeoffInterval.Visible = true;
            
            rbPassenger.Checked = true;

        }

        private void image_onClick(object sender, EventArgs e)
        {
            for(int i = 0; i < 6; i++)
            {
                if(images[i] == sender)
                {
                    chosenImageName = getCurrentImageName(i);
                    chosenImageHandle = images[i];

                    chosenImageMark.Parent = images[i];
                    chosenImageMark.Visible = true;
                    // updateImages();

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
            textBoxWeaponType.ResetText();
            textBoxSpecific.ResetText();

            chosenImageHandle = null;
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
            if (currentFactoring == PlaneType.Military)
            {
                for (int i = 0; i < PlaneImagesCollection.militaryPlaneNames.Count; i++)
                {
                    images[i].Image = (Image)Properties.Resources.ResourceManager.GetObject(PlaneImagesCollection.militaryPlaneNames[i]);
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

                    labelSpecific.Text = "       Maks. pasażerów";
                    labelSpecific.Visible = true;
                    textBoxSpecific.Visible = true;

                    labelWeaponType.Visible = false;
                    textBoxWeaponType.Visible = false;

                    break;
                case PlaneType.Transport:
                    labelSpecific.Text = "Maks. ładowność (kg)";
                    labelSpecific.Visible = true;
                    textBoxSpecific.Visible = true;

                    labelWeaponType.Visible = false;
                    textBoxWeaponType.Visible = false;

                    break;
                case PlaneType.Military:

                    labelSpecific.Text = "  Maks. ilość amunicji";
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
            factoriedPlane.setTakeoffTime(Int32.Parse(comboBox1.Text));
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
