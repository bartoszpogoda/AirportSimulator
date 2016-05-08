using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymulatorLotniska.ZarzadzaniePowiadomieniami
{
    public class MenedzerPowiadomien
    {
        private List<Powiadomienie> listaPowiadomien;
        GroupBox uchwytPanel;

        public MenedzerPowiadomien(GroupBox uchwytPanel)
        {
            listaPowiadomien = new List<Powiadomienie>();
            this.uchwytPanel = uchwytPanel;
            
        }
        
        public void dodajPowiadomienie(Powiadomienie powiadomienie)
        {
            listaPowiadomien.Insert(0, powiadomienie);
            narysuj();
        }

        public void usunPowiadomienie(Powiadomienie powiadomienie)
        {
            listaPowiadomien.Remove(powiadomienie);
            narysuj();
        }

        public GroupBox getPanel() { return uchwytPanel; }


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
                listaPowiadomien.ElementAt(i).pokazXY(x, y); 
                y += StaleKonfiguracyjne.rozmiarOdstepu + listaPowiadomien.ElementAt(i).getWysokosc();
            }
            for(; i < listaPowiadomien.Count; i++)
            {
                listaPowiadomien.ElementAt(i).schowaj();
            }
        }
        
    }
}
