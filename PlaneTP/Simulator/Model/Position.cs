using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public class Position : ICloneable
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
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="x">Positiion en X</param>
	/// <param name="y">Positiion en Y</param>
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
	/// <summary>
	/// Charger les positions d'un fichier XML
	/// </summary>
	/// <param name="reader">le fichier XML</param>
	public void ReadXml(XmlReader reader)
	{
		reader.ReadStartElement();

		_x = int.Parse(reader.ReadElementString("X"));
		_y = int.Parse(reader.ReadElementString("Y"));

		reader.ReadEndElement(); 
	}
	
	public static bool operator ==(Position a, Position b)
	{
		return a.X == b.X && a.Y == b.Y;
	}
	
	public static bool operator !=(Position a, Position b)
	{
		return !(a == b);
	}
	/// <summary>
	/// Constructeur de copie
	/// </summary>
	/// <returns>un clone</returns>
	public object Clone()
	{
		return new Position(X, Y);
	}
}