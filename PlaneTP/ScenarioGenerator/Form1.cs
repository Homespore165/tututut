namespace ScenarioGenerator;

public partial class Form1 : Form
{
    private Controller _controller;
    
    public Form1()
    {
        _controller = Controller.Instance;
        InitializeComponent();
    }
    
    private void btnAddAirport_Click(object sender, EventArgs e)
    {
        _controller.AddAirport();
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