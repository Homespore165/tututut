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
		_form = new Form1(this);
	}
	
	public void AddPlane(int airportId, string name, string type, int speed, int maintenanceTime, int boardingTime = 0, int unboardingTime = 0)
	{
		_scenario.AddPlane(airportId, name, type, speed, maintenanceTime, boardingTime, unboardingTime);
	}

	public void AddAirport(string name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		_scenario.AddAirport(name, x, y, passengerTraffic, cargoTraffic);
	}

	public void EditAirport(int airportId, string name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		_scenario.EditAirport(airportId, name, x, y, passengerTraffic, cargoTraffic);
	}

	public void DeleteAirport(int airportId)
	{
		_scenario.DeleteAirport(airportId);
	}

	public void SaveScenario()
	{
		_scenario.Save();
	}

	public void LoadScenario()
	{
		throw new NotImplementedException();
	}
	
	public void EmptyScenario()
	{
		_scenario = new Scenario();
	}

	public void Test()
	{
		AddAirport("abc", 1, 2, 3, 4);
		AddAirport("def", 5, 6, 7, 8);
		AddAirport("ghi", 5, 6, 7, 8);
		AddPlane(0, "jkl", "Cargo", 6, 7, 8);
		AddPlane(0, "jkl", "Cargo", 6, 7, 8);
		_scenario.Save();
	}
}