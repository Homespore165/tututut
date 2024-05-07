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
		Airport airport = new Airport(name, x, y, passengerTraffic, cargoTraffic);
		_airports.Add(airport);
	}
	
	public void EditAirport(int id, string name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		_airports[id] =	new Airport(name, x, y, passengerTraffic, cargoTraffic);
	}
	
	public void DeleteAirport(int id)
	{
		_airports.Remove(_airports[id]);
	}
	
	public void AddPlane(int airportId, string name, string type, int speed, int maintenanceTime, int boardingTime = 0, int unboardingTime = 0)
	{
		_airports[airportId].AddPlane(name, type, speed, maintenanceTime, boardingTime, unboardingTime);
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
		writer.WriteStartElement("Scenario");
		
		writer.WriteElementString("FrequencyFire", FrequencyFire.ToString());
		writer.WriteElementString("FrequencyRecon", FrequencyRecon.ToString());
		writer.WriteElementString("FrequencyRescue", FrequencyRescue.ToString());
		
		writer.WriteStartElement("Airports");
		
		XmlSerializer serializer = new XmlSerializer(typeof(Airport));
		foreach (Airport airport in _airports)
			serializer.Serialize(writer, airport);
		
		writer.Close();
	}

	public void Save()
	{
		WriteXml(XmlWriter.Create("../../../scenario.xml"));
	}
}