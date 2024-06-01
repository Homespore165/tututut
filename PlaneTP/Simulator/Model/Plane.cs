using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public abstract class Plane : IXmlSerializable
{
	public State State { get; set; }
	public Position Position { get; set; }
	protected string _name;
	public string Name
	{
		get => _name;
		set => _name = value;
	}
	
	protected int _speed;
	public int Speed
	{
		get => _speed;
		set => _speed = value;
	}
	
	protected int _maintenanceTime;
	public int MaintenanceTime
	{
		get => _maintenanceTime;
		set => _maintenanceTime = value;
	}

	public Airport? Airport { get; set; }

	public Plane(string name, int speed, int maintenanceTime, Airport airport)
	{
		_name = name;
		_speed = speed;
		_maintenanceTime = maintenanceTime;
		State = new Waiting(this);
		Airport = airport;
	}

	protected Plane()
	{
		State = new Waiting(this);
	}


	public XmlSchema? GetSchema()
	{
		return null;
	}

	public void ReadXml(XmlReader reader)
	{
		throw new NotImplementedException();
	}

	public virtual void WriteXml(XmlWriter writer)
	{
		writer.WriteElementString("Name", _name);
		
		writer.WriteElementString("Speed", _speed.ToString());
		writer.WriteElementString("MaintenanceTime", _maintenanceTime.ToString());
	}
	
	public override string? ToString()
	{
		return _name + ";" + _speed + ";" + _maintenanceTime;
	}

	public void TimeStep()
	{
		State.TimeStep();
	}
}