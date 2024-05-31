using Simulator.Model;

namespace Simulator;

public class Controller
{
    private static Controller _instance;
    public static Controller Instance => _instance ??= new Controller(); // Implementation de singleton. Pas thread-safe
    
    private Scenario _scenario;
    
    private SimForm _form;
    public SimForm Form
    {
        get => _form;
        set => _form = value;
    }
    
    private Controller()
    {
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