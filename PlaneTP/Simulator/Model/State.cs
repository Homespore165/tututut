namespace Simulator.Model;

public abstract class State
{
    protected Plane _plane;

    protected State (Plane plane)
    {
        _plane = plane;
    }

    public abstract void TimeStep();
}
