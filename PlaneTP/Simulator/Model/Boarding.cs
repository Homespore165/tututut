namespace Simulator.Model;

public class Boarding : State
{
    private int _timeToCompletion;
    private ClientTransport _client;
    private Position _start;
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="client">Client</param>
    public Boarding(PlaneTransport plane, Position start, ClientTransport client) : base(plane)
    {
        _timeToCompletion = plane.BoardingTime;
        _client = client;
        _start = start;
    }
    /// <summary>
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public override void TimeStep()
    {
        _timeToCompletion--;
        if (_timeToCompletion == 0)
        {
            PlaneTransport p = (PlaneTransport)_plane;
            if (_client.Size > p.Capacity)
            {
                Console.WriteLine("Size: " + _client.Size);
                Console.WriteLine("Capacity: " + p.Capacity);
                ClientTransport c = _client.Split(p.Capacity);
                //_plane.Airport?.AddClient(_client);
                _plane.State = new FlyingTransport(_plane, _start, c);
            } else {
                _plane.State = new FlyingTransport(_plane, _start, _client);
                _plane.Airport.RemoveClient(_client);
                _client.Destination.Planes.Add(_plane);
            }
        }
    }
}
