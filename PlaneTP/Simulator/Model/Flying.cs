namespace Simulator.Model;

public abstract class Flying: State
{
    protected Position _position;
    protected Client _client;
    protected Position _startPos;
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="start">Position de départ de l'avion (position de l'aéroport)</param>
    protected Flying(Plane plane, Position position) : base(plane)
    {
        _position = (Position)position.Clone();
        _startPos = (Position)position.Clone();
    }
    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="start">Position de départ de l'avion (position de l'aéroport)</param>
    /// <param name="client">Client</param>
    protected Flying(Plane plane, Position position, Client client) : base(plane)
    {
        _position = (Position)position.Clone();
        _client = client;
        _startPos = (Position)position.Clone();
    }
    /// <summary>
    /// Sérilialiser en String l'état
    /// </summary>
    /// <returns></returns>
    public override String ToString()
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
        int startX = _startPos.X;
        int startY = _startPos.Y;
        int endX = _client.Position.X;
        int endY = _client.Position.Y;
        int posX = _position.X;
        int posY = _position.Y;
        
        return $"{planeType};{startX};{startY};{endX};{endY};{posX};{posY}";
    }
}
