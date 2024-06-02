namespace Simulator.Model;

public class Waiting : State
{
    public Waiting(Plane plane) : base(plane) {}
    
    public override void TimeStep()
    {
        List<Client> clients = _plane.GetPossibleClients();
        Console.WriteLine(clients);
        if (clients.Count > 0)
        {
            Client client = clients[0];
            _plane.StartFlightProcess(client);
        }
    }
}