namespace Simulator.Model;

public abstract class Flying: State
{
    protected Position _position;
    protected Client _client;
    protected Flying(Plane plane, Position position) : base(plane)
    {
        _position = position;
    }

    public String ToString()
    {
        String planeType = _plane.GetType().Name.Remove(0,5);
        planeType = planeType switch
        {
            "Observation" => "O",
            "Rescue" => "R",
            "Passenger" => "P",
            "Cargo" => "C",
            "Fire" => "F",
        };
        int startX = _plane.Airport.Position.X;
        int startY = _plane.Airport.Position.Y;
        int endX = _client.Position.X;
        int endY = _client.Position.Y;
        int posX = _position.X;
        int posY = _position.Y;
        
        return $"{planeType};{startX};{startY};{endX};{endY};{posX},{posY}";
    }
}
