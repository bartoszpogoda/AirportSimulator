using SymulatorLotniska.Samoloty;

namespace SymulatorLotniska.ZarzadzanieSamolotami
{
    class ListaSamolotow
    {
        private ElementListySamolotow pierwszy;
        private ElementListySamolotow ostatni;
        private int length;
        private ElementListySamolotow iterator;

        public int getLength()
        {
            return length;
        }
        public ListaSamolotow()
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

            length++;

        }

        public void usunSamolot(Samolot samolot)
        {
            if(pierwszy.samolot == samolot)
            {
                pierwszy = pierwszy.nastepnyElement;
                return;
            }

            iteratorNaStart();
            ElementListySamolotow poprzedni = iterator;

            while (iteratorMaNastepny())
            {
                iteratorNastepny();

                if (iterator.samolot == samolot) {
                    poprzedni.nastepnyElement = iterator.nastepnyElement;
                }

                poprzedni = iterator;
            }
        }





    }
}
