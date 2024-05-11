namespace Simulator.Model;

public class PlanePassenger : PlaneTransport
{
	public PlanePassenger(string name, int x, int y, int speed, int maintenanceTime, int boardingTime, int unboardTime)
		: base(name, x, y, speed, maintenanceTime, boardingTime, unboardTime)
	{
	}
	
	private PlanePassenger() {}
}