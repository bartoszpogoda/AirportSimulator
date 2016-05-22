using SymulatorLotniska.Planes;

namespace SymulatorLotniska.ZarzadzanieSamolotami
{
    class ElementListySamolotow
    {
        public Plane samolot;
        public ElementListySamolotow nastepnyElement;

        public ElementListySamolotow(Plane samolot)
        {
            this.samolot = samolot;
            nastepnyElement = null;
        }
    }
}
