namespace ScenarioGenerator.Model;

public abstract class PlaneTransport : Plane
{
	private int _timeToBoard;
	public int TimeToBoard
	{
		get => _timeToBoard;
		set => _timeToBoard = value;
	}
	
	private int _timeToUnboard;
	public int TimeToUnboard
	{
		get => _timeToUnboard;
		set => _timeToUnboard = value;
	}
	
	public PlaneTransport(string name, int x, int y, int speed, int maintenanceTime, int timeToBoard, int timeToUnboard) : base(name, x, y, speed, maintenanceTime)
	{
		_timeToBoard = timeToBoard;
		_timeToUnboard = timeToUnboard;
	}
}