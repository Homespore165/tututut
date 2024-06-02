namespace Simulator.Model;

public abstract class FlyingSupport: Flying
{
    protected Airport _source;
    protected ClientSupport _client;

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
        int angle = (int)Math.Atan2(deltaY, deltaX);
        _position.X += (int)Math.Ceiling(speed * Math.Cos(angle));
        _position.Y += (int)Math.Ceiling(speed * Math.Sin(angle));
    }
    
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