namespace Simulator.Model;

public class FlyingTransport : Flying
{
    protected ClientTransport _client;

    public FlyingTransport(Plane plane, Position start, ClientTransport client) : base(plane, start, client)
    {
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
    
    public override void TimeStep()
    {
        Toward();
        if (_position == _client.Destination.Position)
        {
            _plane.State = new Deboarding((PlaneTransport)_plane,  _client);
        }
    }
}