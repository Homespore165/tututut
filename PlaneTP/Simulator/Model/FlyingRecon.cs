namespace Simulator.Model;

public class FlyingRecon : FlyingSupport
{
    public FlyingRecon(Plane plane, ClientRecon client) : base(plane, client) {}
    
    public override void TimeStep()
    {
        throw new NotImplementedException();
    }
}
