using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;

public class FlyingRescue : FlyingSupport
{
    public FlyingRescue() { }
    public override string ToString()
    {
        return "The plane is flying";
    }
}
