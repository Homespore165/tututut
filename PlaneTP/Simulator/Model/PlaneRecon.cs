namespace Simulator.Model;

public class PlaneRecon : PlaneSupport
{
	public PlaneRecon(string name, int x, int y, int speed, int maintenanceTime, Airport airport) : base(name, x, y, speed,
		maintenanceTime, airport)
	{
	}
	
	public PlaneRecon() {}
}