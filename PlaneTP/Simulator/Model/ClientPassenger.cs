namespace Simulator.Model;

public class ClientPassenger : ClientTransport
{
    public int NbPassenger { get; set; }
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="destination">Aéroport de destination</param>
    public ClientPassenger(Airport destination) : base(destination)
    {
        Random r = new Random();
        NbPassenger = r.Next(0, 100);
        Size = NbPassenger;
    }
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="destination">Aéroport de destination</param>
    /// <param name="nbPassenger">nombre de passagers</param>
    public ClientPassenger(Airport destination, int nbPassenger): base(destination)
    {
        NbPassenger = nbPassenger;
    }
    /// <summary>
    /// Prendre une portion du nombre de passagers 
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public override ClientTransport Split(double size)
    {
        NbPassenger -= (int)size;
        Size -= size;
        return new ClientPassenger(Destination, (int)size);
    }
    /// <summary>
    /// Sérialise le client en String
    /// </summary>
    /// <returns>une string signifiant le nombre de passagers et la destination des passagers</returns>
    public override String ToString()
    {
        return $"{NbPassenger} passagers à destination de {Destination.Name}";
    }
}