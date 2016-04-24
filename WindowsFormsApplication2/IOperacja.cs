using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public abstract class IOperacja
    {
       
        public abstract bool wykonajTick(); // zwraca false jezeli to bylo ostatnie wykonanie

        public abstract void zatrzymaj();

        public abstract Samolot getSamolot();

       

    }
}
