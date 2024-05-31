
namespace Simulator.Model;

public class ClientSupportFactory
{
    private static ClientSupportFactory _instance;
    public static ClientSupportFactory Instance => _instance ??= new ClientSupportFactory(new Position(1000,500)); // Implementation de singleton. Pas thread-safe
    private Position _size;
    
    
    private ClientSupportFactory(Position size)
    {
        _size = size;
    }
    
    public ClientSupport CreateClientSupport(string type)
    {
        Random r = new Random();
        Position position = new Position(r.Next(_size.X), r.Next(_size.Y));
        return (type switch
        {
            "Fire" => new ClientFire(position, r.Next(5)),
            "Recon" => new ClientRecon(position),
            "Rescue" => new ClientRecon(position),
            _ => null
        })!;
    }
}
