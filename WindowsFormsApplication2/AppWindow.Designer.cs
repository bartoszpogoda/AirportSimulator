using System;
using System.Drawing;
using System.Windows.Forms;

namespace SymulatorLotniska
{
    partial class AppWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelSamolotow = new System.Windows.Forms.Panel();
            this.labelHangar = new System.Windows.Forms.Label();
            this.panelInformacji = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.labelTekstInformacje = new System.Windows.Forms.Label();
            this.labelInformacje = new System.Windows.Forms.Label();
            this.panelSamolotyWPowietrzu = new System.Windows.Forms.Panel();
            this.labelSamolotyPowietrze = new System.Windows.Forms.Label();
            this.panelPrzyciskow = new System.Windows.Forms.Panel();
            this.panelPasStartowy1 = new System.Windows.Forms.Panel();
            this.panelPasStartowy2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnPrawo = new System.Windows.Forms.Button();
            this.btnLewo = new System.Windows.Forms.Button();
            this.btnGora = new System.Windows.Forms.Button();
            this.btnDol = new System.Windows.Forms.Button();
            this.btnSendAway = new System.Windows.Forms.Button();
            this.btnLanding = new System.Windows.Forms.Button();
            this.btnM5C = new System.Windows.Forms.Button();
            this.btnM1C = new System.Windows.Forms.Button();
            this.btnD5C = new System.Windows.Forms.Button();
            this.btnStartowanie = new System.Windows.Forms.Button();
            this.btnD1C = new System.Windows.Forms.Button();
            this.doHangaru = new System.Windows.Forms.Button();
            this.operationCancel = new System.Windows.Forms.Button();
            this.kontrola = new System.Windows.Forms.Button();
            this.naPasStartowy = new System.Windows.Forms.Button();
            this.tankowanie = new System.Windows.Forms.Button();
            this.mainPlaneFactoryPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbPassenger = new System.Windows.Forms.RadioButton();
            this.rbTransport = new System.Windows.Forms.RadioButton();
            this.rbMilitary = new System.Windows.Forms.RadioButton();
            this.imageChoosePanel = new System.Windows.Forms.Panel();
            this.parameterChoosePanel = new System.Windows.Forms.Panel();
            this.buttonCreateInHangar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.chosenImage = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelModel = new System.Windows.Forms.Label();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxFuelUsage = new System.Windows.Forms.TextBox();
            this.textBoxMaxFuelLevel = new System.Windows.Forms.TextBox();
            this.textBoxTakeoffInterval = new System.Windows.Forms.TextBox();
            this.textBoxSpecific = new System.Windows.Forms.TextBox();
            this.labelFuelUsage = new System.Windows.Forms.Label();
            this.labelTakeoffInterval = new System.Windows.Forms.Label();
            this.labelMaxFuelLevel = new System.Windows.Forms.Label();
            this.labelSpecific = new System.Windows.Forms.Label();
            this.textBoxWeaponType = new System.Windows.Forms.TextBox();
            this.labelWeaponType = new System.Windows.Forms.Label();
            this.buttonCreateInAir = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panelSamolotow.SuspendLayout();
            this.panelInformacji.SuspendLayout();
            this.panelSamolotyWPowietrzu.SuspendLayout();
            this.panelPrzyciskow.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mainPlaneFactoryPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.imageChoosePanel.SuspendLayout();
            this.parameterChoosePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 14);
            this.button1.TabIndex = 0;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(218, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 14);
            this.button2.TabIndex = 2;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelSamolotow
            // 
            this.panelSamolotow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelSamolotow.Controls.Add(this.btnGora);
            this.panelSamolotow.Controls.Add(this.btnDol);
            this.panelSamolotow.Controls.Add(this.labelHangar);
            this.panelSamolotow.Location = new System.Drawing.Point(10, 15);
            this.panelSamolotow.Name = "panelSamolotow";
            this.panelSamolotow.Size = new System.Drawing.Size(277, 200);
            this.panelSamolotow.TabIndex = 0;
            // 
            // labelHangar
            // 
            this.labelHangar.AutoSize = true;
            this.labelHangar.BackColor = System.Drawing.Color.LightSlateGray;
            this.labelHangar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHangar.ForeColor = System.Drawing.Color.White;
            this.labelHangar.Location = new System.Drawing.Point(-1, 0);
            this.labelHangar.Name = "labelHangar";
            this.labelHangar.Size = new System.Drawing.Size(155, 18);
            this.labelHangar.TabIndex = 0;
            this.labelHangar.Text = "Samoloty w hangarze:";
            // 
            // panelInformacji
            // 
            this.panelInformacji.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panelInformacji.Controls.Add(this.button3);
            this.panelInformacji.Controls.Add(this.labelTekstInformacje);
            this.panelInformacji.Controls.Add(this.button2);
            this.panelInformacji.Controls.Add(this.labelInformacje);
            this.panelInformacji.Controls.Add(this.button1);
            this.panelInformacji.Location = new System.Drawing.Point(412, 15);
            this.panelInformacji.Name = "panelInformacji";
            this.panelInformacji.Size = new System.Drawing.Size(280, 200);
            this.panelInformacji.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(132, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 14);
            this.button3.TabIndex = 3;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // labelTekstInformacje
            // 
            this.labelTekstInformacje.AutoSize = true;
            this.labelTekstInformacje.BackColor = System.Drawing.Color.Khaki;
            this.labelTekstInformacje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTekstInformacje.ForeColor = System.Drawing.Color.Black;
            this.labelTekstInformacje.Location = new System.Drawing.Point(-3, 0);
            this.labelTekstInformacje.Name = "labelTekstInformacje";
            this.labelTekstInformacje.Size = new System.Drawing.Size(167, 18);
            this.labelTekstInformacje.TabIndex = 0;
            this.labelTekstInformacje.Text = "Informacje o samolocie:";
            // 
            // labelInformacje
            // 
            this.labelInformacje.AutoSize = true;
            this.labelInformacje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInformacje.ForeColor = System.Drawing.Color.Black;
            this.labelInformacje.Location = new System.Drawing.Point(6, 30);
            this.labelInformacje.Name = "labelInformacje";
            this.labelInformacje.Size = new System.Drawing.Size(120, 18);
            this.labelInformacje.TabIndex = 0;
            this.labelInformacje.Text = "Wybierz samolot";
            // 
            // panelSamolotyWPowietrzu
            // 
            this.panelSamolotyWPowietrzu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelSamolotyWPowietrzu.Controls.Add(this.btnPrawo);
            this.panelSamolotyWPowietrzu.Controls.Add(this.btnLewo);
            this.panelSamolotyWPowietrzu.Controls.Add(this.labelSamolotyPowietrze);
            this.panelSamolotyWPowietrzu.Location = new System.Drawing.Point(10, 221);
            this.panelSamolotyWPowietrzu.Name = "panelSamolotyWPowietrzu";
            this.panelSamolotyWPowietrzu.Size = new System.Drawing.Size(491, 109);
            this.panelSamolotyWPowietrzu.TabIndex = 0;
            // 
            // labelSamolotyPowietrze
            // 
            this.labelSamolotyPowietrze.AutoSize = true;
            this.labelSamolotyPowietrze.BackColor = System.Drawing.Color.LightSlateGray;
            this.labelSamolotyPowietrze.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSamolotyPowietrze.ForeColor = System.Drawing.Color.White;
            this.labelSamolotyPowietrze.Location = new System.Drawing.Point(-1, 0);
            this.labelSamolotyPowietrze.Name = "labelSamolotyPowietrze";
            this.labelSamolotyPowietrze.Size = new System.Drawing.Size(158, 18);
            this.labelSamolotyPowietrze.TabIndex = 1;
            this.labelSamolotyPowietrze.Text = "Samoloty w powietrzu:";
            // 
            // panelPrzyciskow
            // 
            this.panelPrzyciskow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPrzyciskow.Controls.Add(this.btnSendAway);
            this.panelPrzyciskow.Controls.Add(this.btnLanding);
            this.panelPrzyciskow.Controls.Add(this.btnM5C);
            this.panelPrzyciskow.Controls.Add(this.btnM1C);
            this.panelPrzyciskow.Controls.Add(this.btnD5C);
            this.panelPrzyciskow.Controls.Add(this.btnStartowanie);
            this.panelPrzyciskow.Controls.Add(this.btnD1C);
            this.panelPrzyciskow.Controls.Add(this.doHangaru);
            this.panelPrzyciskow.Controls.Add(this.operationCancel);
            this.panelPrzyciskow.Controls.Add(this.kontrola);
            this.panelPrzyciskow.Controls.Add(this.naPasStartowy);
            this.panelPrzyciskow.Controls.Add(this.tankowanie);
            this.panelPrzyciskow.Location = new System.Drawing.Point(293, 33);
            this.panelPrzyciskow.Name = "panelPrzyciskow";
            this.panelPrzyciskow.Size = new System.Drawing.Size(113, 170);
            this.panelPrzyciskow.TabIndex = 0;
            // 
            // panelPasStartowy1
            // 
            this.panelPasStartowy1.BackColor = System.Drawing.Color.AliceBlue;
            this.panelPasStartowy1.Location = new System.Drawing.Point(10, 336);
            this.panelPasStartowy1.Name = "panelPasStartowy1";
            this.panelPasStartowy1.Size = new System.Drawing.Size(491, 100);
            this.panelPasStartowy1.TabIndex = 4;
            // 
            // panelPasStartowy2
            // 
            this.panelPasStartowy2.BackColor = System.Drawing.Color.AliceBlue;
            this.panelPasStartowy2.Location = new System.Drawing.Point(10, 442);
            this.panelPasStartowy2.Name = "panelPasStartowy2";
            this.panelPasStartowy2.Size = new System.Drawing.Size(491, 100);
            this.panelPasStartowy2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Location = new System.Drawing.Point(521, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 286);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Centrum powiadomien";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(521, 522);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 20);
            this.button4.TabIndex = 7;
            this.button4.Text = "Wyczyść";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(57, 92);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnPrawo
            // 
            this.btnPrawo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrawo.Image = global::SymulatorLotniska.Properties.Resources.btnPrawo;
            this.btnPrawo.Location = new System.Drawing.Point(454, 76);
            this.btnPrawo.Name = "btnPrawo";
            this.btnPrawo.Size = new System.Drawing.Size(30, 30);
            this.btnPrawo.TabIndex = 4;
            this.btnPrawo.UseVisualStyleBackColor = false;
            this.btnPrawo.Click += new System.EventHandler(this.btnPrawo_Click);
            // 
            // btnLewo
            // 
            this.btnLewo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLewo.Image = global::SymulatorLotniska.Properties.Resources.btnLewo;
            this.btnLewo.Location = new System.Drawing.Point(3, 79);
            this.btnLewo.Name = "btnLewo";
            this.btnLewo.Size = new System.Drawing.Size(30, 30);
            this.btnLewo.TabIndex = 3;
            this.btnLewo.UseVisualStyleBackColor = false;
            this.btnLewo.Click += new System.EventHandler(this.btnLewo_Click);
            // 
            // btnGora
            // 
            this.btnGora.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGora.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGora.Image = global::SymulatorLotniska.Properties.Resources.btnGora;
            this.btnGora.Location = new System.Drawing.Point(247, 18);
            this.btnGora.Name = "btnGora";
            this.btnGora.Size = new System.Drawing.Size(30, 30);
            this.btnGora.TabIndex = 1;
            this.btnGora.UseVisualStyleBackColor = false;
            this.btnGora.Click += new System.EventHandler(this.btnGora_Click);
            // 
            // btnDol
            // 
            this.btnDol.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDol.Image = global::SymulatorLotniska.Properties.Resources.btnDol;
            this.btnDol.Location = new System.Drawing.Point(247, 167);
            this.btnDol.Name = "btnDol";
            this.btnDol.Size = new System.Drawing.Size(30, 30);
            this.btnDol.TabIndex = 2;
            this.btnDol.UseVisualStyleBackColor = false;
            this.btnDol.Click += new System.EventHandler(this.btnDol_Click);
            // 
            // btnSendAway
            // 
            this.btnSendAway.BackColor = System.Drawing.Color.White;
            this.btnSendAway.Image = global::SymulatorLotniska.Properties.Resources.btnGora;
            this.btnSendAway.Location = new System.Drawing.Point(59, 3);
            this.btnSendAway.Name = "btnSendAway";
            this.btnSendAway.Size = new System.Drawing.Size(50, 50);
            this.btnSendAway.TabIndex = 15;
            this.btnSendAway.UseVisualStyleBackColor = false;
            this.btnSendAway.Click += new System.EventHandler(this.btnSendAway_Click);
            // 
            // btnLanding
            // 
            this.btnLanding.BackColor = System.Drawing.Color.White;
            this.btnLanding.Image = global::SymulatorLotniska.Properties.Resources.btnDol;
            this.btnLanding.Location = new System.Drawing.Point(4, 3);
            this.btnLanding.Name = "btnLanding";
            this.btnLanding.Size = new System.Drawing.Size(50, 50);
            this.btnLanding.TabIndex = 14;
            this.btnLanding.UseVisualStyleBackColor = false;
            this.btnLanding.Click += new System.EventHandler(this.btnLanding_Click);
            // 
            // btnM5C
            // 
            this.btnM5C.BackColor = System.Drawing.Color.White;
            this.btnM5C.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnM5C.Image = global::SymulatorLotniska.Properties.Resources.buttonM5czlowiek;
            this.btnM5C.Location = new System.Drawing.Point(59, 59);
            this.btnM5C.Name = "btnM5C";
            this.btnM5C.Size = new System.Drawing.Size(50, 50);
            this.btnM5C.TabIndex = 13;
            this.btnM5C.UseVisualStyleBackColor = false;
            this.btnM5C.Click += new System.EventHandler(this.btnM5C_Click);
            // 
            // btnM1C
            // 
            this.btnM1C.BackColor = System.Drawing.Color.White;
            this.btnM1C.Image = global::SymulatorLotniska.Properties.Resources.buttonM1czlowiek;
            this.btnM1C.Location = new System.Drawing.Point(59, 3);
            this.btnM1C.Name = "btnM1C";
            this.btnM1C.Size = new System.Drawing.Size(50, 50);
            this.btnM1C.TabIndex = 12;
            this.btnM1C.UseVisualStyleBackColor = false;
            this.btnM1C.Click += new System.EventHandler(this.btnM1C_Click);
            // 
            // btnD5C
            // 
            this.btnD5C.BackColor = System.Drawing.Color.White;
            this.btnD5C.Image = global::SymulatorLotniska.Properties.Resources.buttonP5czlowiek;
            this.btnD5C.Location = new System.Drawing.Point(4, 59);
            this.btnD5C.Name = "btnD5C";
            this.btnD5C.Size = new System.Drawing.Size(50, 50);
            this.btnD5C.TabIndex = 11;
            this.btnD5C.UseVisualStyleBackColor = false;
            this.btnD5C.Click += new System.EventHandler(this.btnD5C_Click);
            // 
            // btnStartowanie
            // 
            this.btnStartowanie.BackColor = System.Drawing.Color.White;
            this.btnStartowanie.Image = global::SymulatorLotniska.Properties.Resources.btnStartowanie;
            this.btnStartowanie.Location = new System.Drawing.Point(4, 115);
            this.btnStartowanie.Name = "btnStartowanie";
            this.btnStartowanie.Size = new System.Drawing.Size(50, 50);
            this.btnStartowanie.TabIndex = 8;
            this.btnStartowanie.UseVisualStyleBackColor = false;
            this.btnStartowanie.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnD1C
            // 
            this.btnD1C.BackColor = System.Drawing.Color.White;
            this.btnD1C.Image = global::SymulatorLotniska.Properties.Resources.buttonP1czlowiek;
            this.btnD1C.Location = new System.Drawing.Point(4, 3);
            this.btnD1C.Name = "btnD1C";
            this.btnD1C.Size = new System.Drawing.Size(50, 50);
            this.btnD1C.TabIndex = 6;
            this.btnD1C.UseVisualStyleBackColor = false;
            this.btnD1C.Click += new System.EventHandler(this.wprowadzenieLudzi_Click);
            // 
            // doHangaru
            // 
            this.doHangaru.BackColor = System.Drawing.Color.White;
            this.doHangaru.Image = global::SymulatorLotniska.Properties.Resources.btnDoHangaru;
            this.doHangaru.Location = new System.Drawing.Point(60, 115);
            this.doHangaru.Name = "doHangaru";
            this.doHangaru.Size = new System.Drawing.Size(50, 50);
            this.doHangaru.TabIndex = 5;
            this.doHangaru.UseVisualStyleBackColor = false;
            this.doHangaru.Click += new System.EventHandler(this.doHangaru_Click);
            // 
            // operationCancel
            // 
            this.operationCancel.BackColor = System.Drawing.Color.Pink;
            this.operationCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("operationCancel.BackgroundImage")));
            this.operationCancel.Location = new System.Drawing.Point(3, 3);
            this.operationCancel.Name = "operationCancel";
            this.operationCancel.Size = new System.Drawing.Size(50, 50);
            this.operationCancel.TabIndex = 3;
            this.operationCancel.UseVisualStyleBackColor = false;
            this.operationCancel.Click += new System.EventHandler(this.tankowanieCancel_Click);
            // 
            // kontrola
            // 
            this.kontrola.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.kontrola.Image = global::SymulatorLotniska.Properties.Resources.kontrolatechniczna;
            this.kontrola.Location = new System.Drawing.Point(3, 59);
            this.kontrola.Name = "kontrola";
            this.kontrola.Size = new System.Drawing.Size(50, 50);
            this.kontrola.TabIndex = 2;
            this.kontrola.UseVisualStyleBackColor = false;
            this.kontrola.Click += new System.EventHandler(this.kontrola_Click);
            // 
            // naPasStartowy
            // 
            this.naPasStartowy.BackColor = System.Drawing.Color.White;
            this.naPasStartowy.Image = ((System.Drawing.Image)(resources.GetObject("naPasStartowy.Image")));
            this.naPasStartowy.Location = new System.Drawing.Point(3, 115);
            this.naPasStartowy.Name = "naPasStartowy";
            this.naPasStartowy.Size = new System.Drawing.Size(50, 50);
            this.naPasStartowy.TabIndex = 1;
            this.naPasStartowy.UseVisualStyleBackColor = false;
            this.naPasStartowy.Click += new System.EventHandler(this.naPasStartowy_Click);
            // 
            // tankowanie
            // 
            this.tankowanie.BackColor = System.Drawing.Color.White;
            this.tankowanie.Image = global::SymulatorLotniska.Properties.Resources.tankowanieN;
            this.tankowanie.Location = new System.Drawing.Point(3, 3);
            this.tankowanie.Name = "tankowanie";
            this.tankowanie.Size = new System.Drawing.Size(50, 50);
            this.tankowanie.TabIndex = 0;
            this.tankowanie.UseVisualStyleBackColor = false;
            this.tankowanie.Click += new System.EventHandler(this.tankowanie_Click);
            // 
            // mainPlaneFactoryPanel
            // 
            this.mainPlaneFactoryPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainPlaneFactoryPanel.Controls.Add(this.cancelButton);
            this.mainPlaneFactoryPanel.Controls.Add(this.buttonCreateInAir);
            this.mainPlaneFactoryPanel.Controls.Add(this.panel2);
            this.mainPlaneFactoryPanel.Controls.Add(this.buttonCreateInHangar);
            this.mainPlaneFactoryPanel.Controls.Add(this.parameterChoosePanel);
            this.mainPlaneFactoryPanel.Controls.Add(this.imageChoosePanel);
            this.mainPlaneFactoryPanel.Controls.Add(this.rbMilitary);
            this.mainPlaneFactoryPanel.Controls.Add(this.rbTransport);
            this.mainPlaneFactoryPanel.Controls.Add(this.rbPassenger);
            this.mainPlaneFactoryPanel.Controls.Add(this.panel1);
            this.mainPlaneFactoryPanel.Location = new System.Drawing.Point(10, 12);
            this.mainPlaneFactoryPanel.Name = "mainPlaneFactoryPanel";
            this.mainPlaneFactoryPanel.Size = new System.Drawing.Size(682, 203);
            this.mainPlaneFactoryPanel.TabIndex = 8;
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
            // 
            // imageChoosePanel
            // 
            this.imageChoosePanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.imageChoosePanel.Controls.Add(this.pictureBox9);
            this.imageChoosePanel.Controls.Add(this.pictureBox8);
            this.imageChoosePanel.Controls.Add(this.pictureBox7);
            this.imageChoosePanel.Controls.Add(this.pictureBox6);
            this.imageChoosePanel.Controls.Add(this.pictureBox5);
            this.imageChoosePanel.Controls.Add(this.pictureBox4);
            this.imageChoosePanel.Controls.Add(this.pictureBox3);
            this.imageChoosePanel.Controls.Add(this.pictureBox2);
            this.imageChoosePanel.Controls.Add(this.pictureBox1);
            this.imageChoosePanel.Location = new System.Drawing.Point(169, 33);
            this.imageChoosePanel.Name = "imageChoosePanel";
            this.imageChoosePanel.Size = new System.Drawing.Size(168, 167);
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
            this.parameterChoosePanel.Size = new System.Drawing.Size(255, 187);
            this.parameterChoosePanel.TabIndex = 5;
            // 
            // buttonCreateInHangar
            // 
            this.buttonCreateInHangar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCreateInHangar.Location = new System.Drawing.Point(631, 65);
            this.buttonCreateInHangar.Name = "buttonCreateInHangar";
            this.buttonCreateInHangar.Size = new System.Drawing.Size(48, 55);
            this.buttonCreateInHangar.TabIndex = 6;
            this.buttonCreateInHangar.UseVisualStyleBackColor = false;
            this.buttonCreateInHangar.Click += new System.EventHandler(this.buttonCreateInHangar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox2.Location = new System.Drawing.Point(59, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox3.Location = new System.Drawing.Point(115, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox4.Location = new System.Drawing.Point(3, 59);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox5.Location = new System.Drawing.Point(59, 59);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 50);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox6.Location = new System.Drawing.Point(115, 59);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(50, 50);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox7.Location = new System.Drawing.Point(3, 115);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(50, 50);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox8.Location = new System.Drawing.Point(59, 115);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 50);
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox9.Location = new System.Drawing.Point(115, 115);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(50, 50);
            this.pictureBox9.TabIndex = 8;
            this.pictureBox9.TabStop = false;
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
            this.textBoxFuelUsage.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
            this.textBoxSpecific.Location = new System.Drawing.Point(69, 160);
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
            this.labelTakeoffInterval.Click += new System.EventHandler(this.label4_Click);
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
            this.labelSpecific.Location = new System.Drawing.Point(30, 142);
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
            // buttonCreateInAir
            // 
            this.buttonCreateInAir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCreateInAir.Location = new System.Drawing.Point(630, 6);
            this.buttonCreateInAir.Name = "buttonCreateInAir";
            this.buttonCreateInAir.Size = new System.Drawing.Size(48, 46);
            this.buttonCreateInAir.TabIndex = 9;
            this.buttonCreateInAir.UseVisualStyleBackColor = false;
            this.buttonCreateInAir.Click += new System.EventHandler(this.buttonCreateInAir_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelButton.Location = new System.Drawing.Point(630, 134);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(48, 55);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 545);
            this.Controls.Add(this.mainPlaneFactoryPanel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelSamolotyWPowietrzu);
            this.Controls.Add(this.panelPasStartowy2);
            this.Controls.Add(this.panelPasStartowy1);
            this.Controls.Add(this.panelInformacji);
            this.Controls.Add(this.panelSamolotow);
            this.Controls.Add(this.panelPrzyciskow);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppWindow";
            this.Text = "Symulator Lotniska v: -0.001";
            this.panelSamolotow.ResumeLayout(false);
            this.panelSamolotow.PerformLayout();
            this.panelInformacji.ResumeLayout(false);
            this.panelInformacji.PerformLayout();
            this.panelSamolotyWPowietrzu.ResumeLayout(false);
            this.panelSamolotyWPowietrzu.PerformLayout();
            this.panelPrzyciskow.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.mainPlaneFactoryPanel.ResumeLayout(false);
            this.mainPlaneFactoryPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.imageChoosePanel.ResumeLayout(false);
            this.parameterChoosePanel.ResumeLayout(false);
            this.parameterChoosePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // moj kod

        

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelSamolotow;
        private System.Windows.Forms.Panel panelInformacji;
        private System.Windows.Forms.Panel panelPrzyciskow;
        private System.Windows.Forms.Label labelHangar;
        private System.Windows.Forms.Label labelInformacje;
        private System.Windows.Forms.Label labelTekstInformacje;
        private System.Windows.Forms.Panel panelSamolotyWPowietrzu;
        private Button kontrola;
        private Button naPasStartowy;
        private Button tankowanie;
        private Button operationCancel;
        private Panel panelPasStartowy1;
        private Panel panelPasStartowy2;
        private Button btnStartowanie;
        private Button btnD1C;
        private Button doHangaru;
        private Label labelSamolotyPowietrze;
        private Button btnM5C;
        private Button btnM1C;
        private Button btnD5C;
        private Button btnDol;
        private Button btnGora;
        private Button btnPrawo;
        private Button btnLewo;
        private GroupBox groupBox1;
        private Button button3;
        private Button button4;
        private Button btnSendAway;
        private Button btnLanding;
        private Button button5;
        private Panel mainPlaneFactoryPanel;
        private Panel panel1;
        private Label label1;
        private RadioButton rbMilitary;
        private RadioButton rbTransport;
        private RadioButton rbPassenger;
        private Button buttonCreateInHangar;
        private Panel parameterChoosePanel;
        private Panel imageChoosePanel;
        private Panel panel2;
        private PictureBox chosenImage;
        private PictureBox pictureBox9;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label labelModel;
        private Label labelTakeoffInterval;
        private Label labelFuelUsage;
        private TextBox textBoxSpecific;
        private TextBox textBoxTakeoffInterval;
        private TextBox textBoxMaxFuelLevel;
        private TextBox textBoxFuelUsage;
        private TextBox textBoxModel;
        private Label labelMaxFuelLevel;
        private Label labelSpecific;
        private Label labelWeaponType;
        private TextBox textBoxWeaponType;
        private Button buttonCreateInAir;
        private Button cancelButton;
    }
}

