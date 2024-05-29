using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;

public class Boarding : State
{
    int timeToCompletion;
    public Boarding() { }
    public override string ToString()
    {
        return "The plane is boarding";
    }
}
