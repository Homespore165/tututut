namespace Simulator.Model;

public abstract class Flying: State
{
    private Position _position;

    protected Flying(Plane plane) : base(plane)
    {
        _position = plane.Position;
    }
}
