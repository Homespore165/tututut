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

    /// <summary>
    /// Faire avancer l'avion
    /// </summary>
    private void Toward()
    {
        base.Toward();
        
        if (isAtPos(_client.Position))
        {
            _handler = Circle;
        }
    }

    /// <summary>
    /// Faire revenir l'avion
    /// </summary>
    private void Back()
    {
        base.Back();
        
        if (isAtPos(_source.Position))
        {
            _plane.State = new Maintenance(_plane);
        }
    }

    /// <summary>
    /// Effectuer le cercle de reconnaissance
    /// </summary>
    private void Circle()
    {
        int timeToCircle = 30;

        int deltaX = _client.Position.X - _startPos.X;
        int deltaY = _client.Position.Y - _startPos.Y;

        double angle = Math.Atan2(deltaY, deltaX) - Math.PI;
        angle += _circle * (2 * Math.PI / timeToCircle);

        _position.X = _client.Position.X + (int)Math.Round(15 * Math.Cos(angle));
        _position.Y = _client.Position.Y + (int)Math.Round(15 * Math.Sin(angle));

        _circle++;
        if (_circle >= timeToCircle)
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
