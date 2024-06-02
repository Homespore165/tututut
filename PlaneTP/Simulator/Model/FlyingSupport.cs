namespace Simulator.Model;

public abstract class FlyingSupport: Flying
{
    protected Airport _source;
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="start">Position de départ de l'avion (position de l'aéroport)</param>
    /// <param name="client">Client</param>
    protected FlyingSupport(Plane plane, Position start, ClientSupport client) : base(plane, start)
    {
        _source = plane.Airport; 
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
    /// Faire retourner l'avion
    /// </summary>
    protected void Back()
    {
        int speed = _plane.Speed;
        int deltaX = _source.Position.X - _position.X;
        int deltaY = _source.Position.Y - _position.Y;
        int angle = (int)Math.Atan2(deltaY, deltaX);
        _position.X += (int)Math.Ceiling(speed * Math.Cos(angle));
        _position.Y += (int)Math.Ceiling(speed * Math.Sin(angle));
    }
}