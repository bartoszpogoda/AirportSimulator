using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Lotnisko : Form
    {
        private MenedzerSamolotow menedzerSamolotow;
        private MenedzerOperacji menedzerOperacji;

        public Lotnisko()
        {
            InitializeComponent();  
            menedzerOperacji = new MenedzerOperacji(this);
            menedzerSamolotow = new MenedzerSamolotow(this, menedzerOperacji);


        }

        public System.ComponentModel.IContainer getComponents()
        {
            return components;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.dbgDodajSamolot(0);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            menedzerOperacji.dodajOperacje(new OperacjaTankowanie((Samolot)menedzerSamolotow.getZaznaczony()));
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            menedzerSamolotow.dbgDodajSamolot(1);
        }
    }
}
