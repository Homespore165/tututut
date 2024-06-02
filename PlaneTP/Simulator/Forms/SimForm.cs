using Simulator.Forms;

namespace Simulator;

public partial class SimForm : Form
{
    private Controller _controller;
    private List<FormFlight> _flights;
    private float _tempTime;

    public SimForm()
    {
        _controller = Controller.Instance;
        InitializeComponent();
        _flights = new List<FormFlight>();
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
        _flights.Add(flight);
    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void advanceTimeBtn_Click(object sender, EventArgs e)
    {

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

        Pen linePen = new Pen(Brushes.Blue, 2f);
        linePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        linePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        Brush b = Brushes.DarkBlue;

        Graphics graphics = e.Graphics;

        Font font = new Font(FontFamily.GenericSansSerif, 12);
        Brush brush = SystemBrushes.ControlText;

        foreach (FormFlight flight in _flights)
        {
            flight.setProgress(_tempTime % 1f);

            graphics.DrawLine(flight.Pen, flight.Start, flight.End);
            graphics.DrawString(flight.Type, font, brush, flight.Position);
            graphics.DrawEllipse(Pens.DarkBlue, new Rectangle(flight.Position.X - pointSize, flight.Position.Y - pointSize, pointSize * 2, pointSize * 2));

            if (flight.Type == "O")
            {
                graphics.DrawEllipse(flight.Pen, new Rectangle(flight.End.X - circleSize, flight.End.Y - circleSize, circleSize * 2, circleSize * 2));
            }
        }

        updateMap();
    }

    //temp: ToDelete
    private void updateMap()
    {
        mapImage.Invalidate();
    }


    // "type;startx;starty;endx;endy;posx,posy"
    public void updateFlights(List<String> strings)
    {

    }
}