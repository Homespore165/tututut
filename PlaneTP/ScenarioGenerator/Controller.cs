using System.Xml;
using ScenarioGenerator.Model;

namespace ScenarioGenerator;

public delegate void EmptyScenario();
public class Controller
{
	private static Controller _instance;
	public static Controller Instance => _instance ??= new Controller(); // Implementation de singleton. Pas thread-safe
	
	private event EmptyScenario _emptyScenarioEvent;

	private Scenario _scenario;
	
	private Form1 _form;
	public Form1 Form
	{
		get => _form;
		set => _form = value;
	}
	/// <summary>
	/// Constructeur
	/// </summary>
	private Controller()
	{
		_form = new Form1(this);
		_emptyScenarioEvent += _form.OnEmptyScenario;

		_scenario = new Scenario();
		_scenario.SubscribeAirportUpdate(_form.UpdateAirports);
		_scenario.SubscribePlaneUpdate(_form.UpdatePlanes);
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
		_scenario.AddPlane(airportId, name, type, speed, maintenanceTime, boardingTime, unboardingTime);
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
		_scenario.AddAirport(name, x, y, passengerTraffic, cargoTraffic);
		_scenario.SubscribePlaneUpdate(_form.UpdatePlanes);
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
	public void EditAirport(int airportId, string name, int x, int y, int passengerTraffic, int cargoTraffic)
	{
		_scenario.EditAirport(airportId, name, x, y, passengerTraffic, cargoTraffic);
	}
	/// <summary>
	/// Supprimer un aéroport
	/// </summary>
	/// <param name="id">Id de l'aéroport</param>
	public void DeleteAirport(int airportId)
	{
		_scenario.DeleteAirport(airportId);
	}
	/// <summary>
	/// Enregistrer le scénario actuel
	/// </summary>
	public void SaveScenario()
	{
		_scenario.Save();
	}
	/// <summary>
	/// Enregistrer les Indicateur de fréquances d'événements
	/// </summary>
	/// <param name="fire">Indicateur de la fréquance d'événement</param>
	/// <param name="recon">Indicateur de la fréquance d'événement</param>
	/// <param name="rescue">Indicateur de la fréquance d'événement</param>
	public void SaveFrequencies(int fire, int rescue, int recon)
	{
		_scenario.FrequencyFire = fire;
		_scenario.FrequencyRecon = recon;
		_scenario.FrequencyRescue = rescue;
	}
	/// <summary>
	/// Remplir le générateur à l'aide du scénario déja enregistré
	/// </summary>
	public void LoadScenario()
	{
		this.EmptyScenario();
		_scenario.Load();
	}
	/// <summary>
	/// Mise à 0 du scénario
	/// </summary>
	public void EmptyScenario()
	{
		_emptyScenarioEvent?.Invoke();
		_scenario = new Scenario();
        _scenario.SubscribeAirportUpdate(_form.UpdateAirports);
        _scenario.SubscribePlaneUpdate(_form.UpdatePlanes);
    }
	/// <summary>
	/// Retourne les avions d'un aéroport sélectionné
	/// </summary>
	/// <param name="airportId">L'aéroport sélectionné</param>
	/// <returns>Les avions de cet aéroport</returns>
	public string[] GetPlanes(int airportId)
	{
		return _scenario.GetPlanes(airportId);
	}
	/// <summary>
	/// Retourne la valeur de la fréquance d'événement d'incendie après le chargement d'un scénario
	/// </summary>
	/// <returns></returns>
	public int GetFire()
	{
		return _scenario.GetFire();
	}
	/// <summary>
	/// Retourne la valeur de la fréquance d'événement de reconnaissance après le chargement d'un scénario
	/// </summary>
	/// <returns>la valeur de la fréquance d'événement</returns>
	public int GetRecon()
	{
		return _scenario.GetRecon();
	}
	/// <summary>
	/// Retourne la valeur de la fréquance d'événement de sauvetage après le chargement d'un scénario
	/// </summary>
	/// <returns>la valeur de la fréquance d'événement</returns>
	public int GetRescue()
	{
		return _scenario.GetRescue();
	}
}