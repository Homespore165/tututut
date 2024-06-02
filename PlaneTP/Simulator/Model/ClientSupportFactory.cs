
namespace Simulator.Model;

public class ClientSupportFactory
{
    private static ClientSupportFactory? _instance;
    public static ClientSupportFactory Instance => _instance ??= new ClientSupportFactory(); // Implementation de singleton. Pas thread-safe
    private readonly Position _size = new (1000, 500);
    private readonly Random _random = new ();
    
    private ClientSupportFactory()
    {
    }
    
    public ClientSupport CreateClientSupport(string type)
    {
        Position position = new Position(_random.Next(_size.X + 1), _random.Next(_size.Y + 1));
        return (type switch
        {
            "Fire" => new ClientFire(position),
            "Recon" => new ClientRecon(position),
            "Rescue" => new ClientRescue(position),
            _ => null
        })!;
    }
}
