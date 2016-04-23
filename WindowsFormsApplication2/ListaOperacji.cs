using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class ListaOperacji
    {
        private ElementListyOperacji pierwszy;
        private ElementListyOperacji ostatni;
        private MenedzerOperacji uchwytMenedzerOperacji;
        
        public ListaOperacji(MenedzerOperacji uchwytMenedzerOperacji)
        {
            pierwszy = null;
            ostatni = null;
            this.uchwytMenedzerOperacji = uchwytMenedzerOperacji;
        }

        public void wykonajLancuchOperacji()
        {
            pierwszy.wykonajOperacje(this);
        }

        public void powiadomOBrakuOperacji()
        {
            uchwytMenedzerOperacji.zatrzymajTimer();
        }

        public void setPierwszy(ElementListyOperacji pierwszy) {
            this.pierwszy = pierwszy;
        }

        public void setOstatni(ElementListyOperacji ostatni)
        {
            this.ostatni = ostatni;
        }

        public void dodajOperacje(IOperacja operacja)
        {

            if (pierwszy == null)
            {
                pierwszy = new ElementListyOperacji(operacja);
                ostatni = pierwszy;
            }
            else
            {
                ostatni.nastepnyElement = new ElementListyOperacji(operacja);
                ostatni.nastepnyElement.poprzedniElement = ostatni;
                ostatni = ostatni.nastepnyElement;
            }

            // dodano operacje wiec odpalamy tajmera!!

            uchwytMenedzerOperacji.uruchomTimer();

        }
        public ElementListyOperacji znajdzOperacjeNaSamolocie(Samolot samolot)
        {
            if (pierwszy.operacja.getSamolot() == samolot) return pierwszy;

            ElementListyOperacji iterator = pierwszy;

            while(iterator.nastepnyElement != null)
            {
                iterator = iterator.nastepnyElement;

                if (iterator.operacja.getSamolot() == samolot) return iterator;
            }
            return null;
        }

        public void usunOperacjeNaSamolocie(ElementListyOperacji operacja)
        {

            if(pierwszy == operacja)
            {
                pierwszy.operacja.zatrzymaj();

                if(pierwszy.nastepnyElement == null)
                {
                    pierwszy = null;
                    ostatni = null;
                    powiadomOBrakuOperacji();
                    return;
                }

                pierwszy.nastepnyElement.poprzedniElement = null;
                pierwszy = pierwszy.nastepnyElement;
            }

            ElementListyOperacji iterator = this.pierwszy;

            while(iterator.nastepnyElement != null)
            {
                iterator = iterator.nastepnyElement;

                if(iterator == operacja)
                {
                    iterator.operacja.zatrzymaj();

                    if (iterator.nastepnyElement == null)
                    {
                        ostatni = iterator.poprzedniElement;
                        iterator.poprzedniElement.nastepnyElement = null;
                        return;
                    }

                    iterator.nastepnyElement.poprzedniElement = iterator.poprzedniElement;
                    iterator.poprzedniElement = iterator.nastepnyElement;
                    return;

                }
            }
        }




    }
}
