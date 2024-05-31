﻿using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ScenarioGenerator.Model;

public delegate void OnAirportUpdate(string[] planes);
public class Scenario : IXmlSerializable
{
	private event OnAirportUpdate OnAirportUpdate;
    private List<Airport> _airports;
    public List<Airport> Airports
    {
        get => _airports;
        set => _airports = value;
    }

    private int _frequencyFire;
    public int FrequencyFire
    {
        get => _frequencyFire;
        set => _frequencyFire = value;
    }
	
    private int _frequencyRecon;
    public int FrequencyRecon
    {
        get => _frequencyRecon;
        set => _frequencyRecon = value;
    }
	
    private int _frequencyRescue;
    public int FrequencyRescue
    {
        get => _frequencyRescue;
        set => _frequencyRescue = value;
    }
	
    public Scenario()
    {
        _airports = new List<Airport>();
        _frequencyFire = 0;
        _frequencyRecon = 0;
        _frequencyRescue = 0;
    }
	
    public Scenario(int frequencyFire, int frequencyRecon, int frequencyRescue)
    {
        _airports = new List<Airport>();
        _frequencyFire = frequencyFire;
        _frequencyRecon = frequencyRecon;
        _frequencyRescue = frequencyRescue;
    }
	
    public void AddAirport(Airport airport)
    {
        _airports.Add(airport);
    }
	
    public void AddAirport(string name, int x, int y, int passengerTraffic, int cargoTraffic)
    {
        Airport airport = new Airport(name, x, y, passengerTraffic, cargoTraffic);
        _airports.Add(airport);
        NotifyAirportChanged();
    }
	
    public void EditAirport(int id, string name, int x, int y, int passengerTraffic, int cargoTraffic)
    {
        List<Plane> p = _airports[id].Planes;
        _airports[id] =	new Airport(name, x, y, passengerTraffic, cargoTraffic);
        _airports[id].Planes = p;
        NotifyAirportChanged();
    }
	
    public void DeleteAirport(int id)
    {
        _airports[id].ClearPlanes();
        _airports.Remove(_airports[id]);
        NotifyAirportChanged();
    }
	
    public void AddPlane(int airportId, string name, string type, int speed, int maintenanceTime, int boardingTime = 0, int unboardingTime = 0)
    {
        _airports[airportId].AddPlane(name, type, speed, maintenanceTime, boardingTime, unboardingTime);
    }
	
    public XmlSchema? GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement();

        _frequencyFire = int.Parse(reader.ReadElementString("FrequencyFire"));
        _frequencyRecon = int.Parse(reader.ReadElementString("FrequencyRecon"));
        _frequencyRescue = int.Parse(reader.ReadElementString("FrequencyRescue"));
        
        XmlSerializer serializer = new XmlSerializer(typeof(Airport));
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Airport")
            {
                Airport airport = (Airport)serializer.Deserialize(reader.ReadSubtree());
                _airports.Add(airport);
            }
        }
        reader.Close();
        NotifyAirportChanged();
        
    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteStartElement("Scenario");
		
        writer.WriteElementString("FrequencyFire", FrequencyFire.ToString());
        writer.WriteElementString("FrequencyRecon", FrequencyRecon.ToString());
        writer.WriteElementString("FrequencyRescue", FrequencyRescue.ToString());
		
        writer.WriteStartElement("Airports");
		
        XmlSerializer serializer = new XmlSerializer(typeof(Airport));
        foreach (Airport airport in _airports)
            serializer.Serialize(writer, airport);
		
        writer.Close();
    }

    public void Save()
    {
        WriteXml(XmlWriter.Create("../../../scenario.xml"));
    }

    public void Load()
    {
        XmlReader reader = XmlReader.Create("../../../scenario.xml");
        ReadXml(reader);
    }
    /// <summary>
    /// Gestion de l'événement modification d'un aéroport 
    /// </summary>
    /// <param name="updateAirports">événement</param>
	private void NotifyAirportChanged()
    {
        OnAirportUpdate?.Invoke(_airports.Select(a => a.ToString()).ToArray());
    }
    /// <summary>
    /// S'abonner à l'événement modification d'un aéroport
    /// </summary>
    /// <param name="updateAirports">événement</param>
    public void SubscribeAirportUpdate(Action<string[]> updateAirports)
    {
        OnAirportUpdate += new OnAirportUpdate(updateAirports);
    }
    
    /// <summary>
    ///  S'abonner à l'événement modification d'un avion
    /// </summary>
    /// <param name="updatePlanes">événement</param>
    public void SubscribePlaneUpdate(Action<string[]> updatePlanes)
    {
        _airports.ForEach(a => a.UnsubcribeAll());
        _airports.ForEach(a => a.SubscribePlaneChanged(updatePlanes));
    }
    /// <summary>
    /// Retourne les avions d'un aéroport sélectionné
    /// </summary>
    /// <param name="airportId">L'aéroport sélectionné</param>
    /// <returns>Les avions de cet aéroport</returns>
    public string[] GetPlanes(int airportId)
    {
        return _airports[airportId].GetPlanes();
    }
    /// <summary>
    /// Retourne la valeur de la fréquance d'événement d'incendie après le chargement d'un scénario
    /// </summary>
    /// <returns></returns>
    public int GetFire()
    {
        return _frequencyFire;
    }
    /// <summary>
    /// Retourne la valeur de la fréquance d'événement de sauvetage après le chargement d'un scénario
    /// </summary>
    /// <returns>la valeur de la fréquance d'événement</returns>
    public int GetRescue()
    {
        return _frequencyRescue;
    }
    /// <summary>
    /// Retourne la valeur de la fréquance d'événement de reconnaissance après le chargement d'un scénario
    /// </summary>
    /// <returns>la valeur de la fréquance d'événement</returns>
    public int GetRecon()
    {
        return _frequencyRecon;
    }
}