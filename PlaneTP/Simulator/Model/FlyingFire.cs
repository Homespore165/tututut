namespace Simulator.Model;

public class FlyingFire : FlyingSupport
{
    ClientFire _client;
    private delegate void Step();
    private Step _handler;
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="start">Position de départ de l'avion (position de l'aéroport)</param>
    /// <param name="client">Client</param>
    public FlyingFire(Plane plane, Position start, ClientFire client) : base(plane, start, client)
    {
        _client = client;
        _handler = Toward;
    }
    /// <summary>
    /// Faire avancer l'avion
    /// </summary>
    private void Toward()
    {
        base.Toward();
        
        if (_client.Position == _position)
        {
            _client.Intensity--;
            _handler = Back;
        }
    }
    /// <summary>
    /// Faire retourner l'avion
    /// </summary>
    private void Back()
    {
        base.Back();
    
        if (_source.Position == _position)
        {
            _handler = _client.Intensity > 0 ? Toward : () => _plane.State = new Maintenance(_plane);
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
