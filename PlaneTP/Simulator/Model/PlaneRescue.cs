namespace Simulator.Model;

public class PlaneRescue : PlaneSupport
{
	public PlaneRescue(string name, int x, int y, int speed, int maintenanceTime, Airport airport) : base(name, x, y, speed,
		maintenanceTime, airport)
	{
		
	}
	
	public PlaneRescue() {}
}