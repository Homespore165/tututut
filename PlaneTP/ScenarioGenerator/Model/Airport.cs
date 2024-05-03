using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ScenarioGenerator.Model;

public class Airport : IXmlSerializable
{
	private string _name;
	public string Name
	{
		get => _name;
		set => _name = value;
	}
	
	private List<Plane> _planes;
	public List<Plane> Planes
	{
		get => _planes;
		set => _planes = value;
	}
	
	private int _passengerTraffic;
	public int PassengerTraffic
	{
		get => _passengerTraffic;
		set => _passengerTraffic = value;
	}
	
	private int _cargoTraffic;
	public int CargoTraffic
	{
		get => _cargoTraffic;
		set => _cargoTraffic = value;
	}
	
	private Position _position;
	public Position Position
	{
		get => _position;
		set => _position = value;
	}
	
	public delegate void AirportEventHandler();
	private event AirportEventHandler AirportChanged;
	public event AirportEventHandler OnPlaneUpdate
	{
		add => AirportChanged += value;
		remove => AirportChanged -= value;
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