namespace Simulator.Model;

public class ClientPassenger : ClientTransport
{
    public int NbPassenger { get; set; }
    public ClientPassenger(Airport destination) : base(destination)
    {
        Random r = new Random();
        NbPassenger = r.Next(0, 100);
    }
    
    public ClientPassenger(Airport destination, int nbPassenger): base(destination)
    {
        NbPassenger = nbPassenger;
    }
}