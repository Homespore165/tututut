namespace Simulator.Model;

public class PlaneRecon : PlaneSupport
{
	public PlaneRecon(string name, int x, int y, int speed, int maintenanceTime, Airport airport) : base(name, x, y, speed,
		maintenanceTime, airport)
	{
	}
	
	public PlaneRecon() {}

	public override List<Client> GetPossibleClients()
	{
		return Scenario.Instance.ClientsRecon.Cast<Client>().ToList();
	}
	
	public override void StartFlightProcess(Client client)
	{
		State = new FlyingRecon(this, Airport.Position, (ClientRecon)client);
	}
}