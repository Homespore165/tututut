using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public class Scenario
{
    public delegate void Flight(List<String> flights);
    private event Flight FlightUpdate;
    public delegate void AirportDelegate(List<String> airports);
    private event AirportDelegate AirportUpdate;
    public delegate void PlaneDelegate(List<String> planes);
    private event PlaneDelegate PlaneUpdate;
    private static Scenario _instance;
    public static Scenario Instance => _instance ??= new Scenario();
    private List<Plane> _planes;
    public List<Plane> Planes
    {
        get
        {
            List<Plane> planes = new List<Plane>();
            foreach (Airport airport in _airports)
            {
                planes.AddRange(airport.Planes);
            }
            return planes.Where(p => p.State is Flying).ToList();
        }
    }
    
    private List<Airport> _airports;
    public List<Airport> Airports
    {
        get => _airports;
        set => _airports = value;
    }
    
    private List<ClientSupport> _clientsSupport;
    public List<ClientSupport> ClientsSupport
    {
        get => _clientsSupport;
        set => _clientsSupport = value;
    }
    public List<ClientFire> ClientsFire => _clientsSupport.OfType<ClientFire>().ToList();
    public List<ClientRecon> ClientsRecon => _clientsSupport.OfType<ClientRecon>().ToList();
    public List<ClientRescue> ClientsRescue => _clientsSupport.OfType<ClientRescue>().ToList();


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
        _instance = this;
        _airports = new List<Airport>();
        _planes = new List<Plane>();
        _clientsSupport = new List<ClientSupport>();
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
        _planes = new List<Plane>();
        _airports = new List<Airport>();
        _clientsSupport = new List<ClientSupport>();
        _frequencyFire = frequencyFire;
        _frequencyRecon = frequencyRecon;
        _frequencyRescue = frequencyRescue;
    }
	
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
                airport.Scenario = this;
                _airports.Add(airport);
            }
        }
        reader.Close();
    }
    /// <summary>
    /// Remplir le simulateur à l'aide du scénario déja enregistré
    /// </summary>
    public void Load()
    {
        XmlReader reader = XmlReader.Create("../../../Scenario.xml");
        ReadXml(reader);
    }
    /// <summary>
    /// Génère un incident de type incendie
    /// </summary>
    private void GenerateFire()
    {
        Random r = new Random();
        if (r.Next(0, 100) < _frequencyFire)
        {
            ClientSupportFactory factory = ClientSupportFactory.Instance;
            _clientsSupport.Add(factory.CreateClientSupport("Fire"));
        }
    }
    /// <summary>
    /// Génère un incident de type reconnaissance
    /// </summary>
    private void GenerateRecon()
    {
        Random r = new Random();
        if (r.Next(0, 100) < _frequencyRecon)
        {
            ClientSupportFactory factory = ClientSupportFactory.Instance;
            _clientsSupport.Add(factory.CreateClientSupport("Recon"));
        }
    }
    /// <summary>
    /// Génère un incident de type sauvetage
    /// </summary>
    private void GenerateRescue()
    {
        Random r = new Random();
        if (r.Next(0, 100) < _frequencyRescue)
        {
            ClientSupportFactory factory = ClientSupportFactory.Instance;
            _clientsSupport.Add(factory.CreateClientSupport("Rescue"));
        }
    }
    /// <summary>
    /// Génère un incident
    /// </summary>
    private void GenerateClients()
    {
        GenerateFire();
        GenerateRecon();
        GenerateRescue();
    }
    /// <summary>
    /// Gestion d'avancer d'un seul pas
    /// </summary>
    public void TimeStep()
    {
        GenerateClients();
        Planes?.ForEach(p => p.TimeStep());
        Airports.ForEach(a => a.TimeStep());
        
    }
    /// <summary>
    /// Envoie des informations à la vue
    /// </summary>
    public void updateView()
    {
        FlightUpdate?.Invoke(Planes.Select(p => p.State.ToString()).ToList());
        AirportUpdate?.Invoke(Airports.Select(a => a.ToString()).ToList());
        PlaneUpdate?.Invoke(GetAirportPlanes());
    }
    /// <summary>
    /// S'abonner à l'événement modification d'un vol
    /// </summary>
    /// <param name="eventHandler">événement</param>
    public void SubscribeFlights(Flight eventHandler)
    {
        FlightUpdate += eventHandler;
    }
    /// <summary>
    /// S'abonner à l'événement modification d'un aéroport
    /// </summary>
    /// <param name="eventHandler">événement</param>
    public void SubscribeAirports(AirportDelegate eventHandler)
    {
        AirportUpdate += eventHandler;
    }
    /// <summary>
    /// Génère des destinations alétoires aux clients de transport
    /// </summary>
    /// <param name="airport"></param>
    /// <returns></returns>
    public Airport GetRandomAirportExcluding(Airport airport)
    {
        Random r = new Random();
        Airport a = airport;
        while (a == airport)
        {
            a = _airports[r.Next(0, _airports.Count)];
        }
        return a;
    }
    /// <summary>
    /// Détruit un incident réglé
    /// </summary>
    /// <param name="client">client</param>
    public void RemoveClient(ClientSupport client)
    {
        _clientsSupport.Remove(client);
    }
    /// <summary>
    /// Retourne les avions par aéroport
    /// </summary>
    /// <returns>Les avions des aéroports</returns>
    public List<string> GetAirportPlanes()
    {
        List<string> info = new List<string>();
        foreach (var airport in _airports)
        {
            string name = airport.Name;
            string output = name + ";";
            foreach (var plane in airport.Planes)
            {
                output += plane.Name + " - " + plane.GetType().Name.Remove(0,5) + " - " + plane.State + ";";
            }
            output.Remove(output.Length - 1);
            info.Add(output);
        }
        return info;
    }
    /// <summary>
    ///  S'abonner à l'événement modification d'un avion
    /// </summary>
    /// <param name="updatePlaneList">événement</param>
    public void SubscribeAirportsPlane(PlaneDelegate updatePlaneList)
    {
        PlaneUpdate += updatePlaneList;
    }
}