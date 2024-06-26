﻿using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public delegate void OnPlaneUpdate(string[] planes);
public class Airport : IXmlSerializable
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
	/// Constructeur d'aéroport
	/// </summary>
	/// <param name="name">Nom</param>
	/// <param name="position">Position</param>
	/// <param name="passengerTraffic">Fréquence de traffic passager</param>
	/// <param name="cargoTraffic">Fréquence de traffic cargo</param>
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
    /// Constructeur d'aéroport
    /// </summary>
    /// <param name="name">Nom</param>
    /// <param name="x">Position X</param>
    /// <param name="y">Position Y</param>
    /// <param name="passengerTraffic">Fréquence de traffic passager</param>
    /// <param name="cargoTraffic">Fréquence de traffic cargo</param>
    public Airport(String name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		_name = name;
		_position = new Position(x, y);
		_passengerTraffic = passengerTraffic;
		_cargoTraffic = cargoTraffic;
		_planes = new List<Plane>();
		_clientsTransport = new List<ClientTransport>();
	}

	private Airport()
	{
		_planes = new List<Plane>();
		_clientsTransport = new List<ClientTransport>();
	}
	
	/// <summary>
	/// Ajouter un avion dans l'aéroport
	/// </summary>
	/// <param name="name">Nom</param>
	/// <param name="type">Type</param>
	/// <param name="speed">Vitesse</param>
	/// <param name="maintenanceTime">Temps de maintenance</param>
	/// <param name="boardingTime">Temps d'embarquement</param>
	/// <param name="unboardingTime">Temps de débarquement</param>
	public void AddPlane(string name, string type, int speed, int maintenanceTime, int boardingTime, int unboardingTime)
	{
		_planes.Add(PlaneFactory.Instance.CreatePlane(name, type, speed, maintenanceTime, this, boardingTime, unboardingTime));
	}
	
	/// <summary>
	/// Ajouter un client dans l'aéroport
	/// </summary>
	/// <param name="client">Le client à ajouter</param>
	public void AddClient(ClientTransport client)
	{
		_clientsTransport.Add(client);
	}
	
	/// <summary>
	/// Obtenir le schéma XML
	/// </summary>
	/// <returns></returns>
	public XmlSchema? GetSchema()
	{
		return null;
	}
	
	/// <summary>
	/// Lire le stream XML
	/// </summary>
	/// <param name="reader">Le reader avec le stream XML</param>
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
	/// Écrire au stream XML
	/// </summary>
	/// <param name="writer">Le writer du stream XML</param>
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
	/// Obtenir la liste des avions de l'aéroport
	/// </summary>
	/// <returns>La liste d'avions</returns>
	public string[] GetPlanes()
	{
		return _planes.Select(p => p.ToString()).ToArray();
	}

	/// <summary>
	/// Génére des clients de passagers
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
	/// Génére des clients de cargo
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
	/// Génére des clients divers
	/// </summary>
	private void GenerateClient()
	{
		GeneratePassenger();
		GenerateCargo();
	}

	/// <summary>
	/// Avance d'une étape de temps
	/// </summary>
	public void TimeStep()
	{
		GenerateClient();
		_planes.RemoveAll(p => p.Airport != this);

		int index = 0;
		while (index < _planes.Count) {
			_planes[index].TimeStep();
			index++;
		}
	}

	/// <summary>
	/// Génere un string représentant la classe
	/// </summary>
	/// <returns>Un string</returns>
	public override string ToString()
	{
		string name = _name;
		string clients = string.Join(";", _clientsTransport.Select(c => c.ToString()));
		return $"{name};{_position.X};{_position.Y};{clients}";
	}

	/// <summary>
	/// Enleve un client de la liste de clients
	/// </summary>
	/// <param name="clientTransport"></param>
	public void RemoveClient(ClientTransport clientTransport)
	{
		_clientsTransport.Remove(clientTransport);
	}

	/// <summary>
	/// Enleve un avions de l'aéroport
	/// </summary>
	/// <param name="plane"></param>
	public void RemovePlane(Plane plane)
	{
		_planes.Remove(plane);
	}
}