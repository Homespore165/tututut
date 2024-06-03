using System.Xml;
using System.Xml.Serialization;

namespace Simulator.Model;

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
	protected PlaneTransport()
	{
		Capacity = new Random().Next(100, 300);
	}
	public int Capacity { get; set; }

	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="speed">Vitesse de l'avion</param>
	/// <param name="maintenanceTime">Temps de maintenance de l'avion</param>
	/// <param name="airport">Aéroport au moment de création</param>
	/// <param name="x">Position de l'avion en X</param>
	/// <param name="y">Position de l'avion en y</param>
	/// <param name="boardingTime">Temps d'embarquement de l'avion</param>
	/// <param name="unboardTime">temps de débarquement</param>
	public PlaneTransport(string name, int x, int y, int speed, int maintenanceTime, Airport airport, int boardingTime, int unboardTime) : base(name, speed, maintenanceTime, airport)
	{
		_boardingTime = boardingTime;
		_unboardTime = unboardTime;
		Capacity = new Random().Next(100, 300);
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