namespace Simulator.Model;

public class ClientFire : ClientSupport
{
    public int Intensity { get; set; }
    
    public ClientFire(Position position, int intensity) : base(position)
    {
        Intensity = intensity;
    }
}
