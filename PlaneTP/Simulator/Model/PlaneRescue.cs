namespace Simulator.Model;

public class PlaneRescue : PlaneSupport
{
	public PlaneRescue(string name, int x, int y, int speed, int maintenanceTime, Airport airport) : base(name, x, y, speed,
		maintenanceTime, airport)
	{
		
	}
	
	public PlaneRescue() {}

	public override List<Client> GetPossibleClients()
	{
		return Scenario.Instance.ClientsRescue.Cast<Client>().ToList();
	}

	public override void StartFlightProcess(Client client)
	{
		State = new FlyingRescue(this, Airport.Position, (ClientRescue)client);
		Scenario.Instance.RemoveClient((ClientSupport)client);
	}
}