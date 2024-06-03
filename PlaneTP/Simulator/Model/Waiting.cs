namespace Simulator.Model;

public class Waiting : State
{
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    public Waiting(Plane plane) : base(plane) {}

    /// <summary>
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public override void TimeStep()
    {
        List<Client> clients = _plane.GetPossibleClients();
        if (clients.Count > 0)
        {
            Client client = clients[0];
            _plane.StartFlightProcess(client);
        }
    }
}