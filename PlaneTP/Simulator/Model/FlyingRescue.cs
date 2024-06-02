using System.Runtime.InteropServices.JavaScript;

namespace Simulator.Model;

public class FlyingRescue : FlyingSupport
{
    private delegate void Step();
    private Step _handler;

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="start">Position de départ de l'avion (position de l'aéroport)</param>
    /// <param name="client">Client</param>
    public FlyingRescue(Plane plane, Position start, ClientRescue client) : base(plane, start, client)
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
        
        if (isAtPos(_client.Position))
        {
            _handler = Back;
        }
    }

    /// <summary>
    /// Faire retourner l'avion
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
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public override void TimeStep()
    {
        _handler();
    }
}
