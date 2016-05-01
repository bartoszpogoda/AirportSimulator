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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelSamolotow = new System.Windows.Forms.Panel();
            this.panelInformacji = new System.Windows.Forms.Panel();
            this.pasekPostepu = new System.Windows.Forms.ProgressBar();
            this.panelSamolotyWPowietrzu = new System.Windows.Forms.Panel();
            this.labelHangar = new System.Windows.Forms.Label();
            this.labelInformacje = new System.Windows.Forms.Label();
            this.labelTekstInformacje = new System.Windows.Forms.Label();
            this.labelWPowietrzu = new System.Windows.Forms.Label();
            this.panelPrzyciskow = new System.Windows.Forms.Panel();
            this.wyprowadzLudzi = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.wprowadzenieLudzi = new System.Windows.Forms.Button();
            this.doHangaru = new System.Windows.Forms.Button();
            this.wyladuj = new System.Windows.Forms.Button();
            this.operationCancel = new System.Windows.Forms.Button();
            this.kontrola = new System.Windows.Forms.Button();
            this.naPasStartowy = new System.Windows.Forms.Button();
            this.tankowanie = new System.Windows.Forms.Button();
            this.panelPasStartowy1 = new System.Windows.Forms.Panel();
            this.panelPasStartowy2 = new System.Windows.Forms.Panel();
            this.odeslij = new System.Windows.Forms.Button();
            this.panelInformacji.SuspendLayout();
            this.panelPrzyciskow.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelSamolotow
            // 
            this.panelSamolotow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelSamolotow.Location = new System.Drawing.Point(10, 15);
            this.panelSamolotow.Name = "panelSamolotow";
            this.panelSamolotow.Size = new System.Drawing.Size(250, 200);
            this.panelSamolotow.TabIndex = 0;
            // 
            // panelInformacji
            // 
            this.panelInformacji.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panelInformacji.Controls.Add(this.pasekPostepu);
            this.panelInformacji.Location = new System.Drawing.Point(270, 5);
            this.panelInformacji.Name = "panelInformacji";
            this.panelInformacji.Size = new System.Drawing.Size(200, 210);
            this.panelInformacji.TabIndex = 0;
            // 
            // pasekPostepu
            // 
            this.pasekPostepu.BackColor = System.Drawing.Color.Gold;
            this.pasekPostepu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pasekPostepu.Location = new System.Drawing.Point(3, 190);
            this.pasekPostepu.Name = "pasekPostepu";
            this.pasekPostepu.Size = new System.Drawing.Size(194, 17);
            this.pasekPostepu.TabIndex = 0;
            // 
            // panelSamolotyWPowietrzu
            // 
            this.panelSamolotyWPowietrzu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelSamolotyWPowietrzu.Location = new System.Drawing.Point(485, 0);
            this.panelSamolotyWPowietrzu.Name = "panelSamolotyWPowietrzu";
            this.panelSamolotyWPowietrzu.Size = new System.Drawing.Size(111, 498);
            this.panelSamolotyWPowietrzu.TabIndex = 0;
            // 
            // labelHangar
            // 
            this.labelHangar.AutoSize = true;
            this.labelHangar.BackColor = System.Drawing.Color.LightSlateGray;
            this.labelHangar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHangar.ForeColor = System.Drawing.Color.White;
            this.labelHangar.Location = new System.Drawing.Point(0, 0);
            this.labelHangar.Name = "labelHangar";
            this.labelHangar.Size = new System.Drawing.Size(155, 18);
            this.labelHangar.TabIndex = 0;
            this.labelHangar.Text = "Samoloty w hangarze:";
            // 
            // labelInformacje
            // 
            this.labelInformacje.AutoSize = true;
            this.labelInformacje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInformacje.ForeColor = System.Drawing.Color.Black;
            this.labelInformacje.Location = new System.Drawing.Point(0, 20);
            this.labelInformacje.Name = "labelInformacje";
            this.labelInformacje.Size = new System.Drawing.Size(120, 18);
            this.labelInformacje.TabIndex = 0;
            this.labelInformacje.Text = "Wybierz samolot";
            // 
            // labelTekstInformacje
            // 
            this.labelTekstInformacje.AutoSize = true;
            this.labelTekstInformacje.BackColor = System.Drawing.Color.Khaki;
            this.labelTekstInformacje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTekstInformacje.ForeColor = System.Drawing.Color.Black;
            this.labelTekstInformacje.Location = new System.Drawing.Point(0, 0);
            this.labelTekstInformacje.Name = "labelTekstInformacje";
            this.labelTekstInformacje.Size = new System.Drawing.Size(167, 18);
            this.labelTekstInformacje.TabIndex = 0;
            this.labelTekstInformacje.Text = "Informacje o samolocie:";
            // 
            // labelWPowietrzu
            // 
            this.labelWPowietrzu.AutoSize = true;
            this.labelWPowietrzu.BackColor = System.Drawing.Color.LightSeaGreen;
            this.labelWPowietrzu.Location = new System.Drawing.Point(0, 0);
            this.labelWPowietrzu.Name = "labelWPowietrzu";
            this.labelWPowietrzu.Size = new System.Drawing.Size(18, 143);
            this.labelWPowietrzu.TabIndex = 3;
            this.labelWPowietrzu.Text = "W\n\nP\nO\nW\nI\nE\nT\nR\nZ\nU";
            this.labelWPowietrzu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPrzyciskow
            // 
            this.panelPrzyciskow.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panelPrzyciskow.Controls.Add(this.odeslij);
            this.panelPrzyciskow.Controls.Add(this.wyprowadzLudzi);
            this.panelPrzyciskow.Controls.Add(this.start);
            this.panelPrzyciskow.Controls.Add(this.wprowadzenieLudzi);
            this.panelPrzyciskow.Controls.Add(this.doHangaru);
            this.panelPrzyciskow.Controls.Add(this.wyladuj);
            this.panelPrzyciskow.Controls.Add(this.operationCancel);
            this.panelPrzyciskow.Controls.Add(this.kontrola);
            this.panelPrzyciskow.Controls.Add(this.naPasStartowy);
            this.panelPrzyciskow.Controls.Add(this.tankowanie);
            this.panelPrzyciskow.Location = new System.Drawing.Point(270, 213);
            this.panelPrzyciskow.Name = "panelPrzyciskow";
            this.panelPrzyciskow.Size = new System.Drawing.Size(200, 73);
            this.panelPrzyciskow.TabIndex = 0;
            // 
            // wyprowadzLudzi
            // 
            this.wyprowadzLudzi.BackColor = System.Drawing.Color.Beige;
            this.wyprowadzLudzi.Location = new System.Drawing.Point(108, 37);
            this.wyprowadzLudzi.Name = "wyprowadzLudzi";
            this.wyprowadzLudzi.Size = new System.Drawing.Size(75, 23);
            this.wyprowadzLudzi.TabIndex = 9;
            this.wyprowadzLudzi.Text = "Wyprowadz ludzi";
            this.wyprowadzLudzi.UseVisualStyleBackColor = false;
            this.wyprowadzLudzi.Click += new System.EventHandler(this.button3_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Beige;
            this.start.Location = new System.Drawing.Point(108, 8);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 8;
            this.start.Text = "Startuj";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.button6_Click);
            // 
            // wprowadzenieLudzi
            // 
            this.wprowadzenieLudzi.BackColor = System.Drawing.Color.Beige;
            this.wprowadzenieLudzi.Location = new System.Drawing.Point(13, 37);
            this.wprowadzenieLudzi.Name = "wprowadzenieLudzi";
            this.wprowadzenieLudzi.Size = new System.Drawing.Size(75, 23);
            this.wprowadzenieLudzi.TabIndex = 6;
            this.wprowadzenieLudzi.Text = "Wprowadz ludzi";
            this.wprowadzenieLudzi.UseVisualStyleBackColor = false;
            // 
            // doHangaru
            // 
            this.doHangaru.BackColor = System.Drawing.Color.Beige;
            this.doHangaru.Location = new System.Drawing.Point(13, 8);
            this.doHangaru.Name = "doHangaru";
            this.doHangaru.Size = new System.Drawing.Size(75, 23);
            this.doHangaru.TabIndex = 5;
            this.doHangaru.Text = "Do hangaru";
            this.doHangaru.UseVisualStyleBackColor = false;
            // 
            // wyladuj
            // 
            this.wyladuj.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.wyladuj.Location = new System.Drawing.Point(13, 37);
            this.wyladuj.Name = "wyladuj";
            this.wyladuj.Size = new System.Drawing.Size(170, 23);
            this.wyladuj.TabIndex = 4;
            this.wyladuj.Text = "Wyląduj";
            this.wyladuj.UseVisualStyleBackColor = false;
            this.wyladuj.Click += new System.EventHandler(this.wyladuj_Click);
            // 
            // operationCancel
            // 
            this.operationCancel.Location = new System.Drawing.Point(13, 24);
            this.operationCancel.Name = "operationCancel";
            this.operationCancel.Size = new System.Drawing.Size(170, 23);
            this.operationCancel.TabIndex = 3;
            this.operationCancel.Text = "Zatrzymaj tankowanie";
            this.operationCancel.UseVisualStyleBackColor = true;
            this.operationCancel.Click += new System.EventHandler(this.tankowanieCancel_Click);
            // 
            // kontrola
            // 
            this.kontrola.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.kontrola.Location = new System.Drawing.Point(108, 8);
            this.kontrola.Name = "kontrola";
            this.kontrola.Size = new System.Drawing.Size(75, 23);
            this.kontrola.TabIndex = 2;
            this.kontrola.Text = "Kontrola";
            this.kontrola.UseVisualStyleBackColor = false;
            this.kontrola.Click += new System.EventHandler(this.kontrola_Click);
            // 
            // naPasStartowy
            // 
            this.naPasStartowy.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.naPasStartowy.Location = new System.Drawing.Point(13, 37);
            this.naPasStartowy.Name = "naPasStartowy";
            this.naPasStartowy.Size = new System.Drawing.Size(170, 23);
            this.naPasStartowy.TabIndex = 1;
            this.naPasStartowy.Text = "Na pas startowy";
            this.naPasStartowy.UseVisualStyleBackColor = false;
            this.naPasStartowy.Click += new System.EventHandler(this.naPasStartowy_Click);
            // 
            // tankowanie
            // 
            this.tankowanie.BackColor = System.Drawing.Color.Beige;
            this.tankowanie.Location = new System.Drawing.Point(13, 8);
            this.tankowanie.Name = "tankowanie";
            this.tankowanie.Size = new System.Drawing.Size(75, 23);
            this.tankowanie.TabIndex = 0;
            this.tankowanie.Text = "Tankuj";
            this.tankowanie.UseVisualStyleBackColor = false;
            this.tankowanie.Click += new System.EventHandler(this.tankowanie_Click);
            // 
            // panelPasStartowy1
            // 
            this.panelPasStartowy1.BackColor = System.Drawing.Color.AliceBlue;
            this.panelPasStartowy1.Location = new System.Drawing.Point(0, 292);
            this.panelPasStartowy1.Name = "panelPasStartowy1";
            this.panelPasStartowy1.Size = new System.Drawing.Size(479, 100);
            this.panelPasStartowy1.TabIndex = 4;
            // 
            // panelPasStartowy2
            // 
            this.panelPasStartowy2.BackColor = System.Drawing.Color.AliceBlue;
            this.panelPasStartowy2.Location = new System.Drawing.Point(0, 398);
            this.panelPasStartowy2.Name = "panelPasStartowy2";
            this.panelPasStartowy2.Size = new System.Drawing.Size(479, 100);
            this.panelPasStartowy2.TabIndex = 5;
            // 
            // odeslij
            // 
            this.odeslij.BackColor = System.Drawing.Color.Beige;
            this.odeslij.Location = new System.Drawing.Point(13, 8);
            this.odeslij.Name = "odeslij";
            this.odeslij.Size = new System.Drawing.Size(75, 23);
            this.odeslij.TabIndex = 10;
            this.odeslij.Text = "Odeślij";
            this.odeslij.UseVisualStyleBackColor = false;
            this.odeslij.Click += new System.EventHandler(this.odeslij_Click);
            // 
            // OknoAplikacji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 502);
            this.Controls.Add(this.panelSamolotyWPowietrzu);
            this.Controls.Add(this.panelPasStartowy2);
            this.Controls.Add(this.panelPasStartowy1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelWPowietrzu);
            this.Controls.Add(this.labelInformacje);
            this.Controls.Add(this.labelHangar);
            this.Controls.Add(this.panelInformacji);
            this.Controls.Add(this.panelSamolotow);
            this.Controls.Add(this.panelPrzyciskow);
            this.Controls.Add(this.labelTekstInformacje);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OknoAplikacji";
            this.Text = "Symulator Lotniska v: -0.001";
            this.panelInformacji.ResumeLayout(false);
            this.panelPrzyciskow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label labelWPowietrzu;
        private Button kontrola;
        private Button naPasStartowy;
        private Button tankowanie;
        private Button operationCancel;
        private ProgressBar pasekPostepu;
        private Panel panelPasStartowy1;
        private Panel panelPasStartowy2;
        private Button wyladuj;
        private Button start;
        private Button wprowadzenieLudzi;
        private Button doHangaru;
        private Button wyprowadzLudzi;
        private Button odeslij;
    }
}

