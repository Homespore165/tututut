namespace Simulator.Model;

public class FlyingFire : FlyingSupport
{
    protected ClientFire _client;
    public FlyingFire(Plane plane, ClientFire client) : base(plane, client)
    {
        _client = client;
    }
    public override void NewPosition()
    {
        if (_client.Intensity > 0)
        {
            bool returning = (_plane.Position.X == _client.Position.X && _plane.Position.Y == _client.Position.Y) ? true : false;
            if (!returning)
            {
                float t = 0.0001f * _plane.Speed % 1f;
                int x = (int)((1 - t) * _plane.Position.X + t *  _client.Position.X);
                int y = (int)((1 - t) * _plane.Position.Y + t *  _client.Position.Y);
                _plane.Position = new Position(x, y);
            }
            else
            {
                float t = 0.0001f * _plane.Speed % 1f;
                int x = (int)((1 - t) * _client.Position.X + t *  _plane.Position.X);
                int y = (int)((1 - t) * _client.Position.Y + t *  _plane.Position.Y);
                _plane.Position = new Position(x, y);
                if (_plane.Airport.Position.X == _plane.Position.X  && _plane.Airport.Position.Y == _plane.Position.Y)
                {
                    _client.Intensity--;
                }
            }
        }
    }
        
    public override void TimeStep()
    {
        NewPosition();
        if (_plane.Airport.Position.X == _plane.Position.X  && _plane.Airport.Position.Y == _plane.Position.Y && _client.Intensity == 0)
        {
            _plane.State = new Maintenance(_plane);
        }
    }
}
