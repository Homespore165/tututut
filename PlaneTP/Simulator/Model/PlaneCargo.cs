namespace Simulator.Model;

public class PlaneCargo : PlaneTransport
{
	public PlaneCargo(string name, int x, int y, int speed, int maintenanceTime, int boardingTime, int unboardTime)
		: base(name, x, y, speed, maintenanceTime, boardingTime, unboardTime)
	{
	}
	
	private PlaneCargo() {}
}