namespace Simulator.Model;

public class Maintenance : State
{
    private int _timeToCompletion;

    public Maintenance(Plane plane) : base(plane)
    {
        _timeToCompletion = plane.MaintenanceTime;
    }

    public override void TimeStep()
    {
        _timeToCompletion--;
        if (_timeToCompletion == 0)
        {
            _plane.State = new Waiting(_plane);
        }
    }
}
