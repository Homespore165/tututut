using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;
public abstract class ClientTransport : Client
{
    public Airport Destination { get; set; }

    public double Size { get; set; }
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="destination">Aéroport de destination</param>
    public ClientTransport(Airport destination)
    {
        Destination = destination;
        Position = Destination.Position;
    }
    /// <summary>
    /// Prendre une portion de la quantité du client
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public abstract ClientTransport Split(double size);
}
