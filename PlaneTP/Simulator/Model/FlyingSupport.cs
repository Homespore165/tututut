namespace Simulator.Model;

public abstract class FlyingSupport: Flying
{
    protected Airport _source;
    protected ClientSupport _client;

    protected FlyingSupport(Plane plane, ClientSupport client) : base(plane)
    {
        _source = plane.Airport; 
        _client = client;
    }
    public abstract void NewPosition();
}
