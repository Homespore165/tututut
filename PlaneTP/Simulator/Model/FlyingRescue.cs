using System.Runtime.InteropServices.JavaScript;

namespace Simulator.Model;

public class FlyingRescue : FlyingSupport
{
    private delegate void Step();
    private Step _handler;

    public FlyingRescue(Plane plane, Position start, ClientRescue client) : base(plane, start, client)
    {
        _handler = Toward;
    }
    
    private void Toward()
    {
        base.Toward();
        
        if (_client.Position.X == _position.X && _client.Position.Y == _position.Y)
        {
            _handler = Back;
        }
    }
    
    private void Back()
    {
        base.Back();
        
        if (_source.Position.X == _position.X && _source.Position.Y == _position.Y)
        {
            _plane.State = new Maintenance(_plane);
        }
    }
        
    public override void TimeStep()
    {
        if (_plane.Airport.Position.X == _position.X  && _plane.Airport.Position.Y == _position.Y)
        {
            _plane.State = new Maintenance(_plane);
        }
    }
}
