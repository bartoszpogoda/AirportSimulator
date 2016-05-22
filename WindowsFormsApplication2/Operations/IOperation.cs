using SymulatorLotniska.Planes;

namespace SymulatorLotniska.Operations
{
    public abstract class IOperation
    {
        ///<summary>
        /// algorytm wykonujacy sie co tick timera.
        ///</summary> 
        /// <returns>
        /// false po ostatnim wykonaniu
        /// </returns>
        public abstract bool execute();

        ///<summary>
        /// algorytm wykonujacy sie przy niestandardowym zatrzymaniu operacji
        ///</summary> 
        public abstract void stop();
        
        public abstract Plane getPlane();
    }
}
