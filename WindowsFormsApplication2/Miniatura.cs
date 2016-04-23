using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class Miniatura : PictureBox
    {
        private string adresBazowy;

        protected MenedzerSamolotow uchwytMenedzerSamolotow;

        public Miniatura(string adresBazowy, MenedzerSamolotow uchwytMenedzerSamolotow, Control parent) : base()
        {
            this.adresBazowy = adresBazowy;
            this.uchwytMenedzerSamolotow = uchwytMenedzerSamolotow;

            Image = (Image)Properties.Resources.ResourceManager.GetObject(adresBazowy + "s");

           // ImageLocation = adresBazowy + "s.png"; 
            Location = new Point(0, 0);
            Visible = false;
            Enabled = false;

            Parent = parent;
            Size = new Size(50, 50);

            Click += new EventHandler(miniaturkaOnClick);
            parent.Controls.Add(this);

        }

        public void setParent(Control parent)
        {
            Parent.Controls.Remove(this);
            Parent = parent;
            Parent.Controls.Add(this); // chyba tak
        }

        private void miniaturkaOnClick(object sender, EventArgs e)
        {
            uchwytMenedzerSamolotow.zaznaczSamolot(this);
        }

        public void pokaz()
        {
            Visible = true;
            Enabled = true;
        }

        public void schowaj()
        {
            Visible = false;
            Enabled = false;
        }

        public bool czyJestPokazany()
        {
            return Visible;
        }

        public void ustawGrafike(char c)
        {
            Image = (Image)Properties.Resources.ResourceManager.GetObject(adresBazowy + c);
        }

    }
}
