namespace Simulator.Model;

public class PlaneRescue : PlaneSupport
{
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="name">Nom de l'avion</param>
	/// <param name="speed">Vitesse de l'avion</param>
	/// <param name="maintenanceTime">Temps de maintenance de l'avion</param>
	/// <param name="airport">Aéroport au moment de création</param>
	/// <param name="x">Position de l'avion en X</param>
	/// <param name="y">Position de l'avion en y</param>
	public PlaneRescue(string name, int x, int y, int speed, int maintenanceTime, Airport airport) : base(name, x, y, speed,
		maintenanceTime, airport)
	{
		
	}
	public PlaneRescue() {}
	/// <summary>
	/// Retourne la liste des clients potentiel pour l'avion
	/// </summary>
	/// <returns>la liste des clients</returns>
	public override List<Client> GetPossibleClients()
	{
		return Scenario.Instance.ClientsRescue.Cast<Client>().ToList();
	}
	/// <summary>
	/// Commence le processus de vol 
	/// </summary>
	/// <param name="client">le client</param>
	public override void StartFlightProcess(Client client)
	{
		State = new FlyingRescue(this, Airport.Position, (ClientRescue)client);
		Scenario.Instance.RemoveClient((ClientSupport)client);
	}
}