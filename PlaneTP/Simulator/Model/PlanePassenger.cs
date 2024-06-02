namespace Simulator.Model;

public class PlanePassenger : PlaneTransport
{
	public PlanePassenger(string name, int x, int y, int speed, int maintenanceTime, Airport airport, int boardingTime, int unboardTime)
		: base(name, x, y, speed, maintenanceTime, airport, boardingTime, unboardTime)
	{
	}
	
	private PlanePassenger() {}
	
	public override List<Client> GetPossibleClients()
	{
		return Airport.ClientsPassenger.Cast<Client>().ToList();
	}

	public override void StartFlightProcess(Client client)
	{
		ClientTransport c = (ClientTransport)client;
		State = new Boarding(this, c);
		Airport = c.Destination;
	}
}