namespace ScenarioGenerator.Model;

public abstract class PlaneSupport : Plane
{
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="x">position en X</param>
	/// <param name="y">position en Y</param>
	/// <param name="speed">Vitesse</param>
	/// <param name="maintenanceTime">Temps de maintenance</param>
	public PlaneSupport(string name, int speed, int maintenanceTime) : base(name, speed, maintenanceTime)
	{
	}
	
	protected PlaneSupport() {}
	/// <summary>
	/// Sérialise l'objet en String
	/// </summary>
	/// <returns>une string signifiant l'avion</returns>
    public override string? ToString()
    {
		return base.ToString() + "; ; ";
    }
}