using System.Drawing;
using System.Windows.Forms;
using SeaWar.Domain;
using SeaWar.Domain;

namespace SeaWar
{
    public class ImageShip : PictureBox
    {
        public Ship ModelShip { get; }

        public ImageShip() : base()
        {
            
        }

        public ImageShip(Ship modelShip) : base()
        {
            this.ModelShip = modelShip;
        }
    }
}