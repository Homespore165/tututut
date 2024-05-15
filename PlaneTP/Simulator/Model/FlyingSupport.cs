using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;

public abstract class FlyingSupport
{
    ClientSupport clientSupport;

    Position CalculatePath(int t)
    {
        Position test = new Position(0,0);
        return test;
    }
}
