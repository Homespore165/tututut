namespace Simulator.Model;

public class Deboarding : State
{
    private int _timeToCompletion;
    private ClientTransport _client;
    
    public Deboarding(PlaneTransport plane, ClientTransport client) : base(plane)
    {
        _timeToCompletion = plane.UnboardTime;
        _client = client;
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
