﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SymulatorLotniska.ZarzadzaniePowiadomieniami
{
    // ToDo: Powiadomienie raczej stanie sie interfejsem, (ew klasa abstrakcyjna)
    // i stworzym konkretne implementacje tej klasy np PowiadomienieZajeciePasaStartowego itp. ale w sumie nie wiem
    // troche dlugie te nazwy kappa a nie ma takiej potrzeby raczej 

    // Panel bedize koloru w zaleznosci od charakteru komunikatu np czerwone jak sie cos spierniczy
    public class Powiadomienie
    {
        Label textBox;
        Panel panel;
        MenedzerPowiadomien uchwytMenedzerPowiadomien;
        public Powiadomienie(MenedzerPowiadomien uchwytMenedzerPowiadomien, String komunikat, CharakterPowiadomienia charakter)
        {

            panel = new Panel();
            textBox = new Label();
            schowaj();

            this.uchwytMenedzerPowiadomien = uchwytMenedzerPowiadomien;

            panel.BackColor = SystemColors.ControlLightLight;
            panel.BorderStyle = BorderStyle.FixedSingle;


            panel.Controls.Add(textBox);
            panel.Location = new Point(0, 0);

            textBox.BorderStyle = BorderStyle.None;
            textBox.Location = new Point(3, 3);
            //textBox.Size = new Size(151, 40);
            textBox.MaximumSize = new Size(StaleKonfiguracyjne.powiadomienieX, 0);
            textBox.AutoSize = true;
            textBox.Text = komunikat;

            panel.Size = new Size(StaleKonfiguracyjne.powiadomienieX, textBox.Size.Height+6);

            panel.Parent = uchwytMenedzerPowiadomien.getPanel();
            panel.Click += onClick;
            textBox.Click += onClick;
            


        }

        public void schowaj()
        {
            panel.Visible = false;
            panel.Enabled = false;

            textBox.Visible = false;
            textBox.Enabled = false;
        }

        private void onClick(object sender, EventArgs e)
        {
            usun();
            uchwytMenedzerPowiadomien.usunPowiadomienie(this);
        }

        public void pokazXY(int x, int y) // zwraca wysokosc jednak nei
        {
            panel.Location = new Point(x, y);

            panel.Visible = true;
            panel.Enabled = true;

            textBox.Visible = true;
            textBox.Enabled = true;
            
        }

        public int getWysokosc() { return panel.Size.Height; }
        
        public void usun()
        {

            panel.Visible = false;
            panel.Enabled = false;

            textBox.Visible = false;
            textBox.Enabled = false;

            textBox.Parent.Controls.Remove(textBox);
            panel.Parent.Controls.Remove(panel);

        }

    }
}
