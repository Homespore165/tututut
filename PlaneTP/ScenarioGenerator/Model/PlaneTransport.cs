using System.Xml;
using System.Xml.Serialization;

namespace ScenarioGenerator.Model;

public abstract class PlaneTransport : Plane
{
	private int _boardingTime;
	public int BoardingTime
	{
		get => _boardingTime;
		set => _boardingTime = value;
	}
	
	private int _unboardTime;
	public int UnboardTime
	{
		get => _unboardTime;
		set => _unboardTime = value;
	}
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="x">position en X</param>
	/// <param name="y">position en Y</param>
	/// <param name="speed">Vitesse</param>
	/// <param name="maintenanceTime">Temps de maintenance</param>
	/// <param name="boardingTime">Temps d'embarquement</param>
	/// <param name="unboardTime">Temps de débarquement</param>
	public PlaneTransport(string name, int x, int y, int speed, int maintenanceTime, int boardingTime, int unboardTime) : base(name, speed, maintenanceTime)
	{
		_boardingTime = boardingTime;
		_unboardTime = unboardTime;
	}
	
	protected PlaneTransport() {}
	/// <summary>
	///  Enregistrer un avion en XML
	/// </summary>
	/// <param name="writer">le fichier XML</param>
	public override void WriteXml(XmlWriter writer)
	{
		writer.WriteElementString("Name", _name);
		writer.WriteElementString("Speed", _speed.ToString());
		writer.WriteElementString("MaintenanceTime", _maintenanceTime.ToString());
		writer.WriteElementString("BoardingTime", _boardingTime.ToString());
		writer.WriteElementString("UnboardTime", _unboardTime.ToString());
	}
	/// <summary>
	/// Sérialise l'objet en String
	/// </summary>
	/// <returns>une string signifiant l'avion</returns>
	public override string? ToString()
	{
		return base.ToString() + ";" + _boardingTime + ";" + _unboardTime;
	}
}