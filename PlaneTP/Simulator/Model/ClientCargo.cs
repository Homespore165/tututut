namespace Simulator.Model;
public class ClientCargo : ClientTransport
{
    public double WeightInTons { get; set; }
    public ClientCargo(Airport destination) : base(destination)
    {
        Random r = new Random();
        WeightInTons = r.NextDouble() * r.Next(0, 1000);
        Size = WeightInTons;
    }
    
    public ClientCargo(Airport destination, double weightInTons) : base(destination)
    {
        WeightInTons = weightInTons;
        Size = WeightInTons;
    }

    public override ClientCargo Split(double size)
    {
        Size -= size;
        WeightInTons -= size;
        return new ClientCargo(Destination, size);
    }
}