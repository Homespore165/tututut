namespace Simulator.Model;

public class FlyingFire : FlyingSupport
{
    public FlyingFire(Plane plane, ClientFire client) : base(plane, client)
    {
    }
    public override void TimeStep()
    {
        throw new NotImplementedException();
    }
}
