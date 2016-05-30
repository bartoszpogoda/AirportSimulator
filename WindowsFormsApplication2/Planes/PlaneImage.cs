using System;
using System.Windows.Forms;
using System.Drawing;
using SymulatorLotniska.AirportManagement;

namespace SymulatorLotniska.Planes
{
    
    public class PlaneImage
    {
        
        private PictureBox currentPlaneImage;
        
        private PictureBox currentStateImage;
        
        private Control currentOnTop;
        
        public PlaneImage(Control parentControl = null, String imageName = "samolot1")
        {

            currentPlaneImage = new PictureBox();
            currentStateImage = new PictureBox();

            currentPlaneImage.Parent = parentControl;
            currentPlaneImage.Size = new Size(Constants.planeImageSizeX, Constants.planeImageSizeY);
            currentPlaneImage.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            hide();
            currentPlaneImage.Click += new EventHandler(onClick);

            currentStateImage.Parent = currentPlaneImage;
            currentStateImage.Location = new Point(0, 0);
            currentStateImage.Size = new Size(Constants.planeImageSizeX, Constants.planeImageSizeY);
            currentStateImage.Visible = false;
            currentStateImage.Enabled = false;
            currentStateImage.BackColor = Color.Transparent;
            currentStateImage.Click += new EventHandler(onClick);

            currentOnTop = currentPlaneImage;
        }

        public void setPlaneImage(string adress)
        {
            currentPlaneImage.Image = (Image)Properties.Resources.ResourceManager.GetObject(adress);
        }

        public PictureBox getPlaneImage() { return currentPlaneImage; }
        public Control getCurrentOnTop() { return currentOnTop; }
        
        /// <summary>
        /// wcisniecie obrazka samolotu powoduje zaznaczenie tego samolotu
        /// </summary>
        private void onClick(object sender, EventArgs e)
        {
            AirportManager.getInstance().selectPlane(this);
        }
        public void show()
        {
            currentPlaneImage.Visible = true;
            currentPlaneImage.Enabled = true;
        } 
        public void hide()
        {
            currentPlaneImage.Visible = false;
            currentPlaneImage.Enabled = false;
        }
        public void setParent(Control parent)
        {
            currentPlaneImage.Parent = parent;
        }
        
        /// <summary>
        /// aktualizuje nakladke stanu, jesli dla danego stanu nie ma nakladki chowa ja i zmienia zmienna currentOnTop
        /// </summary>
        public void setStateImage(State newState)
        {
            if (newState == State.TechnicalInspection)
            {
                currentStateImage.Image = Properties.Resources.kontrolaTechnicznaNakladka;
                currentStateImage.Visible = true;
                currentStateImage.Enabled = true;
                currentOnTop = currentStateImage;
            }
            else if (newState == State.Fueling)
            {
                currentStateImage.Image = Properties.Resources.tankowanieNakladka;
                currentStateImage.Visible = true;
                currentStateImage.Enabled = true;
                currentOnTop = currentStateImage;
            }
            else if (newState == State.Takeoff || newState == State.Landing || newState == State.Hangar
                || newState == State.OnRunwayAftLanding || newState == State.OnRunwayBefTakeoff)
            {
                if (this is PassengerPlane)
                {
                    currentStateImage.Image = Properties.Resources.kolaPasazerski;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
                else if (this is TransportPlane)
                {
                    currentStateImage.Image = Properties.Resources.kolaTowarowy;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
                else
                {
                    currentStateImage.Image = Properties.Resources.kolaWojskowy;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
            }
            else if(newState == State.Loading || newState == State.Unloading)
            {
                if (this is PassengerPlane)
                {
                    currentStateImage.Image = Properties.Resources.wprowadzaniePasazerow;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
                else if (this is TransportPlane)
                {
                    currentStateImage.Image = Properties.Resources.wyprowadzanieTowarowy;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
                else
                {
                    currentStateImage.Image = Properties.Resources.kolaWojskowy;
                    currentStateImage.Visible = true;
                    currentStateImage.Enabled = true;
                    currentOnTop = currentStateImage;
                }
            
               
            }
            else if (newState == State.Destroyed)
            {
                //currentStateImage.Image = (Image)Properties.Resources.);
                currentStateImage.Visible = true;
                currentStateImage.Enabled = true;
                currentOnTop = currentStateImage;
            }
            else
            {
                currentStateImage.Visible = false;
                currentStateImage.Enabled = false;
                currentOnTop = currentPlaneImage;
            }

            AirportManager.getInstance().refreshPbSelectedIfSelected(this);
            AirportManager.getInstance().redraw();

        }
        public bool isVisible()
        {
            return currentPlaneImage.Visible;
        }
        }
}
