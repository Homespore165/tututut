namespace ScenarioGenerator.Model;

public class PlaneFactory
{
    private static PlaneFactory _instance;
    public static PlaneFactory Instance => _instance ??= new PlaneFactory();
    
    private PlaneFactory()
    {
    }

    public Plane CreatePlane(string name, string type, int speed, int maintenanceTime, int boardingTime = 0, int unboardingTime = 0)
    {
        return type switch
        {
            "Passenger" => new PlanePassenger(name, 0, 0, speed, maintenanceTime, boardingTime, unboardingTime),
            "Cargo" => new PlaneCargo(name, 0, 0, speed, maintenanceTime, boardingTime, unboardingTime),
            "Fire" => new PlaneFire(name, 0, 0, speed, maintenanceTime),
            "Recon" => new PlaneRecon(name, 0, 0, speed, maintenanceTime),
            "Rescue" => new PlaneRescue(name, 0, 0, speed, maintenanceTime),
            _ => throw new ArgumentException("Invalid plane type")
        };
    }
}