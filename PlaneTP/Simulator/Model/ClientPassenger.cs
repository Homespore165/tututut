namespace Simulator.Model;

public class ClientPassenger : ClientTransport
{
    public int NbPassenger { get; set; }
    public ClientPassenger(Airport destination) : base(destination)
    {
        Random r = new Random();
        NbPassenger = r.Next(0, 100);
        Size = NbPassenger;
    }
    
    public ClientPassenger(Airport destination, int nbPassenger): base(destination)
    {
        NbPassenger = nbPassenger;
    }
    
    public override ClientTransport Split(double size)
    {
        NbPassenger -= (int)size;
        Size -= size;
        return new ClientPassenger(Destination, (int)size);
    }
    
    public override String ToString()
    {
        return $"{NbPassenger} passagers à destination de {Destination.Name}";
    }
}