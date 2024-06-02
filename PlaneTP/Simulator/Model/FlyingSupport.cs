namespace Simulator.Model;

public abstract class FlyingSupport: Flying
{
    protected Airport _source;
    protected ClientSupport _client;

    protected FlyingSupport(Plane plane, Position start, ClientSupport client) : base(plane, start)
    {
        _source = plane.Airport; 
        _client = client;
    }
    public abstract void NewPosition();
}
