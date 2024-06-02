namespace Simulator.Model;

public class PlaneCargo : PlaneTransport
{
    public PlaneCargo(string name, int x, int y, int speed, int maintenanceTime, Airport airport ,int boardingTime, int unboardTime)
        : base(name, x, y, speed, maintenanceTime, airport, boardingTime, unboardTime)
    {
    }
	
    private PlaneCargo() {}

    public override List<Client> GetPossibleClients()
    {
        return Airport.ClientsCargo.Cast<Client>().ToList();
    }

    public override void StartFlightProcess(Client client)
    {
        ClientTransport c = (ClientTransport)client;
        State = new FlyingTransport(this, Airport.Position, c);
        Airport.RemoveClient(c);
        Airport = c.Destination;
    }
}