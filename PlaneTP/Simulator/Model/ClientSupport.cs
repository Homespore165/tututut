using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;

public abstract class ClientSupport : Client
{
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="position">La position de l'incident</param>
    protected ClientSupport(Position position)
    {
        Position = (Position)position.Clone();
    }
}
