using System;
using System.Windows.Forms;
using System.Drawing;
using SymulatorLotniska.ZarzadzanieSamolotami;

namespace SymulatorLotniska.Samoloty
{
    public class Miniatura
    {
        private string adresBazowy;
        private PictureBox obrazekSamolotu;
        private PictureBox obrazekStanu;
        private Control aktualnyNaGorze;

        protected MenedzerSamolotow uchwytMenedzerSamolotow;

        public PictureBox getObrazekSamolotu() { return obrazekSamolotu; }
        
        public Control getAktualnyNaGorze() { return aktualnyNaGorze; }
   
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

            aktualnyNaGorze = obrazekSamolotu;
        }

        public void setParent(Control parent) // bedzie potrzebne przy zmianie z hangaru na pas i w powietrze itp
        {
            obrazekSamolotu.Parent.Controls.Remove(obrazekSamolotu);
            obrazekSamolotu.Parent = parent;
            if(parent != null) obrazekSamolotu.Parent.Controls.Add(obrazekSamolotu); // chyba tak
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
                aktualnyNaGorze = obrazekSamolotu;
            }
            else if (aktualnyStan == Stan.Zaladunek)
            {
                obrazekStanu.Image = (Image)Properties.Resources.ResourceManager.GetObject("zaladunek");
                obrazekStanu.Visible = true;
                obrazekStanu.Enabled = true;
                aktualnyNaGorze = obrazekStanu;
            }
            else if (aktualnyStan == Stan.KontrolaTechniczna)
            {
                obrazekStanu.Image = (Image)Properties.Resources.ResourceManager.GetObject(StaleKonfiguracyjne.adresKontrolaTechniczna);
                obrazekStanu.Visible = true;
                obrazekStanu.Enabled = true;
                aktualnyNaGorze = obrazekStanu;
            }
            else if (aktualnyStan == Stan.Tankowanie)
            {
                obrazekStanu.Image = (Image)Properties.Resources.ResourceManager.GetObject(StaleKonfiguracyjne.adresTankowanie);
                obrazekStanu.Visible = true;
                obrazekStanu.Enabled = true;
                aktualnyNaGorze = obrazekStanu;
            }
            else if (aktualnyStan == Stan.Startowanie)
            {
                obrazekStanu.Image = (Image)Properties.Resources.ResourceManager.GetObject("startowanie");
                obrazekStanu.Visible = true;
                obrazekStanu.Enabled = true;
                aktualnyNaGorze = obrazekStanu;
            }
            else // rozwiazanie błedu ze zniknaiem zaznacznia
            {
                obrazekStanu.Visible = false;
                obrazekStanu.Enabled = false;
                aktualnyNaGorze = obrazekSamolotu;
            }

            uchwytMenedzerSamolotow.narysujSamolotyZListy();
            uchwytMenedzerSamolotow.narysujSamolotyZListyPowietrze();

        }

    }
}
