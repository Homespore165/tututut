using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;

public class Maintenance : State
{
    int timeToCompletion;
    public Maintenance() { } 
    public override string ToString()
    {
        return "The plane is in maintenance";
    }
}
