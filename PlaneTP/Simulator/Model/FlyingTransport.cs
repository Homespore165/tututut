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
        int angle = (int)Math.Atan2(deltaY, deltaX);
        _position.X += (int)Math.Ceiling(speed * Math.Cos(angle));
        _position.Y += (int)Math.Ceiling(speed * Math.Sin(angle));
    }
    /// <summary>
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public override void TimeStep()
    {
        Toward();
        if (_position == _client.Destination.Position)
        {
            _plane.State = new Deboarding((PlaneTransport)_plane,  _client);
        }
    }
}