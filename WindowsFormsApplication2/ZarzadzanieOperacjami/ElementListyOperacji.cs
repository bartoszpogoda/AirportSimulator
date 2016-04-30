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
        }

        public void wykonajOperacje(ListaOperacji uchwytListaOperacji) 
        {
            if (!operacja.wykonajTick())
                uchwytListaOperacji.usunElement(this);
          
            if(nastepnyElement != null) nastepnyElement.wykonajOperacje(uchwytListaOperacji);
        }
    }
}
