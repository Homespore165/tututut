using Simulator.Model;
using System.Security.Cryptography.X509Certificates;

namespace Simulator;

public class Controller
{
    private static Controller _instance = null;
    public static Controller Instance { get { 
            if (_instance is null)
            {
                new Controller();
            }
            return _instance;
        }
    }
    
    private Scenario _scenario;
    
    private SimForm _form;
    public SimForm Form
    {
        get => _form;
        set => _form = value;
    }
    
    private Controller()
    {
        _instance = this;

        _form = new SimForm();
        LoadSavedScenario();
        
        //TODO: subscribe to events
    }

    private void LoadSavedScenario()
    {
        _scenario = new Scenario();
        _scenario.Load();
    }
}