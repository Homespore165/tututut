using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Forms
{
    internal class FormFlight
    {
        // O - Observation
        // R - Rescue
        // P - Passenger
        // C - Cargo
        // F - Fire
        public string Type { get; }
        public Point Start { get; }
        public Point End { get; }
        public Point Position { get; set; }
        public Pen Pen { get; }

        public FormFlight(string type, Point start, Point end) 
        {
            Type = type;
            Start = start;
            End = end;
            Position = new Point(start.X, start.Y);

            switch (type)
            {
                case "O":
                    Pen = new Pen(Brushes.White, 2f);
                    break;
                case "R":
                    Pen = new Pen(Brushes.Yellow, 2f);
                    break;
                case "P":
                    Pen = new Pen(Brushes.Blue, 2f);
                    break;
                case "C":
                    Pen = new Pen(Brushes.Green, 2f);
                    break;
                case "F":
                    Pen = new Pen(Brushes.Red, 2f);
                    break;
            }
        }

        public void setProgress(float t)
        {
                int x = (int)((1 - t) * Start.X + t * End.X);
                int y = (int)((1 - t) * Start.Y + t * End.Y);
                Position = new Point(x, y);
        }
    }
}
