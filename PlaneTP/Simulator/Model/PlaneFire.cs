namespace Simulator.Model;

public class PlaneFire : PlaneSupport
{
	public PlaneFire(string name, int x, int y, int speed, int maintenanceTime, Airport airport) : base(name, x, y, speed,
		maintenanceTime, airport)
	{
		
	}
	
	private PlaneFire() {}
	
	public override List<Client> GetPossibleClients()
	{
		return Scenario.Instance.ClientsFire.Cast<Client>().ToList();
	}
	
	public override void StartFlightProcess(Client client)
	{
		State = new FlyingFire(this, Airport.Position, (ClientFire)client);
	}
}