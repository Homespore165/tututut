using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;

public abstract class State
{
    Plane parent;
    public void TimeStep(int t) { }
}
