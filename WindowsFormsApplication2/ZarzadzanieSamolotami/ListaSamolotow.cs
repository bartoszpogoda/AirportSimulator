using SymulatorLotniska.Samoloty;
using System.Windows.Forms;

namespace SymulatorLotniska.ZarzadzanieSamolotami
{
    class ListaSamolotow
    {
        private ElementListySamolotow pierwszy;
        private ElementListySamolotow ostatni;
        private int length;
        private ElementListySamolotow iterator;
        private Control uchwytPanel;

        public int getLength()
        {
            return length;
        }
        public ListaSamolotow(Control uchwytPanel)
        {
            pierwszy = null;
            ostatni = null;
            this.uchwytPanel = uchwytPanel;
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

        public bool iteratorMaNastepny()
        {
            if (iterator.nastepnyElement == null) return false;
            return true;
        }

        public Samolot aktualnyPodIteratorem()
        {
            if (iterator == null) return null;
            return iterator.samolot;
        }
        

        public void dodajSamolot(Samolot samolot) {

            if (pierwszy == null)
            {
                pierwszy = new ElementListySamolotow(samolot);
                ostatni = pierwszy;
            }
            else
            {
                ostatni.nastepnyElement = new ElementListySamolotow(samolot);
                ostatni = ostatni.nastepnyElement;
            }

            samolot.setParent(uchwytPanel);
            length++;

        }

        public void usunSamolot(Samolot samolot)
        {
            if(pierwszy.samolot == samolot)
            {
               
                pierwszy = pierwszy.nastepnyElement;
                length--;
                return;
            }

            ElementListySamolotow iterator = pierwszy;
            
            ElementListySamolotow poprzedni = pierwszy;

            while (iterator.nastepnyElement != null)
            {
                iterator = iterator.nastepnyElement;

                if (iterator.samolot == samolot) {
                    if (iterator.nastepnyElement == null)
                    {
                        ostatni = poprzedni; // <-- brak tego też powodował bład
                        poprzedni.nastepnyElement = null;
                    }
                    else
                        poprzedni.nastepnyElement = iterator.nastepnyElement;
                    length--;

                    return;
                }

                poprzedni = iterator;
            }
        }





    }
}
