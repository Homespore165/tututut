namespace Simulator.Model;

public class FlyingRecon : FlyingSupport
{
    public FlyingRecon(Plane plane, ClientRecon client) : base(plane, client) {}
    
    public override void NewPosition()
    {
        throw new NotImplementedException();
    }
        
    public override void TimeStep()
    {
        NewPosition();
        if (_plane.Airport.Position.X == _plane.Position.X  && _plane.Airport.Position.Y == _plane.Position.Y)
        {
            _plane.State = new Maintenance(_plane);
        }
    }
}
