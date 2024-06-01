namespace Simulator.Model;

public abstract class PlaneSupport : Plane
{
	public PlaneSupport(string name, int x, int y, int speed, int maintenanceTime, Airport airport) : base(name, speed, maintenanceTime, airport)
	{
	}
	
	protected PlaneSupport() {}
}