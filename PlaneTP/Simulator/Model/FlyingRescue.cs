namespace Simulator.Model;

public class FlyingRescue : FlyingSupport
{
    public FlyingRescue(Plane plane, ClientRescue client) : base(plane, client) {}
    
    public override void TimeStep()
    {
        throw new NotImplementedException();
    }
}
