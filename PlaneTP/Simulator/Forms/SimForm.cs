using Simulator.Model;
using System.Xml.Linq;

namespace Simulator;

public partial class SimForm : Form
{
    private Controller _controller;
    private List<string> _flights;
    private List<string> _airports;

    /// <summary>
    /// Constructeur du formulaire
    /// </summary>
    public SimForm()
    {
        _controller = Controller.Instance;
        InitializeComponent();
        _flights = new List<string>();
        _airports = new List<string>();
        advanceTimeBtn.Enabled = false;
    }

    /// <summary>
    /// Évenement pour charger le scénario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button1_Click(object sender, EventArgs e)
    {
        _controller.LoadSavedScenario();
        loadScenarioBtn.Enabled = false;
        advanceTimeBtn.Enabled = true;
    }

    /// <summary>
    /// Évenement pour avancer le temps d'un certain nombre d'étapes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void advanceTimeBtn_Click(object sender, EventArgs e)
    {
        int timeToAdvance = (int)timeAdvanceSelector.Value;

        _controller.TimeStep(timeToAdvance);
    }

    /// <summary>
    /// Évenement pour peinturer la carte principale
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mapImage_Paint(object sender, PaintEventArgs e)
    {

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

            if (posx >= 0 && posy >= 0)
            {
                graphics.DrawEllipse(Pens.DarkBlue, new Rectangle(posx - pointSize, posy - pointSize, pointSize * 2, pointSize * 2));
            }

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

    /// <summary>
    /// Rafraichit la carte
    /// </summary>
    private void updateMap()
    {
        mapImage.Invalidate();
    }

    /// <summary>
    /// Obtient un crayon pour le type d'avion
    /// </summary>
    /// <param name="type">le string du type d'avion</param>
    /// <returns>Le crayon de couleur pour le type d'avion</returns>
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

    /// <summary>
    /// Met à jour la vue des avions en vol
    /// </summary>
    /// <param name="strings">la liste de strings des vols</param>
    public void updateFlights(List<string> strings)
    {
        _flights = strings;

        updateMap();
    }

    /// <summary>
    /// Met à jour la vue des aéroports sur la carte et dans la liste
    /// </summary>
    /// <param name="strings">la liste des aéroports</param>
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

        airportTreeView.ExpandAll();

        updateMap();
    }

    public void updatePlaneList(List<string> strings)
    {
        planeTreeView.Nodes.Clear();

        foreach (string info in strings)
        {
            string[] strs = info.Split(';');
            TreeNode node = new TreeNode(strs[0]);

            for (int i = 1; i < strs.Length; i++)
            {
                node.Nodes.Add(new TreeNode(strs[i]));
            }

            planeTreeView.Nodes.Add(node);
        }

        planeTreeView.ExpandAll();
    }
}