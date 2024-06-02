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

        float length = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);

        _position.X = (int)(_position.X + deltaX / length * speed);
        _position.Y = (int)(_position.Y + deltaY / length * speed);
    }
    /// <summary>
    /// Faire retourner l'avion
    /// </summary>
    protected void Back()
    {
        int speed = _plane.Speed;
        int deltaX = _startPos.X - _position.X;
        int deltaY = _startPos.Y - _position.Y;

        float length = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);

        _position.X = (int)(_position.X + deltaX / length * speed);
        _position.Y = (int)(_position.Y + deltaY / length * speed);
    }
}