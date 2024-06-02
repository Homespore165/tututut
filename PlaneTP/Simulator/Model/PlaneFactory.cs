namespace Simulator.Model;

public class PlaneFactory
{
    private static PlaneFactory? _instance;
    public static PlaneFactory Instance => _instance ??= new PlaneFactory();
    
    private PlaneFactory()
    {
    }
    /// <summary>
    /// Constructeur d'avions
    /// </summary>
    /// <param name="name">Nom de l'avion</param>
    /// <param name="type">Type de l'avion</param>
    /// <param name="speed">Vitesse de l'avion</param>
    /// <param name="maintenanceTime">Temps de maintenance de l'avion</param>
    /// <param name="airport">Aéroport au moment de création</param>
    /// <param name="x">Position de l'avion en X</param>
    /// <param name="y">Position de l'avion en y</param>
    /// <param name="boardingTime">Temps d'embarquement de l'avion</param>
    /// <param name="unboardingTime">temps de débarquement</param>
    /// <returns>un avion</returns>
    /// <exception cref="ArgumentException"></exception>
    public Plane CreatePlane(string name, string type, int speed, int maintenanceTime, Airport airport, int boardingTime = 0, int unboardingTime = 0)
    {
        return type switch
        {
            "Passenger" => new PlanePassenger(name, 0, 0, speed, maintenanceTime, airport, boardingTime, unboardingTime),
            "Cargo" => new PlaneCargo(name, 0, 0, speed, maintenanceTime, airport, boardingTime, unboardingTime),
            "Fire" => new PlaneFire(name, 0, 0, speed, maintenanceTime, airport),
            "Recon" => new PlaneRecon(name, 0, 0, speed, maintenanceTime, airport),
            "Rescue" => new PlaneRescue(name, 0, 0, speed, maintenanceTime, airport),
            _ => throw new ArgumentException("Invalid plane type")
        };
    }
}