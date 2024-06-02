namespace Simulator.Model;

public class FlyingFire : FlyingSupport
{
    protected ClientFire _client;
    public FlyingFire(Plane plane, Position start, ClientFire client) : base(plane, start, client)
    {
        _client = client;
    }
    public override void NewPosition()
    {
        if (_client.Intensity > 0)
        {
            bool returning = (_position.X == _client.Position.X && _position.Y == _client.Position.Y) ? true : false;
            if (!returning)
            {
                float t = 0.0001f * _plane.Speed % 1f;
                int x = (int)((1 - t) * _position.X + t *  _client.Position.X);
                int y = (int)((1 - t) * _position.Y + t *  _client.Position.Y);
                _position = new Position(x, y);
            }
            else
            {
                float t = 0.0001f * _plane.Speed % 1f;
                int x = (int)((1 - t) * _client.Position.X + t *  _position.X);
                int y = (int)((1 - t) * _client.Position.Y + t *  _position.Y);
                _position = new Position(x, y);
                if (_plane.Airport.Position.X == _position.X  && _plane.Airport.Position.Y == _position.Y)
                {
                    _client.Intensity--;
                }
            }
        }
    }
        
    public override void TimeStep()
    {
        NewPosition();
        if (_plane.Airport.Position.X == _position.X  && _plane.Airport.Position.Y == _position.Y && _client.Intensity == 0)
        {
            _plane.State = new Maintenance(_plane);
        }
    }
}
