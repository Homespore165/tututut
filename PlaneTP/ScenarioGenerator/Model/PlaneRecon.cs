﻿namespace ScenarioGenerator.Model;

public class PlaneRecon : PlaneSupport
{
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="x">position en X</param>
	/// <param name="y">position en Y</param>
	/// <param name="speed">Vitesse</param>
	/// <param name="maintenanceTime">Temps de maintenance</param>
	public PlaneRecon(string name, int x, int y, int speed, int maintenanceTime) : base(name, x, y, speed,
		maintenanceTime)
	{
	}
	
	public PlaneRecon() {}
}