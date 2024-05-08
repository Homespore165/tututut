using System.Xml;
using System.Xml.Serialization;

namespace ScenarioGenerator.Model;

public abstract class PlaneTransport : Plane
{
	private int _boardingTime;
	public int BoardingTime
	{
		get => _boardingTime;
		set => _boardingTime = value;
	}
	
	private int _unboardTime;
	public int UnboardTime
	{
		get => _unboardTime;
		set => _unboardTime = value;
	}
	
	public PlaneTransport(string name, int x, int y, int speed, int maintenanceTime, int boardingTime, int unboardTime) : base(name, speed, maintenanceTime)
	{
		_boardingTime = boardingTime;
		_unboardTime = unboardTime;
	}
	
	protected PlaneTransport() {}
	
	public override void WriteXml(XmlWriter writer)
	{
		writer.WriteElementString("Name", _name);

		writer.WriteElementString("Speed", _speed.ToString());
		writer.WriteElementString("MaintenanceTime", _maintenanceTime.ToString());
		writer.WriteElementString("BoardingTime", _boardingTime.ToString());
		writer.WriteElementString("UnboardTime", _unboardTime.ToString());
	}
}