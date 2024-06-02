using Simulator.Model;

namespace Simulator;

static class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.
		ApplicationConfiguration.Initialize();
		Controller c = Controller.Instance;
		Controller.Instance.TimeStep(5);
		Application.Run(Controller.Instance.Form);
	}
}