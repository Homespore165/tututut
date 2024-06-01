namespace Simulator.Model;

public abstract class FlyingSupport: Flying
{
    protected Airport _source;
    protected ClientSupport _client;

    protected FlyingSupport(Plane plane, ClientSupport client) : base(plane)
    {
        //_source = plane.CurrentAirport; //TODO: How do we do this?
        _client = client;
    }
    
    public override void TimeStep()
    {
        throw new NotImplementedException();
    }
}
