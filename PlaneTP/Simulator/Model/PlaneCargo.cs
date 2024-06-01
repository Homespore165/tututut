namespace Simulator.Model;

public class PlaneCargo : PlaneTransport
{
	public PlaneCargo(string name, int x, int y, int speed, int maintenanceTime, Airport airport ,int boardingTime, int unboardTime)
		: base(name, x, y, speed, maintenanceTime, airport, boardingTime, unboardTime)
	{
	}
	
	private PlaneCargo() {}
}