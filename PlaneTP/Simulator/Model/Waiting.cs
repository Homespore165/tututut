﻿namespace Simulator.Model;

public class Waiting : State
{
    public Waiting(Plane plane) : base(plane) {}
    
    public override void TimeStep()
    {
        throw new NotImplementedException();
    }
}
