using Simulator.Model;
using System.Xml.Linq;

namespace Simulator;

public partial class SimForm : Form
{
    private Controller _controller;
    private List<string> _flights;
    private float _tempTime;
    private List<string> _airports;

    public SimForm()
    {
        _controller = Controller.Instance;
        InitializeComponent();
        _flights = new List<string>();
        _airports = new List<string>();
        _tempTime = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _controller.LoadScenario();
    }

    private void advanceTimeBtn_Click(object sender, EventArgs e)
    {
        int timeToAdvance = (int)timeAdvanceSelector.Value;

        _controller.TimeStep(timeToAdvance);
    }

    private void mapImage_Paint(object sender, PaintEventArgs e)
    {
        _tempTime += 0.001f;

        int pointSize = 5;
        int circleSize = 15;

        Graphics graphics = e.Graphics;

        Font font = new Font(FontFamily.GenericSansSerif, 12);
        Brush brush = SystemBrushes.ControlText;

        foreach (string flight in _flights)
        {
            string[] strings = flight.Split(";");

            string type = strings[0];
            int startx = int.Parse(strings[1]);
            int starty = int.Parse(strings[2]);
            int endx = int.Parse(strings[3]);
            int endy = int.Parse(strings[4]);
            int posx = int.Parse(strings[5]);
            int posy = int.Parse(strings[6]);

            Pen linePen = getPenForType(type);
            linePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            linePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            graphics.DrawLine(linePen, new Point(startx, starty), new Point(endx, endy));
            graphics.DrawString(type, font, brush, new Point(posx, posy));

            try
            {
                graphics.DrawEllipse(Pens.DarkBlue, new Rectangle(posx - pointSize, posy - pointSize, pointSize * 2, pointSize * 2));
            } catch {}

            if (type == "O")
            {
                graphics.DrawEllipse(linePen, new Rectangle(endx - circleSize, endy - circleSize, circleSize * 2, circleSize * 2));
            }
        }

        foreach (string airport in _airports)
        {

            string[] strings = airport.Split(";");

            int x = int.Parse(strings[1]);
            int y = int.Parse(strings[2]);

            graphics.DrawString(strings[0], font, brush, new Point(x, y));
        }
    }

    private void updateMap()
    {
        mapImage.Invalidate();
    }

    private Pen getPenForType(string type)
    {
        Pen pen = new Pen(Brushes.Blue, 2f);

        switch (type)
        {
            case "O":
                pen = new Pen(Brushes.White, 2f);
                break;
            case "R":
                pen = new Pen(Brushes.Yellow, 2f);
                break;
            case "C":
                pen = new Pen(Brushes.Green, 2f);
                break;
            case "F":
                pen = new Pen(Brushes.Red, 2f);
                break;
        }

        return pen;
    }

    // "type;startx;starty;endx;endy;posx,posy"
    public void updateFlights(List<string> strings)
    {
        _flights = strings;

        updateMap();
    }

    public void updateAirports(List<string> strings)
    {
        _airports.Clear();
        airportTreeView.Nodes.Clear();

        foreach (string info in strings)
        {
            string[] strs = info.Split(';');
            TreeNode node = new TreeNode(strs[0]);

            _airports.Add(strs[0] + ";" + strs[1] + ";" + strs[2]);

            for (int i = 3; i < strs.Length; i++)
            {
                node.Nodes.Add(new TreeNode(strs[i]));
            }

            airportTreeView.Nodes.Add(node);
        }

        updateMap();
    }
}