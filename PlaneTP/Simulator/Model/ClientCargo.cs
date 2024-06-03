namespace Simulator.Model;
public class ClientCargo : ClientTransport
{
    public double WeightInTons { get; set; }

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="destination">Aéroport de destination</param>
    public ClientCargo(Airport destination) : base(destination)
    {
        Random r = new Random();
        WeightInTons = r.NextDouble() * r.Next(0, 1000);
        Size = WeightInTons;
    }

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="destination">Aéroport de destination</param>
    /// <param name="weightInTons">Poids du cargo</param>
    public ClientCargo(Airport destination, double weightInTons) : base(destination)
    {
        WeightInTons = weightInTons;
        Size = WeightInTons;
    }

    /// <summary>
    /// Prendre une portion du poids du client
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public override ClientCargo Split(double size)
    {
        Size -= size;
        WeightInTons -= size;
        return new ClientCargo(Destination, size);
    }

    /// <summary>
    /// Sérialise le client en String
    /// </summary>
    /// <returns>une string signifiant le poids et la destination du cargo</returns>
    public override String ToString()
    {
        return $"{WeightInTons} tonnes à destination de {Destination.Name}";
    }
}