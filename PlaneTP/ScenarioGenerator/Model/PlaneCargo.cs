namespace ScenarioGenerator.Model;

public class PlaneCargo : PlaneTransport
{
	public PlaneCargo(string name, int x, int y, int speed, int maintenanceTime, int timeToBoard, int timeToUnboard)
		: base(name, x, y, speed, maintenanceTime, timeToBoard, timeToUnboard)
	{
	}
}