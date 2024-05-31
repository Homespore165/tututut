namespace Simulator;

public partial class Form1 : Form
{
	private Controller _controller;
	public Form1(Controller controller)
	{
		_controller = controller;
		InitializeComponent();
	}
}