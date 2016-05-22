using System;
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
    
    public class Powiadomienie
    {
        Label textBox;
        Panel panel;
        CharakterPowiadomienia charakterPowiadomienia;
        public Powiadomienie(String komunikat, CharakterPowiadomienia charakter)
        {
            textBox = new Label();
            textBox.BorderStyle = BorderStyle.None;
            textBox.Location = new Point(3, 3);
            textBox.MaximumSize = new Size(StaleKonfiguracyjne.powiadomienieX, 0);
            textBox.AutoSize = true;
            textBox.Text = komunikat + "\n" + DateTime.Now.ToString
                ("                                    HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            textBox.Click += onClick;


            panel = new Panel();
            schowaj();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(textBox);
            panel.Size = new Size(StaleKonfiguracyjne.powiadomienieX, textBox.Size.Height+6);
            panel.Parent = MenedzerPowiadomien.getInstance().getPanel();
            panel.Click += onClick;
            this.charakterPowiadomienia = charakter;
        }
        public int getWysokosc() { return panel.Size.Height; }

        /// <summary>
        /// ukrywa panel powiadomienia
        /// </summary>
        public void schowaj()
        {
            panel.Visible = false;
            panel.Enabled = false;
        }

        private void onClick(object sender, EventArgs e) 
        {
            usun();
            MenedzerPowiadomien.getInstance().usunPowiadomienie(this);
        }

        /// <summary>
        /// pokazuje powiadomienie w okreslonym miejscu
        /// </summary> 
        public void pokaz(Point pozycja) 
        {
            panel.Location = pozycja;
            
            switch (charakterPowiadomienia)
            {
                    case CharakterPowiadomienia.Zwykle:
                        panel.BackColor = Color.White;
                        break;
                    case CharakterPowiadomienia.Pozytywne:
                        panel.BackColor = Color.FromArgb(162,252,140);
                        break;
                    case CharakterPowiadomienia.Negatywne:
                        panel.BackColor = Color.FromArgb(252, 113, 113);
                        break;
            }

            panel.Visible = true;
            panel.Enabled = true;
        }

       
        
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
