using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;

public abstract class ClientSupport : Client
{
    private Position _position;

    protected ClientSupport(Position position)
    {
        _position = position;
    }
}
