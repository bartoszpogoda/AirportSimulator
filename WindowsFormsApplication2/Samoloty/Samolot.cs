using SymulatorLotniska.ZarzadzanieSamolotami;
using System.Windows.Forms;

namespace SymulatorLotniska.Samoloty
{
    public abstract class Samolot : Miniatura
    {
        //---parametry techniczne
        private int maksIloscPaliwa;
        private int czasStartu;           //w tickach
        private int czasKontroliTechnicznej;         //w tickach
        private int czasKontroli;         //w tickach
        private string model;
        //-----------------------

        //---zmienne okreslajace stan
        private Stan aktualnyStan;
        private int aktualnaIloscPaliwa;
        private bool kontrolaTechniczna;
        private bool kontrola;
        //---------------------------

        public int getMaksIloscPaliwa()  { return maksIloscPaliwa; }
        public void setMaksIloscPaliwa(int maksIloscPaliwa) { this.maksIloscPaliwa = maksIloscPaliwa; }

        public int getCzasStartu() { return czasStartu; }
        public void setCzasStartu(int czasStartu) { this.czasStartu = czasStartu; }


        public string getModel() { return model; }
        public void setModel(string model) { this.model = model; }


        public Stan getAktualnyStan() { return aktualnyStan; }
        public void setAktualnyStan(Stan stan)
        {
                aktualnyStan = stan;
                ustawNakladke(stan);
                uchwytMenedzerSamolotow.uaktualnijPrzyciskiJezeliZaznaczony(this);
                uchwytMenedzerSamolotow.oswiezInformacjeJezeliZaznaczony(this);
        }
      

        public int AktualnaIloscPaliwa
        {
            get
            {
                return aktualnaIloscPaliwa;
            }

            set
            {
                aktualnaIloscPaliwa = value;
                uchwytMenedzerSamolotow.oswiezInformacjeJezeliZaznaczony(this);
            }
        }

        public bool PoKontroli
        {
            get
            {
                return kontrolaTechniczna;
            }

            set
            {
                kontrolaTechniczna = value;
            }
        }

        public int CzasKontroliTechnicznej
        {
            get
            {
                return czasKontroliTechnicznej;
            }

            set
            {
                czasKontroliTechnicznej = value;
            }
        }

        public Samolot(string adresMiniaturki, MenedzerSamolotow uchwytMenedzerSamolotow, Control parent)
            : base(adresMiniaturki, uchwytMenedzerSamolotow, parent)
        {

        }
        


        public Samolot(string adresBazowy, MenedzerSamolotow uchwytMenedzerSamolotow, Control parent, int maksIloscPaliwa, int czasStartu, int czasKontroli, string model)
            : base(adresBazowy, uchwytMenedzerSamolotow, parent)
        {
            this.czasStartu = czasStartu;
            this.model = model;
            this.maksIloscPaliwa = maksIloscPaliwa;
            this.czasKontroliTechnicznej = czasKontroli;

            AktualnaIloscPaliwa = 0;
            PoKontroli = false;
        }
        
        abstract public string wypiszInformacje();


        public bool czyZatankowany()
        {
            if (maksIloscPaliwa == AktualnaIloscPaliwa) return true;
            return false;
        }

        public bool czyPoKontroli() { return PoKontroli; }
    }

}
