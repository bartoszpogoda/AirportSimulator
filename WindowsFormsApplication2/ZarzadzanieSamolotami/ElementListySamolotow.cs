using SymulatorLotniska.Samoloty;

namespace SymulatorLotniska.ZarzadzanieSamolotami
{
    class ElementListySamolotow
    {
        public Samolot samolot;
        public ElementListySamolotow nastepnyElement;

        public ElementListySamolotow(Samolot samolot)
        {
            this.samolot = samolot;
            nastepnyElement = null;
        }
    }
}
