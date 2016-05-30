using SymulatorLotniska.OperationManagement;
using SymulatorLotniska.Operations;
using SymulatorLotniska.Planes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymulatorLotniska.AirportManagement
{
    public class Airspace
    {
        private List<Plane> airspaceContent;
        private Control handlePanel;
        private int firstColumnToDraw;
        private int columnCount;

        public Airspace(Control handlePanel, int columnCount)
        {
            this.handlePanel = handlePanel;
            airspaceContent = new List<Plane>();

            firstColumnToDraw = 0;
            this.columnCount = columnCount;
        }
        public void addToAirspace(Plane plane)
        {
            airspaceContent.Add(plane);
            plane.setParent(handlePanel);

            OperationManager.getInstance().addOperation(new OperationInAir(plane));
            redraw();
        }
        public void remove(Plane plane)
        {
            airspaceContent.Remove(plane);
            plane.hide();
            redraw();
        }
        public void scrollLeft()
        {
            if (firstColumnToDraw > 0)
            {
                firstColumnToDraw--;
                redraw();
            }
        }
        public void scrollRight()
        {
            if (airspaceContent.Count - columnCount > firstColumnToDraw)
            {
                firstColumnToDraw++;
                redraw();
            }
        }

        private Point getPosition(int i)
        {
            return new Point(Constants.interspaceSize * (i + 1) + i * Constants.planeImageSizeX,
                           10 + Constants.interspaceSize);
        }

        public void redraw()
        {
            if (airspaceContent.Count == 0) return;

            int i = 0;

            int columnsToSkip = firstColumnToDraw;

            while (--columnsToSkip >= 0)
            {
               if (i >= airspaceContent.Count) return;

               airspaceContent.ElementAt(i).hide();
               i++;
            }
            
            for (int currentColumn = 0; currentColumn < columnCount; currentColumn++)
            {
                if (i >= airspaceContent.Count) return;

                airspaceContent.ElementAt(i).getPlaneImage().Location = getPosition(currentColumn);
                airspaceContent.ElementAt(i).show();

                i++;
            }

            for(; i < airspaceContent.Count; i++)
            {
                airspaceContent.ElementAt(i).hide();
            }
        }

        public List<Plane> getList() { return airspaceContent; }
    }
}
