namespace Simulator.Model;
public class ClientCargo : ClientTransport
{
    public double WeightInTons { get; set; }
    
    public ClientCargo(Airport destination) : base(destination)
    {
        Random r = new Random();
        WeightInTons = r.NextDouble() * r.Next(0, 1000);
    }
}