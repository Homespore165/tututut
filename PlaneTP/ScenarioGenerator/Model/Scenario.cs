using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ScenarioGenerator.Model;

public class Scenario : IXmlSerializable
{
	private List<Airport> _airports;
	public List<Airport> Airports
	{
		get => _airports;
		set => _airports = value;
	}

	private int _frequencyFire;
	public int FrequencyFire
	{
		get => _frequencyFire;
		set => _frequencyFire = value;
	}
	
	private int _frequencyRecon;
	public int FrequencyRecon
	{
		get => _frequencyRecon;
		set => _frequencyRecon = value;
	}
	
	private int _frequencyRescue;
	public int FrequencyRescue
	{
		get => _frequencyRescue;
		set => _frequencyRescue = value;
	}
	
	public Scenario()
	{
		_airports = new List<Airport>();
		_frequencyFire = 0;
		_frequencyRecon = 0;
		_frequencyRescue = 0;
	}
	
	public Scenario(int frequencyFire, int frequencyRecon, int frequencyRescue)
	{
		_airports = new List<Airport>();
		_frequencyFire = frequencyFire;
		_frequencyRecon = frequencyRecon;
		_frequencyRescue = frequencyRescue;
	}
	
	public void AddAirport(Airport airport)
	{
		_airports.Add(airport);
	}
	
	public void AddAirport(string name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		throw new NotImplementedException();
	}
	
	public void EditAirport(int id, string name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		throw new NotImplementedException();
	}
	
	public void DeleteAirport(int id)
	{
		throw new NotImplementedException();
	}
	
	public void AddPlane(int airportId, string name, int speed, int maintenanceTime)
	{
		throw new NotImplementedException();
	}
	
	public XmlSchema? GetSchema()
	{
		return null;
	}

	public void ReadXml(XmlReader reader)
	{
		throw new NotImplementedException();
	}

	public void WriteXml(XmlWriter writer)
	{
		throw new NotImplementedException();
	}
}