using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication2
{
    public class Miniatura
    {
        private string adresBazowy;
        private PictureBox obrazekSamolotu;
        private PictureBox obrazekStanu;
        private Control aktualnyNaGorze;

        protected MenedzerSamolotow uchwytMenedzerSamolotow;

        public PictureBox ObrazekSamolotu
        {
            get
            {
                return obrazekSamolotu;
            }

            set
            {
                obrazekSamolotu = value;
            }
        }

        public PictureBox NakladkaStanu
        {
            get
            {
                return obrazekStanu;
            }

            set
            {
                obrazekStanu = value;
            }
        }

        public Control AktualnyNaGorze
        {
            get
            {
                return aktualnyNaGorze;
            }
        }

        public Miniatura()
        {

        }
        public Miniatura(string adresBazowy, MenedzerSamolotow uchwytMenedzerSamolotow, Control parent)
        {
            this.adresBazowy = adresBazowy;
            this.uchwytMenedzerSamolotow = uchwytMenedzerSamolotow;

            obrazekSamolotu = new PictureBox();
            obrazekStanu = new PictureBox();


            obrazekSamolotu.Image = (Image)Properties.Resources.ResourceManager.GetObject(adresBazowy);

            // ImageLocation = adresBazowy + "s.png"; 
            obrazekSamolotu.Location = new Point(0, 0);
            obrazekSamolotu.Visible = false;
            obrazekSamolotu.Enabled = false;

            obrazekSamolotu.Parent = parent;
            obrazekSamolotu.Size = new Size(50, 50);

            obrazekSamolotu.Click += new EventHandler(miniaturkaOnClick);
            parent.Controls.Add(obrazekSamolotu);


            obrazekStanu.Location = new Point(0, 0);
            obrazekStanu.Visible = false;
            obrazekStanu.Enabled = false;
            obrazekStanu.BackColor = Color.Transparent;
            obrazekStanu.Click += new EventHandler(miniaturkaOnClick);

            obrazekStanu.Parent = obrazekSamolotu;
            obrazekStanu.Size = new Size(50, 50);

            obrazekSamolotu.Controls.Add(obrazekStanu);

            aktualnyNaGorze = ObrazekSamolotu;
        }

        public void setParent(Control parent)
        {
            obrazekSamolotu.Parent.Controls.Remove(obrazekSamolotu);
            obrazekSamolotu.Parent = parent;
            obrazekSamolotu.Parent.Controls.Add(obrazekSamolotu); // chyba tak
        }

        private void miniaturkaOnClick(object sender, EventArgs e)
        {
            uchwytMenedzerSamolotow.zaznaczSamolot(this);
        }

        public void pokaz()
        {
            obrazekSamolotu.Visible = true;
            obrazekSamolotu.Enabled = true;
        }

        public void schowaj()
        {
            obrazekSamolotu.Visible = false;
            obrazekSamolotu.Enabled = false;
        }

        public bool czyJestPokazany()
        {
            return obrazekSamolotu.Visible;
        }

        public void ustawNakladke(Stan aktualnyStan)
        {
            if (aktualnyStan == Stan.Hangar)
            {
                obrazekStanu.Visible = false;
                obrazekStanu.Enabled = false;
                aktualnyNaGorze = ObrazekSamolotu;
            }
            else if (aktualnyStan == Stan.Zaladunek)
            {
                obrazekStanu.Image = (Image)Properties.Resources.ResourceManager.GetObject("zaladunek");
                obrazekStanu.Visible = true;
                obrazekStanu.Enabled = true;
                aktualnyNaGorze = NakladkaStanu;
            }
            else if (aktualnyStan == Stan.KontrolaTechniczna)
            {
                obrazekStanu.Image = (Image)Properties.Resources.ResourceManager.GetObject("kontrolatechniczna");
                obrazekStanu.Visible = true;
                obrazekStanu.Enabled = true;
                aktualnyNaGorze = NakladkaStanu;
            }
            else if (aktualnyStan == Stan.Tankowanie)
            {
                obrazekStanu.Image = (Image)Properties.Resources.ResourceManager.GetObject("tankowanie");
                obrazekStanu.Visible = true;
                obrazekStanu.Enabled = true;
                aktualnyNaGorze = NakladkaStanu;
            }
            else if (aktualnyStan == Stan.Startowanie)
            {
                obrazekStanu.Image = (Image)Properties.Resources.ResourceManager.GetObject("startowanie");
                obrazekStanu.Visible = true;
                obrazekStanu.Enabled = true;
                aktualnyNaGorze = NakladkaStanu;
            }

            uchwytMenedzerSamolotow.narysujSamolotyZListy();
            uchwytMenedzerSamolotow.narysujSamolotyZListyPowietrze();

        }

    }
}
