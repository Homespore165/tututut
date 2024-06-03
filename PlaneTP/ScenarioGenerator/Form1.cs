namespace ScenarioGenerator;

public partial class Form1 : Form
{
    private Controller _controller;
    
    public Form1(Controller controller)
    {
        _controller = controller;
        InitializeComponent();
    }
    /// <summary>
    /// Déclenche l'événement : Ajout d'un aéroport
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
    /// <summary>
    /// Déclenche l'événement : Modification d'un aéroport
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnEditAirport_Click(object sender, EventArgs e)
    {
        if (lvwAirport.SelectedIndices.Count > 0)
        {
            int airportId = lvwAirport.SelectedIndices[0];
            string name = txbAirportName.Text;
            int x = (int)numAirportPositionX.Value;
            int y = (int)numAirportPositionY.Value;
            int passengerTraffic = (int)numAirportPassengerTraffic.Value;
            int cargoTraffic = (int)numAirportCargoTraffic.Value;
            _controller.EditAirport(airportId, name, x, y, passengerTraffic, cargoTraffic);
        }
    }
    /// <summary>
    /// Déclenche l'événement : Suppresion d'un aéroport
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnDeleteAirport_Click(object sender, EventArgs e)
    {
        if (lvwAirport.SelectedIndices.Count > 0)
        {
            int airportId = lvwAirport.SelectedIndices[0];
            _controller.DeleteAirport(airportId);
        }
    }
    /// <summary>
    /// Déclenche l'événement : Ajout d'un avion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            UpdatePlanes(_controller.GetPlanes(airportId));
        }
    }
    /// <summary>
    /// Déclenche l'événement : Sauvegarde du scénario actuel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSave_Click(object sender, EventArgs e)
    {
        _controller.SaveFrequencies((int)numFrequencyFire.Value, (int)numFrequencyRescue.Value, (int)numFrequencyRecon.Value);
        _controller.SaveScenario();
        MessageBox.Show("Le scénario à bien été enregistré");
    }
    /// <summary>
    /// Déclenche l'événement : Remplir le générateur à l'aide du scénario déja enregistré
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnLoad_Click(object sender, EventArgs e)
    {
        _controller.LoadScenario();
        numFrequencyFire.Value = _controller.GetFire();
        numFrequencyRecon.Value = _controller.GetRecon();
        numFrequencyRescue.Value = _controller.GetRescue();
    }
    /// <summary>
    /// Déclenche l'événement : Mise à 0 du générateur
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnEmpty_Click(object sender, EventArgs e)
    {
        _controller.EmptyScenario();
    }
    /// <summary>
    /// Sélection d'un aéroport par l'usager
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvwAirport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            UpdatePlanes(_controller.GetPlanes(lvwAirport.SelectedIndices[0]));
            txbAirportName.Text = lvwAirport.SelectedItems[0].SubItems[0].Text;
            numAirportPositionX.Value = int.Parse(lvwAirport.SelectedItems[0].SubItems[1].Text);
            numAirportPositionY.Value = int.Parse(lvwAirport.SelectedItems[0].SubItems[2].Text);
            numAirportPassengerTraffic.Value = int.Parse(lvwAirport.SelectedItems[0].SubItems[3].Text);
            numAirportCargoTraffic.Value = int.Parse(lvwAirport.SelectedItems[0].SubItems[4].Text);
        }
        catch (Exception)
        {
            // ignored
        }
    }
    /// <summary>
    /// Sélection d'un avion par l'usager
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvwAirplane_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txbPlaneName.Text = lvwAirplane.SelectedItems[0].SubItems[0].Text;
            cbxPlaneType.Text = lvwAirplane.SelectedItems[0].SubItems[1].Text;
            numPlaneSpeed.Value = int.Parse(lvwAirplane.SelectedItems[0].SubItems[2].Text);
            numPlaneMaintenanceTime.Value = int.Parse(lvwAirplane.SelectedItems[0].SubItems[3].Text);
            numPlaneBoardingTime.Value = int.Parse(lvwAirplane.SelectedItems[0].SubItems[4].Text);
            numPlaneUnboardingTime.Value = int.Parse(lvwAirplane.SelectedItems[0].SubItems[5].Text);
        } catch (Exception)
        {
            // ignored
        }
        
    }
    /// <summary>
    /// Réaction à un événemment
    /// </summary>
    /// <param name="airports">Tout les aéroports du scénario</param>
    public void UpdateAirports(string[] airports)
    {
        lvwAirport.Items.Clear();

        foreach (string airport in airports)
        {
            ListViewItem airportItem = new ListViewItem(airport.Split(";"));
            lvwAirport.Items.Add(airportItem);
        }
    }
    /// <summary>
    /// Réaction à un événemment
    /// </summary>
    /// <param name="planes">Tout les avion du scénario</param>
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
    /// <summary>
    /// Mise à 0 du générateur
    /// </summary>
    public void OnEmptyScenario()
    {
        UpdateAirports(new string[0]);
        UpdatePlanes(new string[0]);
        numFrequencyFire.Value = 0;
        numFrequencyRescue.Value = 0;
        numFrequencyRecon.Value = 0;
    }
    /// <summary>
    /// Fenêtre de géolocalisation pour la position d'un aéroport et ses validations
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void coordsPickerBtn_Click(object sender, EventArgs e)
    {
        CoordsPickerForm coordsPicker = new CoordsPickerForm();

        coordsPicker.ShowDialog();

        numAirportPositionX.Value = (int)Math.Clamp(coordsPicker.ChosenCoordinates.X, 0, numAirportPositionX.Maximum);
        numAirportPositionY.Value = (int)Math.Clamp(coordsPicker.ChosenCoordinates.Y, 0, numAirportPositionY.Maximum);
    }
}
