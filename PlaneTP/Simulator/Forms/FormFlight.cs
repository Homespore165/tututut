using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Forms
{
    internal class FormFlight
    {
        public string Type { get; }
        public Point Start { get; }
        public Point End { get; }
        public Point Position { get; set; }

        public FormFlight(string type, Point start, Point end) 
        {
            Type = type;
            Start = start;
            End = end;
            Position = new Point(start.X, start.Y);
        }

        public void setProgress(float t)
        {
                int x = (int)((1 - t) * Start.X + t * End.X);
                int y = (int)((1 - t) * Start.Y + t * End.Y);
                Position = new Point(x, y);
        }
    }
}
