using System.Xml;
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
	/// <summary>
	/// Constructeur
	/// </summary>
    public Scenario()
    {
        _airports = new List<Airport>();
        _frequencyFire = 0;
        _frequencyRecon = 0;
        _frequencyRescue = 0;
    }
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="frequencyFire">Indicateur de la fréquance d'événement</param>
	/// <param name="frequencyRecon">Indicateur de la fréquance d'événement</param>
	/// <param name="frequencyRescue">Indicateur de la fréquance d'événement</param>
    public Scenario(int frequencyFire, int frequencyRecon, int frequencyRescue)
    {
        _airports = new List<Airport>();
        _frequencyFire = frequencyFire;
        _frequencyRecon = frequencyRecon;
        _frequencyRescue = frequencyRescue;
    }
	/// <summary>
	/// Ajouter un aéroport déja créer
	/// </summary>
	/// <param name="airport">un aéroport</param>
    public void AddAirport(Airport airport)
    {
        _airports.Add(airport);
    }
    /// <summary>
    /// Ajouter un aéroport
    /// </summary>
    /// <param name="name">Nom</param>
    /// <param name="x">position en X</param>
    /// <param name="y">position en Y</param>
    /// <param name="passengerTraffic">Indicateur de traffic humain</param>
    /// <param name="cargoTraffic">Indicateur de traffic postal</param>
    public void AddAirport(string name, int x, int y, int passengerTraffic, int cargoTraffic)
    {
        Airport airport = new Airport(name, x, y, passengerTraffic, cargoTraffic);
        _airports.Add(airport);
        NotifyAirportChanged();
    }
	/// <summary>
	/// Modifier un aéroport
	/// </summary>
	/// <param name="id">Id de l'aéroport</param>
	/// <param name="name">Nom</param>
	/// <param name="x">position en X</param>
	/// <param name="y">position en Y</param>
	/// <param name="passengerTraffic">Indicateur de traffic humain</param>
	/// <param name="cargoTraffic">Indicateur de traffic postal</param>
    public void EditAirport(int id, string name, int x, int y, int passengerTraffic, int cargoTraffic)
    {
        List<Plane> p = _airports[id].Planes;
        _airports[id] =	new Airport(name, x, y, passengerTraffic, cargoTraffic);
        _airports[id].Planes = p;
        NotifyAirportChanged();
    }
	/// <summary>
	/// Supprimer un aéroport
	/// </summary>
	/// <param name="id">Id de l'aéroport</param>
    public void DeleteAirport(int id)
    {
        _airports[id].ClearPlanes();
        _airports.Remove(_airports[id]);
        NotifyAirportChanged();
    }
	/// <summary>
	/// Ajouter un avion dans un aéroport
	/// </summary>
	/// <param name="airportId">Id de l'aéroport</param>
	/// <param name="name">nom de l'avion</param>
	/// <param name="type">type de l'avion</param>
	/// <param name="speed">vitesse de l'avion</param>
	/// <param name="maintenanceTime">temps de maintenance de l'avion</param>
	/// <param name="boardingTime">temps d'embarquement de l'avion</param>
	/// <param name="unboardingTime">temps de débarquement de l'avion</param>
    public void AddPlane(int airportId, string name, string type, int speed, int maintenanceTime, int boardingTime = 0, int unboardingTime = 0)
    {
        _airports[airportId].AddPlane(name, type, speed, maintenanceTime, boardingTime, unboardingTime);
    }
	/// <summary>
	/// </summary>
	/// <returns></returns>
    public XmlSchema? GetSchema()
    {
        return null;
    }
    /// <summary>
    /// Lire le XML du scénario enregistré
    /// </summary>
    /// <param name="writer">le fichier à lire</param>
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
    /// <summary>
    /// Enregistrer le scénario actuel en XML
    /// </summary>
    /// <param name="writer">Le fichier à enregistrer </param>
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
    /// <summary>
    /// Enregistrer le scénario actuel
    /// </summary>
    public void Save()
    {
        WriteXml(XmlWriter.Create("../../../scenario.xml"));
    }
    /// <summary>
    /// Remplir le générateur à l'aide du scénario déja enregistré
    /// </summary>
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