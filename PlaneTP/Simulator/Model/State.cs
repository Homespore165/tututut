namespace Simulator.Model;

public abstract class State
{
    protected Plane _plane;
    /// <summary>
    /// constructeur
    /// </summary>
    /// <param name="plane">L'avion qui possède cet état</param>
    protected State (Plane plane)
    {
        _plane = plane;
    }
    /// <summary>
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public abstract void TimeStep();
}
