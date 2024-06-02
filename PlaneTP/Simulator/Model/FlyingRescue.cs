using System.Runtime.InteropServices.JavaScript;

namespace Simulator.Model;

public class FlyingRescue : FlyingSupport
{
    public FlyingRescue(Plane plane, Position start, ClientRescue client) : base(plane, start ,client) {}
    
    public override void NewPosition()
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
        }
    }
        
    public override void TimeStep()
    {
        NewPosition();
        if (_plane.Airport.Position.X == _position.X  && _plane.Airport.Position.Y == _position.Y)
        {
            _plane.State = new Maintenance(_plane);
        }
    }
}
