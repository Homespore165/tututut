namespace Simulator.Model;

public class ClientFire : ClientSupport
{
    public int Intensity { get; set; }
    
    public ClientFire(Position position) : base(position)
    {
        Random r = new Random();
        Intensity = r.Next(1, 6);
    }
    public ClientFire(Position position, int intensity) : base(position)
    {
        Intensity = intensity;
    }
}
