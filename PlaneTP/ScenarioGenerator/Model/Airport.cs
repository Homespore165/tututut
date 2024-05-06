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
	
	public Airport(String name, Position position, int passengerTraffic, int cargoTraffic)
	{
		_name = name;
		_position = position;
		_passengerTraffic = passengerTraffic;
		_cargoTraffic = cargoTraffic;
		_planes = new List<Plane>();
	}

	public Airport(String name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		_name = name;
		_position = new Position(x, y);
		_passengerTraffic = passengerTraffic;
		_cargoTraffic = cargoTraffic;
		_planes = new List<Plane>();
	}
	
	public delegate void AirportEventHandler();
	private event AirportEventHandler AirportChanged;
	public event AirportEventHandler OnPlaneUpdate
	{
		add => AirportChanged += value;
		remove => AirportChanged -= value;
	}
	
	public void AddPlane(string name, string type, int speed, int maintenanceTime, int boardingTime, int unboardingTime)
	{
		_planes.Add(PlaneFactory.Instance.CreatePlane(name, type, speed, maintenanceTime, boardingTime, unboardingTime));
		AirportChanged?.Invoke();
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