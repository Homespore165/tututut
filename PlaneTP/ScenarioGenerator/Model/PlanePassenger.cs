namespace ScenarioGenerator.Model;

public class PlanePassenger : PlaneTransport
{
	public PlanePassenger(string name, int x, int y, int speed, int maintenanceTime, int timeToBoard, int timeToUnboard)
		: base(name, x, y, speed, maintenanceTime, timeToBoard, timeToUnboard)
	{
	}
}