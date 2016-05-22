using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SymulatorLotniska.ZarzadzaniePowiadomieniami
{
    public class NotificationManager
    {
        private static NotificationManager instance;
        
        public static NotificationManager getInstance()
        {
            if (instance != null) return instance;

            instance = new NotificationManager();
            return instance;
        }

        private List<Notification> listNotification;
        GroupBox handlePanel;

        private NotificationManager()
        {
            listNotification = new List<Notification>();
            
        }
        public void setPanel(GroupBox handePanel) { this.handlePanel = handePanel; }
        
        public void addNotification(String text, NotificationType notificationType)
        {
            listNotification.Insert(0, new Notification(text,notificationType));
            redraw();
        }

        public void removeNotification(Notification notification)
        {
            listNotification.Remove(notification);
            redraw();
        }

        public GroupBox getPanel() { return handlePanel; }

        public void clear()
        {
            foreach (Notification p in listNotification)
                p.remove();
          
            listNotification.Clear();
            redraw();
        }

        private void redraw()
        {
            int x = 0;
            int y = 3*ConfigurationConstants.interspaceSize;

            int i = 0;

            for(; i < listNotification.Count; i++)
            {
                if(y + listNotification.ElementAt(i).getHeight() > handlePanel.Size.Height)
                {
                    break;
                }
                listNotification.ElementAt(i).show(new Point(x, y));
                y += ConfigurationConstants.interspaceSize + listNotification.ElementAt(i).getHeight();
            }
            for(; i < listNotification.Count; i++)
            {
                listNotification.ElementAt(i).hide();
            }
        }
        
    }
}
