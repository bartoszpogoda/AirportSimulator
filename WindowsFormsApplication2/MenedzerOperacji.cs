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

            listaOperacji = new ListaOperacji();
        }

        private void wykonajLancuchOperacji()
        {
            if(listaOperacji.getPierwszy() == null)
            {
                zatrzymajTimer();
                return;
            }
            listaOperacji.getPierwszy().wykonajOperacje(listaOperacji);
        }

        public void dodajOperacje(IOperacja operacja)
        {
            listaOperacji.dodajElement(new ElementListyOperacji(operacja));
            uruchomTimer();
        }

        private ElementListyOperacji znajdz(IOperacja operacja)
        {
            listaOperacji.iteratorNaStart();
            if (listaOperacji.aktualnyPodIteratorem() == null) return null;
            if (listaOperacji.aktualnyPodIteratorem().operacja == operacja) return listaOperacji.aktualnyPodIteratorem();

            while (listaOperacji.iteratorMaNastepny())
            {
                if (listaOperacji.aktualnyPodIteratorem().operacja == operacja) return listaOperacji.aktualnyPodIteratorem();
            }
            return null;
        }
        private IOperacja znajdz(Samolot samolot)
        {
            listaOperacji.iteratorNaStart();
            if (listaOperacji.aktualnyPodIteratorem() == null) return null;
            if (listaOperacji.aktualnyPodIteratorem().operacja.getSamolot() == samolot) return listaOperacji.aktualnyPodIteratorem().operacja;

            while (listaOperacji.iteratorMaNastepny())
            {
                if (listaOperacji.aktualnyPodIteratorem().operacja.getSamolot() == samolot) return listaOperacji.aktualnyPodIteratorem().operacja;
            }
            return null;
        }

        public void zatrzymajOperacje(Samolot samolot)
        {
            IOperacja operacja = znajdz(samolot);
            zatrzymajOperacje(operacja);
        }
        public void zatrzymajOperacje(IOperacja operacja)
        {
            operacja.zatrzymaj();
            ElementListyOperacji element = znajdz(operacja);
            if(element != null) listaOperacji.usunElement(element);
            
        }


        public void zatrzymajTimer()
        {
            timer.Enabled = false;
            Console.WriteLine("Timer: Disabled"); // dbg
        }
        public void uruchomTimer()
        {
            timer.Enabled = true;
            Console.WriteLine("Timer: Enabled"); // dbg
        }

        private void onTimerTick(object sender, EventArgs e)
        {
            //wykonanie metody dla kazdej operacji w liscie
            wykonajLancuchOperacji();
        }

    }
}
