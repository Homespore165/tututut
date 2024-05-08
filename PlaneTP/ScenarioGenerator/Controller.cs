using System.Xml;
using ScenarioGenerator.Model;

namespace ScenarioGenerator;

public class Controller
{
	private static Controller _instance;
	public static Controller Instance => _instance ??= new Controller();
	
	private Scenario _scenario;
	
	private Form1 _form;
	public Form1 Form
	{
		get => _form;
		set => _form = value;
	}
		
	private Controller()
	{
		_scenario = new Scenario();
		_form = new Form1(this);
		_scenario.SubscribeAirportUpdate(_form.UpdateAirports);
		_scenario.SubscribePlaneUpdate(_form.UpdatePlanes);
	}
	
	public void AddPlane(int airportId, string name, string type, int speed, int maintenanceTime, int boardingTime = 0, int unboardingTime = 0)
	{
		_scenario.AddPlane(airportId, name, type, speed, maintenanceTime, boardingTime, unboardingTime);
	}

	public void AddAirport(string name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		_scenario.AddAirport(name, x, y, passengerTraffic, cargoTraffic);
		_scenario.SubscribePlaneUpdate(_form.UpdatePlanes);
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

	public string[] GetPlanes(int airportId)
	{
		return _scenario.GetPlanes(airportId);
	}
}