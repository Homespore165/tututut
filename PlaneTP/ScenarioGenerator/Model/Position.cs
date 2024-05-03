namespace ScenarioGenerator.Model;

public class Position
{
	private int _x;
	public int X
	{
		get => _x;
		set => _x = value;
	}
	
	private int _y;
	public int Y
	{
		get => _y;
		set => _y = value;
	}
	
	public Position(int x, int y)
	{
		_x = x;
		_y = y;
	}
}