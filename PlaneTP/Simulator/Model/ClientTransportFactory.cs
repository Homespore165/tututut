using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model;
public class ClientTransportFactory
{
    private static ClientTransportFactory? _instance;
    public static ClientTransportFactory Instance => _instance ??= new ClientTransportFactory();
    private readonly Position _size = new(1000,500);
    
    private ClientTransportFactory()
    {
    }
    
    public ClientTransport CreateClientTransport(string type, Airport destination)
    {
        return (type switch
        {
            "Cargo" => new ClientCargo(destination),
            "Passenger" => new ClientPassenger(destination),
            _ => null
        })!;
    }
}