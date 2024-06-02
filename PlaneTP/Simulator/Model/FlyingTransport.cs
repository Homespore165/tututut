namespace Simulator.Model;

public class FlyingTransport : Flying
{
    protected ClientTransport _client;
    

    public FlyingTransport(Plane plane, ClientTransport client) : base(plane)
    {
        _client = client;
    }
    public void newPosition()
    {
        float t = 0.0001f * _plane.Speed % 1f;
        int x = (int)((1 - t) * _plane.Airport.Position.X + t * _client.Destination.Position.X);
        int y = (int)((1 - t) * _plane.Airport.Position.Y + t * _client.Destination.Position.Y);
        _plane.Position = new Position(x, y);
    }
    
    public override void TimeStep()
    {
        newPosition();
        if (_plane.Airport.Position.X == _client.Destination.Position.X && _plane.Airport.Position.Y == _client.Destination.Position.Y)
        {
            _plane.State = new Deboarding((PlaneTransport)_plane,  _client);
        }
    }
}