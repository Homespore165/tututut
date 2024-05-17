﻿namespace Simulator.Model;

public abstract class PlaneSupport : Plane
{
	public PlaneSupport(string name, int x, int y, int speed, int maintenanceTime) : base(name, speed, maintenanceTime)
	{
	}
	
	protected PlaneSupport() {}
}