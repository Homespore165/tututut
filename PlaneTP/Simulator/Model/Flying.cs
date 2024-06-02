﻿namespace Simulator.Model;

public abstract class Flying: State
{
    protected Position _position;
    protected Client _client;
    protected Position _startPos;
    protected Flying(Plane plane, Position position) : base(plane)
    {
        _position = position;
        _startPos = position;
    }

    protected Flying(Plane plane, Position position, Client client) : base(plane)
    {
        _position = position;
        _client = client;
        _startPos = position;
    }

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
