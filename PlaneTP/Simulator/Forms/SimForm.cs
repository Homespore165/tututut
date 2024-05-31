namespace Simulator;

public partial class SimForm : Form
{
	private Controller _controller;
	public SimForm()
	{
		_controller = Controller.Instance;
		InitializeComponent();
	}
}