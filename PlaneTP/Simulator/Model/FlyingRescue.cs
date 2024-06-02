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
        
        if (_client.Position == _position)
        {
            _handler = Back;
        }
    }
    
    private void Back()
    {
        base.Back();
        
        if (_source.Position == _position)
        {
            _plane.State = new Maintenance(_plane);
        }
    }
        
    public override void TimeStep()
    {
        if (_plane.Airport.Position == _position)
        {
            _plane.State = new Maintenance(_plane);
        }
    }
}
