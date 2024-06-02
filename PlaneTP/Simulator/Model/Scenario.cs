using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public class Scenario : IXmlSerializable
{
    public delegate void Flight(List<String> flights);
    private event Flight FlightUpdate;
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
            return planes.Where(p => p.State is not Flying).ToList();
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
    
    public Scenario()
    {
        _airports = new List<Airport>();
        _planes = new List<Plane>();
        _clientsSupport = new List<ClientSupport>();
        _frequencyFire = 0;
        _frequencyRecon = 0;
        _frequencyRescue = 0;
    }
	
    public Scenario(int frequencyFire, int frequencyRecon, int frequencyRescue)
    {
        _planes = new List<Plane>();
        _airports = new List<Airport>();
        _clientsSupport = new List<ClientSupport>();
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
    }
	
    public void EditAirport(int id, string name, int x, int y, int passengerTraffic, int cargoTraffic)
    {
        _airports[id] =	new Airport(name, x, y, passengerTraffic, cargoTraffic);
    }
	
    public void DeleteAirport(int id)
    {
        _airports.Remove(_airports[id]);
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
                airport.Scenario = this;
                _airports.Add(airport);
            }
        }
        reader.Close();
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

    public void Load()
    {
        XmlReader reader = XmlReader.Create("../../../Scenario.xml");
        ReadXml(reader);
    }

    public string[] GetPlanes(int airportId)
    {
        return _airports[airportId].GetPlanes();
    }

    private void GenerateFire()
    {
        Random r = new Random();
        if (r.Next(0, 100) < _frequencyFire)
        {
            ClientSupportFactory factory = ClientSupportFactory.Instance;
            _clientsSupport.Add(factory.CreateClientSupport("Fire"));
        }
    }
    
    private void GenerateRecon()
    {
        Random r = new Random();
        if (r.Next(0, 100) < _frequencyRecon)
        {
            ClientSupportFactory factory = ClientSupportFactory.Instance;
            _clientsSupport.Add(factory.CreateClientSupport("Recon"));
        }
    }
    
    private void GenerateRescue()
    {
        Random r = new Random();
        if (r.Next(0, 100) < _frequencyRescue)
        {
            ClientSupportFactory factory = ClientSupportFactory.Instance;
            _clientsSupport.Add(factory.CreateClientSupport("Rescue"));
        }
    }

    private void GenerateClients()
    {
        GenerateFire();
        GenerateRecon();
        GenerateRescue();
    }

    public void TimeStep()
    {
        GenerateClients();
        Planes?.ForEach(p => p.TimeStep());
        Airports.ForEach(a => a.TimeStep());
        FlightUpdate?.Invoke(Planes.Select(p => p.State.ToString()).ToList());
    }
    
    public void SubscribeFlights(Flight eventHandler)
    {
        FlightUpdate += eventHandler;
    }

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
}