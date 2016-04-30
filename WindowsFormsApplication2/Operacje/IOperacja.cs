using SymulatorLotniska.Samoloty;

namespace SymulatorLotniska.Operacje
{
    public abstract class IOperacja
    {
        // algorytm wykonujacy sie co tick timera. Zwraca false przy ostatnim wykonaniu.
        public abstract bool wykonajTick(); 

        // algorytm wykonujacy sie przy przerwaniu operacji (nie samoczynnym)
        public abstract void zatrzymaj();

        // zwraca referencje samolotu ktorego dotyczy operacja (jesli dotyczy)
        public abstract Samolot getSamolot();
    }
}
