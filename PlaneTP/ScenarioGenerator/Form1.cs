namespace ScenarioGenerator;

public partial class Form1 : Form
{
    private Controller _controller;

    public Form1(Controller controller)
    {
        _controller = controller;
        InitializeComponent();
    }

    private void btnAddAirport_Click(object sender, EventArgs e)
    {
        string name = txbAirportName.Text;
        if (name.Length > 0)
        {
            name = name.Trim().Replace(";", "");
            int x = (int)numAirportPositionX.Value;
            int y = (int)numAirportPositionY.Value;
            int passengerTraffic = (int)numAirportPassengerTraffic.Value;
            int cargoTraffic = (int)numAirportCargoTraffic.Value;
            _controller.AddAirport(name, x, y, passengerTraffic, cargoTraffic);
        }
    }

    private void btnEditAirport_Click(object sender, EventArgs e)
    {
        if (lvwAirport.SelectedIndices.Count > 0)
        {
            int airportId = lvwAirport.SelectedIndices[0];
            Console.WriteLine(airportId);
            string name = txbAirportName.Text;
            int x = (int)numAirportPositionX.Value;
            int y = (int)numAirportPositionY.Value;
            int passengerTraffic = (int)numAirportPassengerTraffic.Value;
            int cargoTraffic = (int)numAirportCargoTraffic.Value;
            _controller.EditAirport(airportId, name, x, y, passengerTraffic, cargoTraffic);
        }
    }

    private void btnDeleteAirport_Click(object sender, EventArgs e)
    {
        if (lvwAirport.SelectedIndices.Count > 0)
        {
            int airportId = lvwAirport.SelectedIndices[0];
            _controller.DeleteAirport(airportId);
        }
    }

    private void btnAddPlane_Click(object sender, EventArgs e)
    {
        if (lvwAirport.SelectedIndices.Count > 0 && cbxPlaneType.SelectedIndex >= 0)
        {
            int airportId = lvwAirport.SelectedIndices[0];
            string name = txbPlaneName.Text;
            string type = cbxPlaneType.Text;
            int speed = (int)numPlaneSpeed.Value;
            int maintenanceTime = (int)numPlaneMaintenanceTime.Value;
            int boardingTime = (int)numPlaneBoardingTime.Value;
            int unboardingTime = (int)numPlaneUnboardingTime.Value;
            _controller.AddPlane(airportId, name, type, speed, maintenanceTime, boardingTime, unboardingTime);
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        _controller.SaveFrequencies((int)numFrequencyFire.Value, (int)numFrequencyRescue.Value, (int)numFrequencyRecon.Value);
        _controller.SaveScenario();
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        _controller.LoadScenario();
    }

    private void btnEmpty_Click(object sender, EventArgs e)
    {
        _controller.EmptyScenario();
    }

    private void lvwAirport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            UpdatePlanes(_controller.GetPlanes(lvwAirport.SelectedIndices[0]));
        }
        catch (Exception)
        {
            // ignored
        }
    }

    public void UpdateAirports(string[] airports)
    {
        lvwAirport.Items.Clear();

        foreach (string airport in airports)
        {
            ListViewItem airportItem = new ListViewItem(airport.Split(";"));
            lvwAirport.Items.Add(airportItem);
        }
    }

    public void UpdatePlanes(string[] planes)
    {
        lvwAirplane.Items.Clear();
        foreach (string plane in planes)
        {
            string[] planeValues = plane.Split(";");

            ListViewItem planeItem = new ListViewItem(planeValues);
            lvwAirplane.Items.Add(planeItem);
        }
    }

    public void OnEmptyScenario()
    {
        UpdateAirports(new string[0]);
        UpdatePlanes(new string[0]);
    }

    private void coordsPickerBtn_Click(object sender, EventArgs e)
    {
        CoordsPickerForm coordsPicker = new CoordsPickerForm();

        coordsPicker.ShowDialog();

        if (coordsPicker.ChosenCoordinates.X < 4)
            numAirportPositionX.Value = 5;
        else if (coordsPicker.ChosenCoordinates.X > 786)
            numAirportPositionX.Value = 780;
        else 
            numAirportPositionX.Value = coordsPicker.ChosenCoordinates.X;
        if (coordsPicker.ChosenCoordinates.Y < 30)
            numAirportPositionY.Value = 30;
        else if (coordsPicker.ChosenCoordinates.Y > 418)
            numAirportPositionY.Value = 418;
        else
            numAirportPositionY.Value = coordsPicker.ChosenCoordinates.Y;
    }
}
