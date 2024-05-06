namespace ScenarioGenerator.Model;

public abstract class PlaneTransport : Plane
{
	private int _boardingTime;
	public int BoardingTime
	{
		get => _boardingTime;
		set => _boardingTime = value;
	}
	
	private int _unboardTime;
	public int UnboardTime
	{
		get => _unboardTime;
		set => _unboardTime = value;
	}
	
	public PlaneTransport(string name, int x, int y, int speed, int maintenanceTime, int boardingTime, int unboardTime) : base(name, x, y, speed, maintenanceTime)
	{
		_boardingTime = boardingTime;
		_unboardTime = unboardTime;
	}
}