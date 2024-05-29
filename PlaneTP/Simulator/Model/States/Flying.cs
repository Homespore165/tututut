using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;

public abstract class Flying
{
    Airport source;
    Position position;
    Position destination;
    public void Fly(int t) { }
}
