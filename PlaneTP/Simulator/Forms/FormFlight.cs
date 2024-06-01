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

        private Point test;

        public FormFlight(string type, Point start, Point end) 
        {
            Type = type;
            Start = start;
            End = end;
            Position = new Point(start.X, start.Y);
            test = new Point(0, 0);
        }

        public void setProgress(float t)
        {
            bool returning = (test.X ==  End.X-1 && test.Y == End.Y-1) ? true : false;
            if (!returning)
            {
                int x = (int)((1 - t) * Start.X + t * End.X);
                int y = (int)((1 - t) * Start.Y + t * End.Y);
                Position = new Point(x, y);
                test = new Point(x, y);
            }
            else
            {
                int x = (int)((1 - t) * Start.X + t * End.X);
                int y = (int)((1 - t) * Start.Y + t * End.Y);
                Position = new Point(x, y);
                test = new Point(x, y);
            }
        }
    }
}
