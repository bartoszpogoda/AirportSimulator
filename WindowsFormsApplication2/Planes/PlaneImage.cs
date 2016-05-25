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
            currentPlaneImage.Size = new Size(50, 50);
            currentPlaneImage.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            hide();
            currentPlaneImage.Click += new EventHandler(onClick);

            currentStateImage.Parent = currentPlaneImage;
            currentStateImage.Location = new Point(0, 0);
            currentStateImage.Size = new Size(50, 50);
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
            AirportManager.getInstance().zaznaczSamolot(this);
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
            else if (newState == State.Takeoff)
            {
                currentStateImage.Image = (Image)Properties.Resources.ResourceManager.GetObject("startowanie");
                currentStateImage.Visible = true;
                currentStateImage.Enabled = true;
                currentOnTop = currentStateImage;
            }
            else if (newState == State.Destroyed)
            {
                currentStateImage.Image = (Image)Properties.Resources.ResourceManager.GetObject(Constants.adresZniszczony);
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
