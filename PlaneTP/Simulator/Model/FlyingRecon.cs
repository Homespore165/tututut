namespace Simulator.Model;

public class FlyingRecon : FlyingSupport
{
    private int _circle = 0;
    private delegate void Step();
    private Step _handler;
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="start">Position de départ de l'avion (position de l'aéroport)</param>
    /// <param name="client">Client</param>
    public FlyingRecon(Plane plane, Position start, ClientRecon client) : base(plane, start, client)
    {
        _handler = Toward;
    }

    private void Toward()
    {
        base.Toward();
        
        if (_client.Position == _position)
        {
            _handler = Circle;
        }
    }
    
    private void Back()
    {
        base.Back();
        
        if (_source.Position == _position)
        {
            _plane.State = new Maintenance(_plane);
        }
    }

    private void Circle()
    {
        int speed = _plane.Speed;
        int deltaX = _client.Position.X - _position.X;
        int deltaY = _client.Position.Y - _position.Y;
        double angle = Math.Atan2(deltaY, deltaX);
        angle += Math.PI / 5;

        _position.X += (int)Math.Round(speed * Math.Cos(angle));
        _position.Y += (int)Math.Round(speed * Math.Sin(angle));

        _circle++;
        if (_circle == 10)
        {
            _circle = 0;
            _handler = Back;
        }
    }
    /// <summary>
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public override void TimeStep()
    {
        _handler();
    }
}
