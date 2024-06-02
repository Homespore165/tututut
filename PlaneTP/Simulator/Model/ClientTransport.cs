using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;
public abstract class ClientTransport : Client
{
    public Airport Destination { get; set; }

    public Position Position => Destination.Position;
    public double Size { get; set; }
    public ClientTransport()
    {
    }
    
    public ClientTransport(Airport destination)
    {
        Destination = destination;
    }
    
    public abstract ClientTransport Split(double size);
}
