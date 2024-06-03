namespace Simulator.Model;

public class PlaneCargo : PlaneTransport
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
    /// <param name="boardingTime">Temps d'embarquement de l'avion</param>
    /// <param name="unboardTime">temps de débarquement</param>
    public PlaneCargo(string name, int x, int y, int speed, int maintenanceTime, Airport airport ,int boardingTime, int unboardTime)
        : base(name, x, y, speed, maintenanceTime, airport, boardingTime, unboardTime)
    {
    }
	
    private PlaneCargo() {}

    /// <summary>
    /// Retourne la liste des clients potentiel pour l'avion
    /// </summary>
    /// <returns>la liste des clients</returns>
    public override List<Client> GetPossibleClients()
    {
        return Airport.ClientsCargo.Cast<Client>().ToList();
    }

    /// <summary>
    /// Commence le processus de vol 
    /// </summary>
    /// <param name="client">le client</param>
    public override void StartFlightProcess(Client client)
    {
        ClientTransport c = (ClientTransport)client;
        State = new Boarding(this, Airport.Position, c);
        Airport.RemoveClient((ClientTransport)client);
        Airport = c.Destination;
        c.Destination.Planes.Add(this);
    }
}