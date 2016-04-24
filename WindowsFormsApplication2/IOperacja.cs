using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public abstract class IOperacja
    {
        protected Samolot samolot; // dotyczy samolotu
        protected int pamiec;
        protected Object pamiec2;
        public abstract bool wykonajTick(); // zwraca false jezeli to bylo ostatnie wykonanie

        public abstract void zatrzymaj();

        public Samolot getSamolot() { return samolot;  }

        public IOperacja(Samolot samolot, int pamiec, Object pamiec2)
        {
            this.samolot = samolot;
            this.pamiec = pamiec;
            this.pamiec2 = pamiec2;
        }
        public IOperacja(Samolot samolot, int pamiec)
        {
            this.samolot = samolot;
            this.pamiec = pamiec;
            this.pamiec2 = null;
        }

    }
}
