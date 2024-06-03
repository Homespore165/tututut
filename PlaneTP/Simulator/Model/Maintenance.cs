namespace Simulator.Model;

public class Maintenance : State
{
    private int _timeToCompletion;

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    public Maintenance(Plane plane) : base(plane)
    {
        _timeToCompletion = plane.MaintenanceTime;
    }

    /// <summary>
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public override void TimeStep()
    {
        _timeToCompletion--;
        if (_timeToCompletion == 0)
        {
            _plane.State = new Waiting(_plane);
        }
    }
}
