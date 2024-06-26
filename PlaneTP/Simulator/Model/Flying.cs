﻿using System.DirectoryServices;

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
    /// <param name="position">Position de départ de l'avion (position de l'aéroport)</param>
    protected Flying(Plane plane, Position position) : base(plane)
    {
        _position = (Position)position.Clone();
        _startPos = (Position)position.Clone();
    }

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="plane">Avion possèdant cet état</param>
    /// <param name="position">Position de départ de l'avion (position de l'aéroport)</param>
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
            "Recon" => "O",
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

        string str = $"{planeType};{startX};{startY};{endX};{endY};{posX};{posY}";

        return str;
    }

    /// <summary>
    /// L'avion est-il arrivé à destination
    /// </summary>
    /// <returns>Oui/Non</returns>
    public bool isAtDestination()
    {
        int deltaX = _client.Position.X - _position.X;
        int deltaY = _client.Position.Y - _position.Y;
        float dist = MathF.Sqrt(MathF.Pow(deltaX, 2) + MathF.Pow(deltaY, 2));

        return dist < 5;
    }

    /// <summary>
    /// L'avion est-il à sa position de départ
    /// </summary>
    /// <returns>Oui/Non</returns>
    public bool isAtStart()
    {
        int deltaX = _startPos.X - _position.X;
        int deltaY = _startPos.Y - _position.Y;
        float dist = MathF.Sqrt(MathF.Pow(deltaX, 2) + MathF.Pow(deltaY, 2));

        return dist < 5;
    }

    /// <summary>
    /// L'avion est-il à la position demandée
    /// </summary>
    /// <param name="pos">La position à savoir</param>
    /// <param name="errorRange">La rangée d'erreur</param>
    /// <returns>Un booléen</returns>
    public bool isAtPos(Position pos, float errorRange = 5)
    {
        int deltaX = pos.X - _position.X;
        int deltaY = pos.Y - _position.Y;
        float dist = MathF.Sqrt(MathF.Pow(deltaX, 2) + MathF.Pow(deltaY, 2));

        return dist < errorRange;
    }
}
