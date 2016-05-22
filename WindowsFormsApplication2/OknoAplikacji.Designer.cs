using System;
using System.Drawing;
using System.Windows.Forms;

namespace SymulatorLotniska
{
    partial class OknoAplikacji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OknoAplikacji));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelSamolotow = new System.Windows.Forms.Panel();
            this.btnGora = new System.Windows.Forms.Button();
            this.btnDol = new System.Windows.Forms.Button();
            this.labelHangar = new System.Windows.Forms.Label();
            this.panelInformacji = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.labelTekstInformacje = new System.Windows.Forms.Label();
            this.labelInformacje = new System.Windows.Forms.Label();
            this.panelSamolotyWPowietrzu = new System.Windows.Forms.Panel();
            this.btnPrawo = new System.Windows.Forms.Button();
            this.btnLewo = new System.Windows.Forms.Button();
            this.labelSamolotyPowietrze = new System.Windows.Forms.Label();
            this.panelPrzyciskow = new System.Windows.Forms.Panel();
            this.btnM5C = new System.Windows.Forms.Button();
            this.btnM1C = new System.Windows.Forms.Button();
            this.btnD5C = new System.Windows.Forms.Button();
            this.odeslij = new System.Windows.Forms.Button();
            this.btnStartowanie = new System.Windows.Forms.Button();
            this.btnD1C = new System.Windows.Forms.Button();
            this.doHangaru = new System.Windows.Forms.Button();
            this.wyladuj = new System.Windows.Forms.Button();
            this.operationCancel = new System.Windows.Forms.Button();
            this.kontrola = new System.Windows.Forms.Button();
            this.naPasStartowy = new System.Windows.Forms.Button();
            this.tankowanie = new System.Windows.Forms.Button();
            this.panelPasStartowy1 = new System.Windows.Forms.Panel();
            this.panelPasStartowy2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panelSamolotow.SuspendLayout();
            this.panelInformacji.SuspendLayout();
            this.panelSamolotyWPowietrzu.SuspendLayout();
            this.panelPrzyciskow.SuspendLayout();
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
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
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
            this.labelSamolotyPowietrze.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panelPrzyciskow
            // 
            this.panelPrzyciskow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPrzyciskow.Controls.Add(this.btnM5C);
            this.panelPrzyciskow.Controls.Add(this.btnM1C);
            this.panelPrzyciskow.Controls.Add(this.btnD5C);
            this.panelPrzyciskow.Controls.Add(this.odeslij);
            this.panelPrzyciskow.Controls.Add(this.btnStartowanie);
            this.panelPrzyciskow.Controls.Add(this.btnD1C);
            this.panelPrzyciskow.Controls.Add(this.doHangaru);
            this.panelPrzyciskow.Controls.Add(this.wyladuj);
            this.panelPrzyciskow.Controls.Add(this.operationCancel);
            this.panelPrzyciskow.Controls.Add(this.kontrola);
            this.panelPrzyciskow.Controls.Add(this.naPasStartowy);
            this.panelPrzyciskow.Controls.Add(this.tankowanie);
            this.panelPrzyciskow.Location = new System.Drawing.Point(293, 33);
            this.panelPrzyciskow.Name = "panelPrzyciskow";
            this.panelPrzyciskow.Size = new System.Drawing.Size(113, 170);
            this.panelPrzyciskow.TabIndex = 0;
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
            this.btnD5C.Location = new System.Drawing.Point(3, 59);
            this.btnD5C.Name = "btnD5C";
            this.btnD5C.Size = new System.Drawing.Size(50, 50);
            this.btnD5C.TabIndex = 11;
            this.btnD5C.UseVisualStyleBackColor = false;
            this.btnD5C.Click += new System.EventHandler(this.btnD5C_Click);
            // 
            // odeslij
            // 
            this.odeslij.BackColor = System.Drawing.Color.White;
            this.odeslij.Location = new System.Drawing.Point(38, 113);
            this.odeslij.Name = "odeslij";
            this.odeslij.Size = new System.Drawing.Size(75, 23);
            this.odeslij.TabIndex = 10;
            this.odeslij.Text = "Odeślij";
            this.odeslij.UseVisualStyleBackColor = false;
            this.odeslij.Click += new System.EventHandler(this.odeslij_Click);
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
            this.btnD1C.Location = new System.Drawing.Point(3, 3);
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
            // wyladuj
            // 
            this.wyladuj.BackColor = System.Drawing.Color.White;
            this.wyladuj.Location = new System.Drawing.Point(41, 142);
            this.wyladuj.Name = "wyladuj";
            this.wyladuj.Size = new System.Drawing.Size(68, 23);
            this.wyladuj.TabIndex = 4;
            this.wyladuj.Text = "Wyląduj";
            this.wyladuj.UseVisualStyleBackColor = false;
            this.wyladuj.Click += new System.EventHandler(this.wyladuj_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(521, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 286);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Centrum powiadomien";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            // OknoAplikacji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 545);
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
            this.Name = "OknoAplikacji";
            this.Text = "Symulator Lotniska v: -0.001";
            this.panelSamolotow.ResumeLayout(false);
            this.panelSamolotow.PerformLayout();
            this.panelInformacji.ResumeLayout(false);
            this.panelInformacji.PerformLayout();
            this.panelSamolotyWPowietrzu.ResumeLayout(false);
            this.panelSamolotyWPowietrzu.PerformLayout();
            this.panelPrzyciskow.ResumeLayout(false);
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
        private Button wyladuj;
        private Button btnStartowanie;
        private Button btnD1C;
        private Button doHangaru;
        private Button odeslij;
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
    }
}

