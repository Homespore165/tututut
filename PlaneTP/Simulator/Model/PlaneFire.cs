namespace Simulator.Model;

public class PlaneFire : PlaneSupport
{
	public PlaneFire(string name, int x, int y, int speed, int maintenanceTime) : base(name, x, y, speed,
		maintenanceTime)
	{
		
	}
	
	private PlaneFire() {}
}