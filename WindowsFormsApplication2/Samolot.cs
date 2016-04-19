using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public enum Stan { Spoczynek, Zaladunek, Kontrola, Tankowanie, Startowanie };
    abstract class Samolot : Miniatura// pozniej moze bedzie Abstract poniewaz musi miec swoj typ np transportowy
    {
        private Stan aktualnyStan;
        private int maxPaliwo;
        private int aktualnePaliwo;

        public Stan getStan() { return aktualnyStan; }
          
        // tymczasowo
    
        public Samolot(string adresBazowy, Form uchwytFormy, MenedzerSamolotow uchwytMenedzerSamolotow, int maxPaliwo)
            : base(adresBazowy,uchwytMenedzerSamolotow)
        {
            this.maxPaliwo = maxPaliwo;
            aktualnePaliwo = 0;
        }
        
        public void operacja1() { // tankowanie

        }
        abstract public void operacja2();
        abstract public void operacja3();
        abstract public string wypiszInformacje();
        
        public int getMaxPaliwo()
        {
            return maxPaliwo;
        }

        public int getAktualnePaliwo()
        {
            return aktualnePaliwo;
        }

        public void setAktualnePaliwo(int aktualnePaliwo)
        {
            this.aktualnePaliwo = aktualnePaliwo;
            uchwytMenedzerSamolotow.odswiez();
        }

        public void zmienStan(Stan stan) {
            aktualnyStan = stan;

            if (aktualnyStan == Stan.Spoczynek) ustawGrafike('s');
            else if (aktualnyStan == Stan.Zaladunek) ustawGrafike('k');
            else if(aktualnyStan == Stan.Kontrola) ustawGrafike('z');
            else if(aktualnyStan == Stan.Tankowanie) ustawGrafike('t');
            else if (aktualnyStan == Stan.Startowanie) ustawGrafike('a');

        }


        
    }
    
}
