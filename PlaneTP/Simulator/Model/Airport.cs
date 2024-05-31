using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public delegate void OnPlaneUpdate(string[] planes);
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
	
	private List<ClientTransport> _clientsTransport;
	public List<ClientCargo> ClientsCargo => _clientsTransport.OfType<ClientCargo>().ToList();
	public List<ClientPassenger> ClientsPassenger => _clientsTransport.OfType<ClientPassenger>().ToList();

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

	private Airport()
	{
		_planes = new List<Plane>();
	}
	
	public void AddPlane(string name, string type, int speed, int maintenanceTime, int boardingTime, int unboardingTime)
	{
		_planes.Add(PlaneFactory.Instance.CreatePlane(name, type, speed, maintenanceTime, boardingTime, unboardingTime));
		_planes.ForEach(p => Console.WriteLine(p.ToString()));
	}
	
	public XmlSchema? GetSchema()
	{
		return null;
	}
	
	public void ReadXml(XmlReader reader)
	{
		reader.ReadStartElement();
		_name = reader.ReadElementString("Name");
		XmlSerializer positionSerializer = new XmlSerializer(typeof(Position));
		_position = (Position)positionSerializer.Deserialize(reader);
		_passengerTraffic = int.Parse(reader.ReadElementString("PassengerTraffic"));
		_cargoTraffic = int.Parse(reader.ReadElementString("CargoTraffic"));
		reader.ReadStartElement("Planes");
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			string planeType = reader.Name.Replace("Plane", "");
			reader.Read();
			string planeName = reader.ReadElementString("Name");
			int planeSpeed = int.Parse(reader.ReadElementString("Speed"));
			int planeMaintenanceTime = int.Parse(reader.ReadElementString("MaintenanceTime"));
			int boardingTime = reader.IsStartElement("BoardingTime") ? int.Parse(reader.ReadElementString("BoardingTime")) : 0;
			int unboardingTime = reader.IsStartElement("UnboardTime") ? int.Parse(reader.ReadElementString("UnboardTime")) : 0;
			_planes.Add(PlaneFactory.Instance.CreatePlane(planeName, planeType, planeSpeed, planeMaintenanceTime, boardingTime, unboardingTime));
			reader.ReadEndElement();
		}
		reader.ReadEndElement();
	}

	public void WriteXml(XmlWriter writer)
	{
		writer.WriteElementString("Name", Name);
    
		XmlSerializer positionSerializer = new XmlSerializer(typeof(Position));
		positionSerializer.Serialize(writer, Position);

		writer.WriteElementString("PassengerTraffic", PassengerTraffic.ToString());
		writer.WriteElementString("CargoTraffic", CargoTraffic.ToString());

		writer.WriteStartElement("Planes");
		foreach (var p in _planes)
		{
			XmlSerializer planeSerializer = new XmlSerializer(p.GetType());
			planeSerializer.Serialize(writer, p);
		}
		writer.WriteEndElement();
	}
	
	public string[] GetPlanes()
	{
		return _planes.Select(p => p.ToString()).ToArray();
	}

	private void GeneratePassenger()
	{
		Random r = new Random();
		if (r.Next(100) < _passengerTraffic)
		{
			_clientsTransport.Add(new ClientPassenger());
		}
	}
	
	private void GenerateCargo()
	{
		Random r = new Random();
		if (r.Next(100) < _cargoTraffic)
		{
			_clientsTransport.Add(new ClientCargo());
		}
	}
}