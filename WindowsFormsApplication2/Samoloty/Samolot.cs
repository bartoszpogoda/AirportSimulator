using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public enum Stan { Hangar, Zaladunek, KontrolaHangar, Tankowanie, Startowanie, WPowietrzu, Zniszczony, Null };
    public abstract class Samolot : Miniatura
    {
        //---parametry techniczne
        private int maksIloscPaliwa;
        private int czasStartu;         //w tickach
        private int czasKontroli;         //w tickach
        private string model;
        //-----------------------

        //---zmienne okreslajace stan
        private Stan aktualnyStan;
        private int aktualnaIloscPaliwa;
        private bool kontrolaTechniczna;
        //---------------------------

        public int MaksIloscPaliwa
        {
            get
            {
                return maksIloscPaliwa;
            }

            set
            {
                maksIloscPaliwa = value;
            }
        }

        public int CzasStartu
        {
            get
            {
                return czasStartu;
            }

            set
            {
                czasStartu = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public Stan AktualnyStan
        {
            get
            {
                return aktualnyStan;
            }

            set
            {
                aktualnyStan = value;
                ustawNakladke(value);
                uchwytMenedzerSamolotow.uaktualnijPrzyciskiJezeliZaznaczony(this);
                uchwytMenedzerSamolotow.oswiezInformacjeJezeliZaznaczony(this);

            }
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

        public int CzasKontroli
        {
            get
            {
                return czasKontroli;
            }

            set
            {
                czasKontroli = value;
            }
        }

        public Samolot(string adresBazowy, Form uchwytFormy, MenedzerSamolotow uchwytMenedzerSamolotow, Control parent, int maksIloscPaliwa, int czasStartu, int czasKontroli, string model)
            : base(adresBazowy, uchwytMenedzerSamolotow, parent)
        {
            this.CzasStartu = czasStartu;
            this.Model = model;
            this.MaksIloscPaliwa = maksIloscPaliwa;
            this.czasKontroli = czasKontroli;

            AktualnaIloscPaliwa = 0;
            PoKontroli = false;
        }

        public Samolot() : base()
        {
            CzasStartu = -1;
            Model = "";
            MaksIloscPaliwa = -1;

            AktualnaIloscPaliwa = 0;
            PoKontroli = false;
        }



        abstract public string wypiszInformacje();


        public bool czyZatankowany()
        {
            if (MaksIloscPaliwa == AktualnaIloscPaliwa) return true;
            return false;
        }

        public bool czyPoKontroli() { return PoKontroli; }
    }

}
