using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public abstract class Plane
{
	public State State { get; set; }
	protected string _name;

	public string Name
	{
		get => _name;
		set => _name = value;
	}

	protected int _speed;

	public int Speed
	{
		get => _speed;
		set => _speed = value;
	}

	protected int _maintenanceTime;

	public int MaintenanceTime
	{
		get => _maintenanceTime;
		set => _maintenanceTime = value;
	}

	protected Plane()
	{
		State = new Waiting(this);
	}
	public Airport? Airport { get; set; }

	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="speed">Vitesse de l'avion</param>
	/// <param name="maintenanceTime">Temps de maintenance de l'avion</param>
	/// <param name="airport">Aéroport au moment de création</param>
	public Plane(string name, int speed, int maintenanceTime, Airport airport)
	{
		_name = name;
		_speed = speed;
		_maintenanceTime = maintenanceTime;
		Airport = airport;
		State = new Waiting(this);
	}

	public XmlSchema? GetSchema()
	{
		return null;
	}

	/// <summary>
	/// Lire le XML du scénario enregistré
	/// </summary>
	/// <param name="reader">le fichier à lire</param>
	/// 
	public void ReadXml(XmlReader reader)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Sérialise l'objet en String
	/// </summary>
	/// <returns>une string signifiant l'avion</returns>
	/// 
	public override string? ToString()
	{
		return _name + ";" + _speed + ";" + _maintenanceTime;
	}

	public abstract List<Client> GetPossibleClients();

	/// <summary>
	/// Gestion d'avancer d'un seul pas
	/// </summary>
	public void TimeStep()
	{
		State.TimeStep();
	}

	/// <summary>
	/// Commence le processus de vol selon le type de l'avion
	/// </summary>
	/// <param name="client">le client</param>
	public abstract void StartFlightProcess(Client client);
}