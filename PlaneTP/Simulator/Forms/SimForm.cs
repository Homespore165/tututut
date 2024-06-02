using Simulator.Forms;

namespace Simulator;

public partial class SimForm : Form
{
    private Controller _controller;
    private List<string> _flights;
    private float _tempTime;

    public SimForm()
    {
        _controller = Controller.Instance;
        InitializeComponent();
        _flights = new List<string>();
        _tempTime = 0;

        updateTreeView(new string[]
        {
            "airport1; 11 client2; 62 client1",
            "airrrrrrrrrrprot; 15153 clients; 235235235235235235 asdasdasdasd; yes; ok"
        });

        addFlight("P", 100, 100, 250, 400);
        addFlight("C", 20, 400, 890, 200);
        addFlight("O", 790, 150, 200, 50);
        addFlight("R", 180, 300, 500, 490);
        addFlight("F", 300, 400, 600, 255);
    }

    public void addFlight(string type, int startX, int startY, int endX, int endY)
    {
        FormFlight flight = new FormFlight(type, new Point(startX, startY), new Point(endX, endY));
        flight.setProgress(0.5f);
        //_flights.Add(flight);
    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void advanceTimeBtn_Click(object sender, EventArgs e)
    {
        int timeToAdvance = (int)timeAdvanceSelector.Value;

        _controller.TimeStep(timeToAdvance);
    }

    /// <summary>
    /// update avec une liste de string sous forme:
    /// airport; client; client; client;
    /// </summary>
    /// <param name="jsonString"></param>
    public void updateTreeView(string[] infos)
    {
        foreach (string info in infos)
        {
            string[] strings = info.Split(';');
            TreeNode node = new TreeNode(strings[0]);

            for (int i = 1; i < strings.Length; i++)
            {
                node.Nodes.Add(new TreeNode(strings[i]));
            }

            airportTreeView.Nodes.Add(node);
        }
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
            graphics.DrawEllipse(Pens.DarkBlue, new Rectangle(posx - pointSize, posy - pointSize, pointSize * 2, pointSize * 2));

            if (type == "O")
            {
                graphics.DrawEllipse(linePen, new Rectangle(endx - circleSize, endy - circleSize, circleSize * 2, circleSize * 2));
            }
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
    public void updateFlights(List<String> strings)
    {
        _flights = strings;

        updateMap();
    }
}