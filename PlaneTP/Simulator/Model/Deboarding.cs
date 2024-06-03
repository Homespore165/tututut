namespace Simulator.Model;

public class Deboarding : State
{
    private int _timeToCompletion;
    private ClientTransport _client;

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="client">Client</param>
    public Deboarding(PlaneTransport plane, ClientTransport client) : base(plane)
    {
        _timeToCompletion = plane.UnboardTime;
        _client = client;
    }

    /// <summary>
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public override void TimeStep()
    {
        _timeToCompletion--;
        if (_timeToCompletion <= 0)
        {
            _plane.State = new Waiting(_plane);
        }
    }
}
