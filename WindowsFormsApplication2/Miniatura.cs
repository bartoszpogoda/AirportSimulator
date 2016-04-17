using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class Miniatura : PictureBox
    {
        private string adresBazowy;
        protected MenedzerSamolotow uchwytMenedzerSamolotow;

        public Miniatura(string adresBazowy, MenedzerSamolotow uchwytMenedzerSamolotow) : base()
        {
            this.adresBazowy = adresBazowy;
            this.uchwytMenedzerSamolotow = uchwytMenedzerSamolotow;

            ImageLocation = adresBazowy + "s.png";
            Location = new Point(0, 0);
            Visible = false;
            Enabled = false;

            Parent = uchwytMenedzerSamolotow.getPanelSamolotow();
            Size = new Size(50, 50);

            Click += new EventHandler(miniaturkaOnClick);
            uchwytMenedzerSamolotow.getPanelSamolotow().Controls.Add(this);

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
            ImageLocation = adresBazowy + c + ".png";
        }

    }
}
