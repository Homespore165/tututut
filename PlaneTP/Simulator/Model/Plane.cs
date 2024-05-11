using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public abstract class Plane : IXmlSerializable
{
	protected Plane(string name, Position position, int speed, int maintenanceTime)
	{
		_name = name;
		_speed = speed;
		_maintenanceTime = maintenanceTime;
	}

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

	public Plane(string name, int speed, int maintenanceTime)
	{
		_name = name;
		_speed = speed;
		_maintenanceTime = maintenanceTime;
	}
	
	protected Plane() {}

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
}