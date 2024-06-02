namespace Simulator.Model;

public abstract class Flying: State
{
    protected Position _position;

    protected Flying(Plane plane, Position position) : base(plane)
    {
        _position = position;
    }
}
