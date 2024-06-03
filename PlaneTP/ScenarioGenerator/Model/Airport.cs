using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ScenarioGenerator.Model;

public delegate void OnPlaneUpdate(string[] planes);
public class Airport : IXmlSerializable
{
	private event OnPlaneUpdate OnPlaneUpdate;
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
	}
	/// <summary>
	/// Constructeur
	/// </summary>
	private Airport()
	{
		_planes = new List<Plane>();
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
		_planes.Add(PlaneFactory.Instance.CreatePlane(name, type, speed, maintenanceTime, boardingTime, unboardingTime));
		_planes.ForEach(p => Console.WriteLine(p.ToString()));
		NotifyPlaneChanged();
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
		while (reader.IsStartElement())
		{
			string planeType = reader.Name.Substring("Plane".Length);
			reader.ReadStartElement();
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
	/// <summary>
	/// Vider la liste de mes avions
	/// </summary>
	public void ClearPlanes()
	{
		_planes.Clear();
		NotifyPlaneChanged();
	}
	/// <summary>
	///  Enregistrer un aéroport en XML
	/// </summary>
	/// <param name="writer">le fichier XML</param>
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
	/// <summary>
	/// Sérialise l'objet en String
	/// </summary>
	/// <returns>une string signifiant l'aéroport</returns>
	public override string? ToString()
	{
		return _name + ";" + _position.X + ";" + _position.Y + ";" + _passengerTraffic + ";" + _cargoTraffic;
	}
	/// <summary>
	/// Gestion de l'événement : OnPlaneUpdate
	/// </summary>
	private void NotifyPlaneChanged()
	{
		OnPlaneUpdate?.Invoke(_planes.Select(p => p.ToString()).ToArray());
	}
	/// <summary>
	/// Méthode d'abonnement à l'événement : OnPlaneUpdate
	/// </summary>
	public void SubscribePlaneChanged(Action<string[]> updatePlanes)
	{
		OnPlaneUpdate += new OnPlaneUpdate(updatePlanes);
	}
	/// <summary>
	/// Méthode de désabonnement à l'événement : OnPlaneUpdate
	/// </summary>
	public void UnsubcribeAll()
	{
		OnPlaneUpdate = null;
	}
	/// <summary>
	/// Sérialise ses avions en String
	/// </summary>
	/// <returns>une string</returns>
	public string[] GetPlanes()
	{
		return _planes.Select(p => p.ToString()).ToArray();
	}
}