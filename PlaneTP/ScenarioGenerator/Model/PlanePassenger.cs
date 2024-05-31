namespace ScenarioGenerator.Model;

public class PlanePassenger : PlaneTransport
{
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
	public PlanePassenger(string name, int x, int y, int speed, int maintenanceTime, int boardingTime, int unboardTime)
		: base(name, x, y, speed, maintenanceTime, boardingTime, unboardTime)
	{
	}
	
	private PlanePassenger() {}
}