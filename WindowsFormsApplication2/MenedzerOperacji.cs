using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class MenedzerOperacji
    {
        private Timer timer;
        private ListaOperacji listaOperacji;
        public MenedzerOperacji(Lotnisko uchwytLotnisko)
        {
            timer = new Timer(); // moze trzeba dac argument
            timer.Tick += new EventHandler(onTimerTick);
            timer.Interval = 100;
            timer.Enabled = false; // timer ma sie właczać jak lista operacji nie jest pusta

            listaOperacji = new ListaOperacji(this);
        }
        public void dodajOperacje(IOperacja operacja)
        {
            listaOperacji.dodajOperacje(operacja);
        }

        public void zatrzymajOperacjeNaSamolocie(Samolot samolot)
        {
            listaOperacji.usunOperacjeNaSamolocie(listaOperacji.znajdzOperacjeNaSamolocie(samolot));
        }

        public void zatrzymajTimer()
        {
            timer.Enabled = false;
        }
        public void uruchomTimer()
        {
            timer.Enabled = true;
        }

        private void onTimerTick(object sender, EventArgs e)
        {
            //wykonanie metody dla kazdej operacji w liscie
            listaOperacji.wykonajLancuchOperacji();
        }

    }
}
