using Simulator.Model;
using System.Security.Cryptography.X509Certificates;

namespace Simulator;

public class Controller
{
    private static Controller? _instance;
    public static Controller Instance => _instance ??= new Controller();
    private Scenario? _scenario;
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
        
        _scenario!.SubscribeFlights(_form.updateFlights);
        _scenario!.SubscribeAirports(_form.updateAirports);
    }

    private void LoadSavedScenario()
    {
        _scenario = new Scenario();
        _scenario.Load();
    }

    public void TimeStep(int t)
    {
        for (int i = 0; i < t; i++)
        {
            _scenario!.TimeStep();
        }
        _scenario.updateView();
        GC.Collect();
    }
}