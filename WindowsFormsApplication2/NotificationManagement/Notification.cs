using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SymulatorLotniska.NotificationManagement
{
    // ToDo: Powiadomienie raczej stanie sie interfejsem, (ew klasa abstrakcyjna)
    // i stworzym konkretne implementacje tej klasy np PowiadomienieZajeciePasaStartowego itp. ale w sumie nie wiem
    // troche dlugie te nazwy kappa a nie ma takiej potrzeby raczej 
    
    public class Notification
    {
        Label textBox;
        Panel panel;
        NotificationType notificationType;
        public Notification(String text, NotificationType notificationType)
        {
            textBox = new Label();
            textBox.BorderStyle = BorderStyle.None;
            textBox.Location = new Point(3, 3);
            textBox.MaximumSize = new Size(ConfigurationConstants.powiadomienieX, 0);
            textBox.AutoSize = true;
            textBox.Text = text + "\n" + DateTime.Now.ToString
                ("                                    HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            textBox.Click += onClick;


            panel = new Panel();
            hide();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(textBox);
            panel.Size = new Size(ConfigurationConstants.powiadomienieX, textBox.Size.Height+6);
            panel.Parent = NotificationManager.getInstance().getPanel();
            panel.Click += onClick;
            this.notificationType = notificationType;
        }
        public int getHeight() { return panel.Size.Height; }

        /// <summary>
        /// ukrywa panel powiadomienia
        /// </summary>
        public void hide()
        {
            panel.Visible = false;
            panel.Enabled = false;
        }

        private void onClick(object sender, EventArgs e) 
        {
            remove();
            NotificationManager.getInstance().removeNotification(this);
        }

        /// <summary>
        /// pokazuje powiadomienie w okreslonym miejscu
        /// </summary> 
        public void show(Point pozycja) 
        {
            panel.Location = pozycja;
            
            switch (notificationType)
            {
                    case NotificationType.Normal:
                        panel.BackColor = Color.White;
                        break;
                    case NotificationType.Positive:
                        panel.BackColor = Color.FromArgb(162,252,140);
                        break;
                    case NotificationType.Negative:
                        panel.BackColor = Color.FromArgb(252, 113, 113);
                        break;
            }

            panel.Visible = true;
            panel.Enabled = true;
        }

        public void remove()
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
