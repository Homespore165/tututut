namespace Simulator.Model;

public abstract class FlyingSupport: Flying
{
    protected Airport _source;

    protected FlyingSupport(Plane plane, Position start, ClientSupport client) : base(plane, start)
    {
        _source = plane.Airport; 
        _client = client;
    }

    protected void Toward()
    {
        int speed = _plane.Speed;
        int deltaX = _client.Position.X - _position.X;
        int deltaY = _client.Position.Y - _position.Y;

        float length = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);

        _position.X += (int)(deltaX / length * speed);
        _position.Y += (int)(deltaY / length * speed);
    }
    
    protected void Back()
    {
        int speed = _plane.Speed;
        int deltaX = _client.Position.X - _position.X;
        int deltaY = _client.Position.Y - _position.Y;

        float length = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);

        _position.X += (int)(deltaX / length * -speed);
        _position.Y += (int)(deltaY / length * -speed);
    }
}