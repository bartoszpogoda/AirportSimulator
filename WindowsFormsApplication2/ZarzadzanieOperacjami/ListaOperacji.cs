﻿using System;
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
        private ElementListyOperacji iterator;

        public ListaOperacji()
        {
            pierwszy = null;
            ostatni = null;
        }
        public void iteratorNaStart()
        {
            iterator = pierwszy;
        }
        public void iteratorNastepny()
        {
            if (iterator.nastepnyElement == null)
                iterator = pierwszy;
            else iterator = iterator.nastepnyElement;
        }

        public ElementListyOperacji getPierwszy()
        {
            return pierwszy;
        }

        public bool iteratorMaNastepny()
        {
            if (iterator.nastepnyElement == null) return false;
            return true;
        }
        public ElementListyOperacji aktualnyPodIteratorem()
        {
            if (iterator == null) return null;
            return iterator;
        }
       
        public void dodajElement(ElementListyOperacji element)
        {
            if (pierwszy == null)
            {
                pierwszy = element;
                ostatni = pierwszy;
            }
            else
            {
                ostatni.nastepnyElement = element;
                element.poprzedniElement = ostatni;
                ostatni = element;
            }
        }

        public void usunElement(ElementListyOperacji element)
        {
            // przepisac
            if(pierwszy == element)
            {
                if(pierwszy.nastepnyElement == null)
                {
                    pierwszy = null;
                    ostatni = null;
                    return;
                }

                pierwszy.nastepnyElement.poprzedniElement = null;
                pierwszy = pierwszy.nastepnyElement;
            }

            ElementListyOperacji iterator = this.pierwszy;

            while(iterator.nastepnyElement != null)
            {
                iterator = iterator.nastepnyElement;

                if(iterator == element)
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
