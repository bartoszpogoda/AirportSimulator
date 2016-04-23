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
            panelSamolotow.MouseWheel += new MouseEventHandler(menedzerSamolotow.mouseWheelEventHangar);
            panelSamolotyWPowietrzu.MouseWheel += new MouseEventHandler(menedzerSamolotow.mouseWheelEventPowietrze); // do zaprogramowania

            this.labelTekstInformacje.Parent = panelInformacji;
            this.labelTekstInformacje.AutoSize = false;
            this.labelTekstInformacje.Size = new System.Drawing.Size(labelTekstInformacje.Parent.Size.Width, this.labelTekstInformacje.Size.Height);

            this.labelWPowietrzu.Parent = panelSamolotyWPowietrzu;
            this.labelWPowietrzu.AutoSize = false;
            this.labelWPowietrzu.Size = new System.Drawing.Size(this.labelWPowietrzu.Size.Width, this.labelWPowietrzu.Parent.Size.Height);

            this.labelInformacje.Parent = panelInformacji;

            this.labelHangar.Parent = panelSamolotow;
            this.labelHangar.AutoSize = false;
            this.labelHangar.Size = new System.Drawing.Size(labelHangar.Parent.Size.Width, this.labelHangar.Size.Height);
        }
        public Panel getPanelSamolotowPowietrze() { return this.panelSamolotyWPowietrzu; }
        public Panel getPanelSamolotow() { return this.panelSamolotow;  }
        public Label getLabelInformacje() { return this.labelInformacje;  }

        public Label getTekstInformacje() { return this.labelTekstInformacje;  }
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

        private void labelSamolotyWPowietrzu_Click(object sender, EventArgs e)
        {

        }
    }
}
