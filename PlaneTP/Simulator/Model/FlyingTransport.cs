namespace Simulator.Model;

public class FlyingTransport : Flying
{
    protected ClientTransport _client;

    public FlyingTransport(Plane plane, ClientTransport client) : base(plane)
    {
        _client = client;
    }
}