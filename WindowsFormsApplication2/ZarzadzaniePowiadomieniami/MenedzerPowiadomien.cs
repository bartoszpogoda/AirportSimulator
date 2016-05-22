using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SymulatorLotniska.ZarzadzaniePowiadomieniami
{
    public class MenedzerPowiadomien
    {
        private static MenedzerPowiadomien instance;
        
        public static MenedzerPowiadomien getInstance()
        {
            if (instance != null) return instance;

            instance = new MenedzerPowiadomien();
            return instance;
        }

        private List<Powiadomienie> listaPowiadomien;
        GroupBox uchwytPanel;

        private MenedzerPowiadomien()
        {
            listaPowiadomien = new List<Powiadomienie>();
            
        }
        public void setUchwytPanel(GroupBox uchwytPanel) { this.uchwytPanel = uchwytPanel; }
        
        public void dodajPowiadomienie(String komunikat, CharakterPowiadomienia charakterPowiadomienia)
        {
            listaPowiadomien.Insert(0, new Powiadomienie(komunikat,charakterPowiadomienia));
            narysuj();
        }

        public void usunPowiadomienie(Powiadomienie powiadomienie)
        {
            listaPowiadomien.Remove(powiadomienie);
            narysuj();
        }

        public GroupBox getPanel() { return uchwytPanel; }

        public void wyczysc()
        {
            foreach (Powiadomienie p in listaPowiadomien)
                p.usun();



            listaPowiadomien.Clear();
            narysuj();
        }

        private void narysuj()
        {
            int x = 0;
            int y = 3*StaleKonfiguracyjne.rozmiarOdstepu;

            int i = 0;

            for(; i < listaPowiadomien.Count; i++)
            {
                if(y + listaPowiadomien.ElementAt(i).getWysokosc() > uchwytPanel.Size.Height)
                {
                    break;
                }
                listaPowiadomien.ElementAt(i).pokaz(new Point(x, y));
                y += StaleKonfiguracyjne.rozmiarOdstepu + listaPowiadomien.ElementAt(i).getWysokosc();
            }
            for(; i < listaPowiadomien.Count; i++)
            {
                listaPowiadomien.ElementAt(i).schowaj();
            }
        }
        
    }
}
