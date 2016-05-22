﻿using SymulatorLotniska.Planes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymulatorLotniska.ZarzadzanieSamolotami
{
    public class Hangar
    {
        private List<Plane> hangarContent;
        private Control handlePanel;
        private int firstRowToDraw;
        private int rowCount;
        private int columnCount;

        public Hangar(Control handlePanel, int rowCount, int columnCount) {
            this.handlePanel = handlePanel;
            hangarContent = new List<Plane>();
            firstRowToDraw = 0;
            this.rowCount = rowCount;
            this.columnCount = columnCount;
        }

        public void addToHangar(Plane plane)
        {
            hangarContent.Add(plane);
            plane.setParent(handlePanel);
            redraw();
        }

        public void remove(Plane plane)
        {
            hangarContent.Remove(plane);
            redraw();
        }

        public void scrollUp()
        {
            if(firstRowToDraw > 0)
            {
                firstRowToDraw--;
                redraw();
            }
        }

        public void scrollDown()
        {
            if(hangarContent.Count / columnCount - rowCount + 1 > firstRowToDraw)
            {
                firstRowToDraw++;
                redraw();
            }
        }

        private Point getPosition(int i, int j)
        {
            return new Point(ConfigurationConstants.interspaceSize * (j + 1)
                            + j * ConfigurationConstants.imageSize,
                          10 + ConfigurationConstants.interspaceSize * (i + 1)
                          + i * ConfigurationConstants.imageSize);
        }

        public void redraw()
        {
            if (hangarContent.Count == 0) return;

            int i = 0;
            
            int rowsToSkip = firstRowToDraw;

            while(--rowsToSkip >= 0)
            {
                for(int k = 0; k < columnCount; k++)
                {
                    if (i >= hangarContent.Count) return;
                    hangarContent.ElementAt(i).hide();
                    i++;
                }
            }

            int currentRow = 0, currentColumn = 0;
            for(;currentRow < rowCount; currentRow++)
            {
                for (currentColumn = 0; currentColumn < columnCount; currentColumn++)
                {
                    if (i >= hangarContent.Count) return;

                    hangarContent.ElementAt(i).getPlaneImage().Location = getPosition(currentRow, currentColumn);
                    hangarContent.ElementAt(i).show();

                    // tutaj cos w stylu tego jesli nie bedzie dzialac

                    /*
                    
                    if (listaSamolotow.aktualnyPodIteratorem().Equals(selectedPlane)) {
                        pbSelectedPlane.Parent = selectedPlane.getCurrentOnTop();
                        pbSelectedPlane.Location = new System.Drawing.Point(0, 0);
                        pbSelectedPlane.Visible = true;
                    }
                     */

                    i++;
                }
            }
        }



    }
}