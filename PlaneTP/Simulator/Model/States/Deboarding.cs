using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;

public class Deboarding : State
{
    int timeToCompletion;
    public Deboarding() { }
    public override string ToString()
    {
        return "The plane is deboarding";
    }
}
