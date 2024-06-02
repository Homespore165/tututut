using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public delegate void OnPlaneUpdate(string[] planes);
public class Airport 
{
	public Scenario Scenario { get; set; }
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
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">nom de l'aéroport</param>
	/// <param name="position">position de l'aéroport</param>
	/// <param name="passengerTraffic"></param>
	/// <param name="cargoTraffic"></param>
	public Airport(String name, Position position, int passengerTraffic, int cargoTraffic)
	{
		_name = name;
		_position = position;
		_passengerTraffic = passengerTraffic;
		_cargoTraffic = cargoTraffic;
		_planes = new List<Plane>();
		_clientsTransport = new List<ClientTransport>();
	}
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">nom de l'aéroport</param>
	/// <param name="x">position en X</param>
	/// <param name="y">position en Y</param>
	/// <param name="passengerTraffic"></param>
	/// <param name="cargoTraffic"></param>
	public Airport(String name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		_name = name;
		_position = new Position(x, y);
		_passengerTraffic = passengerTraffic;
		_cargoTraffic = cargoTraffic;
		_planes = new List<Plane>();
		_clientsTransport = new List<ClientTransport>();
	}
	/// <summary>
	/// Constructeur
	/// </summary>
	private Airport()
	{
		_planes = new List<Plane>();
		_clientsTransport = new List<ClientTransport>();
	}
	/// <summary>
	/// Ajouter un avion à l'aéroport
	/// </summary>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="speed">Vitesse</param>
	/// <param name="maintenanceTime">Temps de maintenance</param>
	/// <param name="boardingTime">Temps d'embarquement</param>
	/// <param name="unboardingTime">Temps de débarquement</param>
	/// <param name="type">Type de l'avion</param>
	public void AddPlane(string name, string type, int speed, int maintenanceTime, int boardingTime, int unboardingTime)
	{
		_planes.Add(PlaneFactory.Instance.CreatePlane(name, type, speed, maintenanceTime, this, boardingTime, unboardingTime));
	}
	/// <summary>
	/// Ajouter un avion à l'aéroport
	/// </summary>
	/// <param name="client">client</param>
	public void AddClient(ClientTransport client)
	{
		_clientsTransport.Add(client);
	}
	
	public XmlSchema? GetSchema()
	{
		return null;
	}
	/// <summary>
	/// Charger les aéroports d'un fichier XML
	/// </summary>
	/// <param name="reader">le fichier XML</param>
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
			_planes.Add(PlaneFactory.Instance.CreatePlane(planeName, planeType, planeSpeed, planeMaintenanceTime, this, boardingTime, unboardingTime));
			reader.ReadEndElement();
		}
		reader.ReadEndElement();
	}
	/// <summary>
	/// Sérialise ses avions en String
	/// </summary>
	/// <returns>une string</returns>
	public string[] GetPlanes()
	{
		return _planes.Select(p => p.ToString()).ToArray();
	}
	/// <summary>
	/// Génère des clients de type passagers
	/// </summary>
	private void GeneratePassenger()
	{
		Random r = new Random();
		if (r.Next(0, 101) < _passengerTraffic)
		{
			ClientTransportFactory factory = ClientTransportFactory.Instance;
			Airport destination = Scenario.GetRandomAirportExcluding(this);
			_clientsTransport.Add(factory.CreateClientTransport("Passenger", destination));
		}
	}
	/// <summary>
	/// Génère des clients de type cargo
	/// </summary>
	private void GenerateCargo()
	{
		Random r = new Random();
		if (r.Next(0, 101) < _cargoTraffic)
		{
			ClientTransportFactory factory = ClientTransportFactory.Instance;
			Airport destination = Scenario.GetRandomAirportExcluding(this);
			_clientsTransport.Add(factory.CreateClientTransport("Cargo", destination));
		}
	}
	/// <summary>
	/// Génère des clients 
	/// </summary>
	private void GenerateClient()
	{
		GeneratePassenger();
		GenerateCargo();
	}
	/// <summary>
	/// Gestion d'avancer d'un seul pas
	/// </summary>
	public void TimeStep()
	{
		GenerateClient();
		_planes.RemoveAll(p => p.Airport != this);
		_planes.ForEach(p => p.TimeStep());
	}
	/// <summary>
	/// Sérialise l'objet en String
	/// </summary>
	/// <returns>une string signifiant l'aéroport</returns>
	public override string ToString()
	{
		string name = _name;
		string clients = string.Join(";", _clientsTransport.Select(c => c.ToString()));
		return $"{name};{_position.X};{_position.Y};{clients}";
	}
	/// <summary>
	/// Supprime un client de sa liste
	/// </summary>
	/// <param name="clientTransport">le client à retirer</param>
	public void RemoveClient(ClientTransport clientTransport)
	{
		_clientsTransport.Remove(clientTransport);
	}

	public void RemovePlane(Plane plane)
	{
		_planes.Remove(plane);
	}
}