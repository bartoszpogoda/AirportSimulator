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
            this.panelSamolotow = new System.Windows.Forms.Panel();
            this.btnGora = new System.Windows.Forms.Button();
            this.btnDol = new System.Windows.Forms.Button();
            this.labelHangar = new System.Windows.Forms.Label();
            this.panelInformacji = new System.Windows.Forms.Panel();
            this.labelTekstInformacje = new System.Windows.Forms.Label();
            this.labelInformacje = new System.Windows.Forms.Label();
            this.panelSamolotyWPowietrzu = new System.Windows.Forms.Panel();
            this.btnPrawo = new System.Windows.Forms.Button();
            this.btnLewo = new System.Windows.Forms.Button();
            this.labelSamolotyPowietrze = new System.Windows.Forms.Label();
            this.switchAssistant = new System.Windows.Forms.Label();
            this.btnSendAway = new System.Windows.Forms.Button();
            this.panelPasStartowy1 = new System.Windows.Forms.Panel();
            this.panelPasStartowy2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.peopleCount = new System.Windows.Forms.TextBox();
            this.peoplePanel = new System.Windows.Forms.Panel();
            this.cargoPanel = new System.Windows.Forms.Panel();
            this.cargoCount = new System.Windows.Forms.TextBox();
            this.ammoPanel = new System.Windows.Forms.Panel();
            this.ammoCount = new System.Windows.Forms.TextBox();
            this.switchAcceptingIncomingPlanes = new System.Windows.Forms.Label();
            this.btnFuel = new System.Windows.Forms.Button();
            this.btnOnRunway = new System.Windows.Forms.Button();
            this.btnTechnicalInspection = new System.Windows.Forms.Button();
            this.btnCancelOperation = new System.Windows.Forms.Button();
            this.btnStartowanie = new System.Windows.Forms.Button();
            this.btnLand = new System.Windows.Forms.Button();
            this.btnUnload = new System.Windows.Forms.Button();
            this.panelPrzyciskow = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnToHangar = new System.Windows.Forms.Button();
            this.notificationListClear = new System.Windows.Forms.Label();
            this.switchOperationSingle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSamolotow.SuspendLayout();
            this.panelInformacji.SuspendLayout();
            this.panelSamolotyWPowietrzu.SuspendLayout();
            this.peoplePanel.SuspendLayout();
            this.cargoPanel.SuspendLayout();
            this.ammoPanel.SuspendLayout();
            this.panelPrzyciskow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSamolotow
            // 
            this.panelSamolotow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelSamolotow.Controls.Add(this.btnGora);
            this.panelSamolotow.Controls.Add(this.btnDol);
            this.panelSamolotow.Controls.Add(this.labelHangar);
            this.panelSamolotow.Location = new System.Drawing.Point(13, 28);
            this.panelSamolotow.Name = "panelSamolotow";
            this.panelSamolotow.Size = new System.Drawing.Size(277, 200);
            this.panelSamolotow.TabIndex = 0;
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
            this.btnGora.Click += new System.EventHandler(this.btnUp_click);
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
            this.btnDol.Click += new System.EventHandler(this.btnDown_click);
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
            this.panelInformacji.Controls.Add(this.labelTekstInformacje);
            this.panelInformacji.Controls.Add(this.labelInformacje);
            this.panelInformacji.Location = new System.Drawing.Point(361, 28);
            this.panelInformacji.Name = "panelInformacji";
            this.panelInformacji.Size = new System.Drawing.Size(301, 200);
            this.panelInformacji.TabIndex = 0;
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
            this.panelSamolotyWPowietrzu.Location = new System.Drawing.Point(12, 246);
            this.panelSamolotyWPowietrzu.Name = "panelSamolotyWPowietrzu";
            this.panelSamolotyWPowietrzu.Size = new System.Drawing.Size(491, 109);
            this.panelSamolotyWPowietrzu.TabIndex = 0;
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
            this.btnPrawo.Click += new System.EventHandler(this.btnRight_click);
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
            this.btnLewo.Click += new System.EventHandler(this.btnLeft_click);
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
            // switchAssistant
            // 
            this.switchAssistant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.switchAssistant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.switchAssistant.Location = new System.Drawing.Point(110, 11);
            this.switchAssistant.Name = "switchAssistant";
            this.switchAssistant.Padding = new System.Windows.Forms.Padding(5);
            this.switchAssistant.Size = new System.Drawing.Size(30, 27);
            this.switchAssistant.TabIndex = 17;
            this.switchAssistant.Text = "AI";
            this.switchAssistant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.switchAssistant.Click += new System.EventHandler(this.switchAssistant_click);
            // 
            // btnSendAway
            // 
            this.btnSendAway.BackColor = System.Drawing.Color.White;
            this.btnSendAway.Image = global::SymulatorLotniska.Properties.Resources.btnGora;
            this.btnSendAway.Location = new System.Drawing.Point(4, 59);
            this.btnSendAway.Name = "btnSendAway";
            this.btnSendAway.Size = new System.Drawing.Size(50, 50);
            this.btnSendAway.TabIndex = 15;
            this.btnSendAway.UseVisualStyleBackColor = false;
            this.btnSendAway.Click += new System.EventHandler(this.btnSendAway_click);
            // 
            // panelPasStartowy1
            // 
            this.panelPasStartowy1.BackColor = System.Drawing.Color.AliceBlue;
            this.panelPasStartowy1.Location = new System.Drawing.Point(12, 361);
            this.panelPasStartowy1.Name = "panelPasStartowy1";
            this.panelPasStartowy1.Size = new System.Drawing.Size(491, 100);
            this.panelPasStartowy1.TabIndex = 4;
            // 
            // panelPasStartowy2
            // 
            this.panelPasStartowy2.BackColor = System.Drawing.Color.AliceBlue;
            this.panelPasStartowy2.Location = new System.Drawing.Point(12, 467);
            this.panelPasStartowy2.Name = "panelPasStartowy2";
            this.panelPasStartowy2.Size = new System.Drawing.Size(491, 100);
            this.panelPasStartowy2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(522, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 266);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Centrum powiadomien";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button6.Location = new System.Drawing.Point(0, 0);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(785, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Fabryka samolotów";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btnShowFactoryPanel);
            // 
            // peopleCount
            // 
            this.peopleCount.Enabled = false;
            this.peopleCount.Location = new System.Drawing.Point(26, 37);
            this.peopleCount.Name = "peopleCount";
            this.peopleCount.ReadOnly = true;
            this.peopleCount.Size = new System.Drawing.Size(61, 20);
            this.peopleCount.TabIndex = 9;
            this.peopleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // peoplePanel
            // 
            this.peoplePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.peoplePanel.BackgroundImage = global::SymulatorLotniska.Properties.Resources.people;
            this.peoplePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peoplePanel.Controls.Add(this.peopleCount);
            this.peoplePanel.Location = new System.Drawing.Point(680, 31);
            this.peoplePanel.Name = "peoplePanel";
            this.peoplePanel.Size = new System.Drawing.Size(90, 60);
            this.peoplePanel.TabIndex = 10;
            this.peoplePanel.Click += new System.EventHandler(this.peoplePanel_Click);
            // 
            // cargoPanel
            // 
            this.cargoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cargoPanel.BackgroundImage = global::SymulatorLotniska.Properties.Resources.cargo;
            this.cargoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cargoPanel.Controls.Add(this.cargoCount);
            this.cargoPanel.Location = new System.Drawing.Point(680, 99);
            this.cargoPanel.Name = "cargoPanel";
            this.cargoPanel.Size = new System.Drawing.Size(90, 60);
            this.cargoPanel.TabIndex = 11;
            this.cargoPanel.Click += new System.EventHandler(this.cargoPanel_Click);
            // 
            // cargoCount
            // 
            this.cargoCount.Enabled = false;
            this.cargoCount.Location = new System.Drawing.Point(26, 37);
            this.cargoCount.Name = "cargoCount";
            this.cargoCount.ReadOnly = true;
            this.cargoCount.Size = new System.Drawing.Size(61, 20);
            this.cargoCount.TabIndex = 9;
            this.cargoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ammoPanel
            // 
            this.ammoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ammoPanel.BackgroundImage = global::SymulatorLotniska.Properties.Resources.ammo;
            this.ammoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammoPanel.Controls.Add(this.ammoCount);
            this.ammoPanel.Location = new System.Drawing.Point(680, 168);
            this.ammoPanel.Name = "ammoPanel";
            this.ammoPanel.Size = new System.Drawing.Size(90, 60);
            this.ammoPanel.TabIndex = 11;
            this.ammoPanel.Click += new System.EventHandler(this.ammoPanel_Click);
            // 
            // ammoCount
            // 
            this.ammoCount.Enabled = false;
            this.ammoCount.Location = new System.Drawing.Point(26, 37);
            this.ammoCount.Name = "ammoCount";
            this.ammoCount.ReadOnly = true;
            this.ammoCount.Size = new System.Drawing.Size(61, 20);
            this.ammoCount.TabIndex = 9;
            this.ammoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // switchAcceptingIncomingPlanes
            // 
            this.switchAcceptingIncomingPlanes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.switchAcceptingIncomingPlanes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.switchAcceptingIncomingPlanes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.switchAcceptingIncomingPlanes.Location = new System.Drawing.Point(4, 5);
            this.switchAcceptingIncomingPlanes.Name = "switchAcceptingIncomingPlanes";
            this.switchAcceptingIncomingPlanes.Padding = new System.Windows.Forms.Padding(5);
            this.switchAcceptingIncomingPlanes.Size = new System.Drawing.Size(98, 38);
            this.switchAcceptingIncomingPlanes.TabIndex = 14;
            this.switchAcceptingIncomingPlanes.Text = "Przyjmowanie samolotów";
            this.switchAcceptingIncomingPlanes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.switchAcceptingIncomingPlanes.Click += new System.EventHandler(this.switchAcceptingIncomingPlanes_click);
            // 
            // btnFuel
            // 
            this.btnFuel.BackColor = System.Drawing.Color.White;
            this.btnFuel.Image = global::SymulatorLotniska.Properties.Resources.tankowanieN;
            this.btnFuel.Location = new System.Drawing.Point(3, 3);
            this.btnFuel.Name = "btnFuel";
            this.btnFuel.Size = new System.Drawing.Size(50, 50);
            this.btnFuel.TabIndex = 0;
            this.btnFuel.UseVisualStyleBackColor = false;
            this.btnFuel.Click += new System.EventHandler(this.btnFuel_click);
            // 
            // btnOnRunway
            // 
            this.btnOnRunway.BackColor = System.Drawing.Color.White;
            this.btnOnRunway.Image = ((System.Drawing.Image)(resources.GetObject("btnOnRunway.Image")));
            this.btnOnRunway.Location = new System.Drawing.Point(3, 115);
            this.btnOnRunway.Name = "btnOnRunway";
            this.btnOnRunway.Size = new System.Drawing.Size(50, 50);
            this.btnOnRunway.TabIndex = 1;
            this.btnOnRunway.UseVisualStyleBackColor = false;
            this.btnOnRunway.Click += new System.EventHandler(this.btnOnRunway_click);
            // 
            // btnTechnicalInspection
            // 
            this.btnTechnicalInspection.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnTechnicalInspection.Image = global::SymulatorLotniska.Properties.Resources.kontrolatechniczna;
            this.btnTechnicalInspection.Location = new System.Drawing.Point(4, 59);
            this.btnTechnicalInspection.Name = "btnTechnicalInspection";
            this.btnTechnicalInspection.Size = new System.Drawing.Size(50, 50);
            this.btnTechnicalInspection.TabIndex = 2;
            this.btnTechnicalInspection.UseVisualStyleBackColor = false;
            this.btnTechnicalInspection.Click += new System.EventHandler(this.btnTechnicalInspection_click);
            // 
            // btnCancelOperation
            // 
            this.btnCancelOperation.BackColor = System.Drawing.Color.Pink;
            this.btnCancelOperation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelOperation.BackgroundImage")));
            this.btnCancelOperation.Location = new System.Drawing.Point(4, 3);
            this.btnCancelOperation.Name = "btnCancelOperation";
            this.btnCancelOperation.Size = new System.Drawing.Size(50, 50);
            this.btnCancelOperation.TabIndex = 3;
            this.btnCancelOperation.UseVisualStyleBackColor = false;
            this.btnCancelOperation.Click += new System.EventHandler(this.btnCancelOperation_click);
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
            this.btnStartowanie.Click += new System.EventHandler(this.btnTakeoff_click);
            // 
            // btnLand
            // 
            this.btnLand.BackColor = System.Drawing.Color.White;
            this.btnLand.Image = global::SymulatorLotniska.Properties.Resources.btnDol;
            this.btnLand.Location = new System.Drawing.Point(4, 3);
            this.btnLand.Name = "btnLand";
            this.btnLand.Size = new System.Drawing.Size(50, 50);
            this.btnLand.TabIndex = 14;
            this.btnLand.UseVisualStyleBackColor = false;
            this.btnLand.Click += new System.EventHandler(this.btnLand_click);
            // 
            // btnUnload
            // 
            this.btnUnload.BackColor = System.Drawing.Color.White;
            this.btnUnload.Image = global::SymulatorLotniska.Properties.Resources.btnDol;
            this.btnUnload.Location = new System.Drawing.Point(4, 3);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(50, 50);
            this.btnUnload.TabIndex = 16;
            this.btnUnload.UseVisualStyleBackColor = false;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // panelPrzyciskow
            // 
            this.panelPrzyciskow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPrzyciskow.Controls.Add(this.btnDelete);
            this.panelPrzyciskow.Controls.Add(this.btnUnload);
            this.panelPrzyciskow.Controls.Add(this.btnSendAway);
            this.panelPrzyciskow.Controls.Add(this.btnLand);
            this.panelPrzyciskow.Controls.Add(this.btnStartowanie);
            this.panelPrzyciskow.Controls.Add(this.btnToHangar);
            this.panelPrzyciskow.Controls.Add(this.btnCancelOperation);
            this.panelPrzyciskow.Controls.Add(this.btnTechnicalInspection);
            this.panelPrzyciskow.Controls.Add(this.btnOnRunway);
            this.panelPrzyciskow.Controls.Add(this.btnFuel);
            this.panelPrzyciskow.Location = new System.Drawing.Point(296, 46);
            this.panelPrzyciskow.Name = "panelPrzyciskow";
            this.panelPrzyciskow.Size = new System.Drawing.Size(59, 170);
            this.panelPrzyciskow.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::SymulatorLotniska.Properties.Resources.destroyed;
            this.btnDelete.Location = new System.Drawing.Point(4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 50);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnToHangar
            // 
            this.btnToHangar.BackColor = System.Drawing.Color.White;
            this.btnToHangar.Image = global::SymulatorLotniska.Properties.Resources.btnDoHangaru;
            this.btnToHangar.Location = new System.Drawing.Point(4, 59);
            this.btnToHangar.Name = "btnToHangar";
            this.btnToHangar.Size = new System.Drawing.Size(50, 50);
            this.btnToHangar.TabIndex = 5;
            this.btnToHangar.UseVisualStyleBackColor = false;
            this.btnToHangar.Click += new System.EventHandler(this.btnToHangar_click);
            // 
            // notificationListClear
            // 
            this.notificationListClear.BackColor = System.Drawing.Color.Bisque;
            this.notificationListClear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notificationListClear.Location = new System.Drawing.Point(522, 556);
            this.notificationListClear.Name = "notificationListClear";
            this.notificationListClear.Padding = new System.Windows.Forms.Padding(5);
            this.notificationListClear.Size = new System.Drawing.Size(241, 25);
            this.notificationListClear.TabIndex = 15;
            this.notificationListClear.Text = "Wyczyść listę";
            this.notificationListClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.notificationListClear.Click += new System.EventHandler(this.notificationListClear_Click);
            // 
            // switchOperationSingle
            // 
            this.switchOperationSingle.BackColor = System.Drawing.Color.Aquamarine;
            this.switchOperationSingle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.switchOperationSingle.Location = new System.Drawing.Point(146, 11);
            this.switchOperationSingle.Name = "switchOperationSingle";
            this.switchOperationSingle.Padding = new System.Windows.Forms.Padding(5);
            this.switchOperationSingle.Size = new System.Drawing.Size(95, 27);
            this.switchOperationSingle.TabIndex = 16;
            this.switchOperationSingle.Text = "Operacja";
            this.switchOperationSingle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.switchOperationSingle.Click += new System.EventHandler(this.switchOperationSingle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.switchOperationSingle);
            this.panel1.Controls.Add(this.switchAcceptingIncomingPlanes);
            this.panel1.Controls.Add(this.switchAssistant);
            this.panel1.Location = new System.Drawing.Point(522, 232);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 49);
            this.panel1.TabIndex = 17;
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 590);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.notificationListClear);
            this.Controls.Add(this.ammoPanel);
            this.Controls.Add(this.cargoPanel);
            this.Controls.Add(this.peoplePanel);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelSamolotyWPowietrzu);
            this.Controls.Add(this.panelPasStartowy2);
            this.Controls.Add(this.panelPasStartowy1);
            this.Controls.Add(this.panelInformacji);
            this.Controls.Add(this.panelSamolotow);
            this.Controls.Add(this.panelPrzyciskow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
            this.peoplePanel.ResumeLayout(false);
            this.peoplePanel.PerformLayout();
            this.cargoPanel.ResumeLayout(false);
            this.cargoPanel.PerformLayout();
            this.ammoPanel.ResumeLayout(false);
            this.ammoPanel.PerformLayout();
            this.panelPrzyciskow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // moj kod

        private System.Windows.Forms.Panel panelSamolotow;
        private System.Windows.Forms.Panel panelInformacji;
        private System.Windows.Forms.Label labelHangar;
        private System.Windows.Forms.Label labelInformacje;
        private System.Windows.Forms.Label labelTekstInformacje;
        private System.Windows.Forms.Panel panelSamolotyWPowietrzu;
        private Panel panelPasStartowy1;
        private Panel panelPasStartowy2;
        private Label labelSamolotyPowietrze;
        private Button btnDol;
        private Button btnGora;
        private Button btnPrawo;
        private Button btnLewo;
        private GroupBox groupBox1;
        private Button btnSendAway;
        private Button button6;
        private TextBox peopleCount;
        private Panel peoplePanel;
        private Panel cargoPanel;
        private TextBox cargoCount;
        private Panel ammoPanel;
        private TextBox ammoCount;
        private Label switchAcceptingIncomingPlanes;
        private Button btnFuel;
        private Button btnOnRunway;
        private Button btnTechnicalInspection;
        private Button btnCancelOperation;
        private Button btnStartowanie;
        private Button btnLand;
        private Button btnUnload;
        private Panel panelPrzyciskow;
        private Button btnToHangar;
        private Label notificationListClear;
        private Label switchOperationSingle;
        private Label switchAssistant;
        private Panel panel1;
        private Button btnDelete;
    }
}

