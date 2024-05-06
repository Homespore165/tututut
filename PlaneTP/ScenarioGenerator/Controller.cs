using ScenarioGenerator.Model;

namespace ScenarioGenerator;

public class Controller
{
	private static Controller _instance;
	public static Controller Instance => _instance ??= new Controller();
	
	private Scenario _scenario;
	
	private Form _form;
	public Form Form
	{
		get => _form;
		set => _form = value;
	}
		
	private Controller()
	{
		_scenario = new Scenario();
		_form = new Form1();
	}
	
	public void AddPlane(int airportId, string name, string type, int speed, int maintenanceTime, int boardingTime = 0, int unboardingTime = 0)
	{
		_scenario.AddPlane(airportId, name, type, speed, maintenanceTime, boardingTime, unboardingTime);
	}

	public void AddAirport()
	{
		throw new NotImplementedException();
	}
}