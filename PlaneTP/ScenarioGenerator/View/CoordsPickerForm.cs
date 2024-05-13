using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScenarioGenerator
{
    public partial class CoordsPickerForm : Form
    {

        private Point _chosenCoordinates;
        private Size _geoPinSize;

        /// <summary>
        /// Retourne les coordonnées choisies sous forme X,Y sur le formulaire
        /// </summary>
        public Point ChosenCoordinates { get { return _chosenCoordinates; } }

        public CoordsPickerForm()
        {
            _geoPinSize = new Size(32, 32);
            InitializeComponent();
            _chosenCoordinates = new Point(0, 0);
            updateCoordinateLabels();
            setDebugMsg("");
        }

        private void setDebugMsg(string msg)
        {
            debugLabel.Text = msg;
        }

        private void updateCoordinateLabels()
        {
            posLabel.Text = "Position: " + _chosenCoordinates.X + "X, " + _chosenCoordinates.Y + "Y";

            string coordsString = convertPosToCoordString(_chosenCoordinates);
            coordsLabel.Text = "Coordinates: " + coordsString;
            worldMap.Refresh();
        }

        private string convertPosToCoordString(Point pos)
        {
            string str = "";

            Point centerRelativePosition = new Point(pos.X - worldMap.Width / 2, pos.Y - worldMap.Height / 2);

            str = str + (Math.Abs((float)centerRelativePosition.Y / worldMap.Height * 2 * 90)) + "°";
            str = str + (centerRelativePosition.Y < 0 ? "N" : "S") + "; ";

            str = str + (Math.Abs((float)centerRelativePosition.X / worldMap.Width * 2 * 180)) + "°";
            str = str + (centerRelativePosition.X < 0 ? "W" : "E");

            return str;
        }

        private void worldMap_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs mouseArgs)
            {
                _chosenCoordinates = new Point(mouseArgs.X, mouseArgs.Y);
            }

            updateCoordinateLabels();
        }

        private void worldMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(Properties.Resources.GeoPin, new Rectangle(worldMap.Location.X + _chosenCoordinates.X - _geoPinSize.Width / 2, worldMap.Location.Y + _chosenCoordinates.Y - _geoPinSize.Height, _geoPinSize.Width, _geoPinSize.Height));
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
