namespace Simulator.Model;

public class ClientFire : ClientSupport
{
    public int Intensity { get; set; }

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="position">La position de l'incident</param>
    public ClientFire(Position position) : base(position)
    {
        Random r = new Random();
        Intensity = r.Next(1, 6);
    }

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="position">La position de l'incendie</param>
    /// <param name="intensity">Le nombre d'aller-retours nécessaires</param>
    public ClientFire(Position position, int intensity) : base(position)
    {
        Intensity = intensity;
    }
}
