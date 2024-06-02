namespace Simulator.Model;

public class FlyingFire : FlyingSupport
{
    ClientFire _client;
    private delegate void Step();
    private Step _handler;
    public FlyingFire(Plane plane, Position start, ClientFire client) : base(plane, start, client)
    {
        _client = client;
        _handler = Toward;
    }

    private void Toward()
    {
        base.Toward();
        
        if (isAtDestination())
        {
            _client.Intensity--;
            _handler = Back;
        }
    }
    
    private void Back()
    {
        base.Back();
    
        if (_source.Position == _position)
        {
            _handler = _client.Intensity > 0 ? Toward : () => _plane.State = new Maintenance(_plane);
        }
    }
        
    public override void TimeStep()
    {
        _handler();
    }
}
