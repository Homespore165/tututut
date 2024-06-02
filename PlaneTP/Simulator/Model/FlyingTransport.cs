namespace Simulator.Model;

public class FlyingTransport : Flying
{
    protected ClientTransport _client;
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="start">Position de départ de l'avion (position de l'aéroport)</param>
    /// <param name="client">Client</param>
    public FlyingTransport(Plane plane, Position start, ClientTransport client) : base(plane, start, client)
    {
        _client = client;
    }
    /// <summary>
    /// Faire avancer l'avion
    /// </summary>
    protected void Toward()
    {
        int speed = _plane.Speed;
        int deltaX = _client.Position.X - _position.X;
        int deltaY = _client.Position.Y - _position.Y;

        float length = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);

        _position.X = (int)(_position.X + deltaX / length * speed);
        _position.Y = (int)(_position.Y + deltaY / length * speed);
    }
    /// <summary>
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public override void TimeStep()
    {
        Toward();
        if (isAtPos(_client.Destination.Position))
        {
            _plane.State = new Deboarding((PlaneTransport)_plane,  _client);
            _plane.Airport = _client.Destination;
            _client.Destination.Planes.Add(_plane);
        }
    }
}