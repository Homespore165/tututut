using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ScenarioGenerator.Model;

public abstract class Plane : IXmlSerializable
{
	protected Plane(string name, Position position, int speed, int maintenanceTime)
	{
		_name = name;
		_position = position;
		_speed = speed;
		_maintenanceTime = maintenanceTime;
	}

	private string _name;
	public string Name
	{
		get => _name;
		set => _name = value;
	}
	
	private Position _position;
	public Position Position
	{
		get => _position;
		set => _position = value;
	}
	
	private int _speed;
	public int Speed
	{
		get => _speed;
		set => _speed = value;
	}
	
	private int _maintenanceTime;
	public int MaintenanceTime
	{
		get => _maintenanceTime;
		set => _maintenanceTime = value;
	}

	public Plane(string name, int x, int y, int speed, int maintenanceTime)
	{
		_name = name;
		_position = new Position(x, y);
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

	public void WriteXml(XmlWriter writer)
	{
		writer.WriteElementString("Name", _name);
		
		XmlSerializer positionSerializer = new XmlSerializer(typeof(Position));
		positionSerializer.Serialize(writer, Position);
		
		writer.WriteElementString("Speed", _speed.ToString());
		writer.WriteElementString("MaintenanceTime", _maintenanceTime.ToString());
	}
}