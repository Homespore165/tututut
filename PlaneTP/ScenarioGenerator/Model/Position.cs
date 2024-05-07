using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ScenarioGenerator.Model;

public class Position : IXmlSerializable
{
	private int _x;
	public int X
	{
		get => _x;
		set => _x = value;
	}
	
	private int _y;
	public int Y
	{
		get => _y;
		set => _y = value;
	}
	
	public Position(int x, int y)
	{
		_x = x;
		_y = y;
	}
	
	private Position() {}

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
		writer.WriteElementString("X", X.ToString());
		writer.WriteElementString("Y", Y.ToString());
	}
}