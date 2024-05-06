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
        int x = (int)numAirportPositionX.Value;
        int y = (int)numAirportPositionY.Value;
        int minPassenger;

        //_controller.AddAirport();
    }
    
    private void btnEditAirport_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
    private void btnDeleteAirport_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
    private void btnAddPlane_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
    private void btnSave_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
    private void btnLoad_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
    private void btnEmpty_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}