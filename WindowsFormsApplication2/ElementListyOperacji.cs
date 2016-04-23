using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class ElementListyOperacji
    {
        public IOperacja operacja;
        public ElementListyOperacji nastepnyElement;
        public ElementListyOperacji poprzedniElement;

        public ElementListyOperacji(IOperacja operacja)
        {
            this.operacja = operacja;
            nastepnyElement = null;
            poprzedniElement = null;
            //tekts
        }

        public void wykonajOperacje(ListaOperacji uchwytListaOperacji) 
        {
            if(!operacja.wykonajTick())
            {
                if (poprzedniElement == null && nastepnyElement == null)
                {
                    // to był ostatni
                    uchwytListaOperacji.setPierwszy(null);
                    uchwytListaOperacji.setOstatni(null);
                }
                else if (poprzedniElement == null)
                {
                    uchwytListaOperacji.setPierwszy(nastepnyElement);
                    nastepnyElement.poprzedniElement = null;
                }
                else if(nastepnyElement == null)
                {
                    poprzedniElement.nastepnyElement = null; // bedzie dzialac nawet dla nulla
                    uchwytListaOperacji.setOstatni(poprzedniElement);
                }
                else
                {
                    poprzedniElement.nastepnyElement = nastepnyElement;
                    nastepnyElement.poprzedniElement = poprzedniElement;
                }
            }

            if(nastepnyElement != null) nastepnyElement.wykonajOperacje(uchwytListaOperacji);
        }
    }
}
