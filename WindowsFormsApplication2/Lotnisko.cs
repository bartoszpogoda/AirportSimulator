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
            menedzerSamolotow = new MenedzerSamolotow(this);
            menedzerOperacji = new MenedzerOperacji(this);
           
            
        }

        public System.ComponentModel.IContainer getComponents()
        {
            return components;
        }


        private void scrollEvent(object sender, EventArgs e) {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Write("OMG");
            menedzerSamolotow.dbgDodajSamolot();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            menedzerOperacji.dodajOperacje(new OperacjaTankowanie((Samolot)menedzerSamolotow.getZaznaczony()));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
