namespace WindowsFormsApplication2
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
