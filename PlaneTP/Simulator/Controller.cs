
using Simulator.Model;

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
    }

    /// <summary>
    /// Charge le scénario XML sauvegardé
    /// </summary>
    public void LoadSavedScenario()
    {
        _scenario = new Scenario();
        _scenario.Load();
        _scenario!.SubscribeFlights(_form.updateFlights);
        _scenario!.SubscribeAirports(_form.updateAirports);
        _scenario!.SubscribeAirportsPlane(_form.updatePlaneList);
    }

    /// <summary>
    /// Avance le temps d'un quantité d'étapes
    /// </summary>
    /// <param name="t">Quantité d'étapes</param>
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