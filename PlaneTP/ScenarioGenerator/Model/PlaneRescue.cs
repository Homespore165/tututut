namespace ScenarioGenerator.Model;

public class PlaneRescue : PlaneSupport
{
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="x">position en X</param>
	/// <param name="y">position en Y</param>
	/// <param name="speed">Vitesse</param>
	/// <param name="maintenanceTime">Temps de maintenance</param>
	public PlaneRescue(string name, int speed, int maintenanceTime) : base(name, speed, maintenanceTime) {}
	
	public PlaneRescue() {}
}