namespace ScenarioGenerator.Model;

public class PlaneFactory
{
    private static PlaneFactory _instance;
    public static PlaneFactory Instance => _instance ??= new PlaneFactory(); // Implementation de singleton. Pas thread-safe.
    
    private PlaneFactory() {}
    /// <summary>
    /// Constructeur d'avion
    /// </summary>
    /// <param name="name">Nom de l'avion</param>
    /// <param name="speed">Vitesse</param>
    /// <param name="maintenanceTime">Temps de maintenance</param>
    /// <param name="boardingTime">Temps d'embarquement</param>
    /// <param name="unboardingTime">Temps de débarquement</param>
    public Plane CreatePlane(string name, string type, int speed, int maintenanceTime, int boardingTime = 0, int unboardingTime = 0)
    {
        return type switch
        {
            "Passenger" => new PlanePassenger(name, speed, maintenanceTime, boardingTime, unboardingTime),
            "Cargo" => new PlaneCargo(name, speed, maintenanceTime, boardingTime, unboardingTime),
            "Fire" => new PlaneFire(name, speed, maintenanceTime),
            "Recon" => new PlaneRecon(name, speed, maintenanceTime),
            "Rescue" => new PlaneRescue(name, speed, maintenanceTime),
            _ => throw new ArgumentException("Invalid plane type")
        };
    }
}