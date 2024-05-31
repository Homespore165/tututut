using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ScenarioGenerator.Model;

public abstract class Plane
{
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="position">Position de l'avion</param>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="speed">Vitesse</param>
	/// <param name="maintenanceTime">Temps de maintenance</param>
	protected Plane(string name, Position position, int speed, int maintenanceTime)
	{
		_name = name;
		_speed = speed;
		_maintenanceTime = maintenanceTime;
	}

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
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="speed">Vitesse</param>
	/// <param name="maintenanceTime">Temps de maintenance</param>
	public Plane(string name, int speed, int maintenanceTime)
	{
		_name = name;
		_speed = speed;
		_maintenanceTime = maintenanceTime;
	}
	
	protected Plane() {}

	public XmlSchema? GetSchema()
	{
		return null;
	}
	/// <summary>
	///  Enregistrer un avion en XML
	/// </summary>
	/// <param name="writer">le fichier XML</param>
	public virtual void WriteXml(XmlWriter writer)
	{
		writer.WriteElementString("Name", _name);
		writer.WriteElementString("Speed", _speed.ToString());
		writer.WriteElementString("MaintenanceTime", _maintenanceTime.ToString());
	}
	/// <summary>
	/// Sérialise l'objet en String
	/// </summary>
	/// <returns>une string signifiant l'avion</returns>
	public override string? ToString()
	{
		return _name + ";" + GetType().Name + ";" + _speed + ";" + _maintenanceTime;
	}
}