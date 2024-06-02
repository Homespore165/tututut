namespace Simulator.Model;

public class FlyingRecon : FlyingSupport
{
    public FlyingRecon(Plane plane, Position start, ClientRecon client) : base(plane, start, client) {}
    
    public override void NewPosition()
    {
        throw new NotImplementedException();
    }
        
    public override void TimeStep()
    {
        NewPosition();
        if (_plane.Airport.Position.X == _position.X  && _plane.Airport.Position.Y == _position.Y)
        {
            _plane.State = new Maintenance(_plane);
        }
    }
}
