using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Simulator.Model;

public class Position : IXmlSerializable, ICloneable
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
    /// Contructeur
    /// </summary>
    /// <param name="x">Coordonée X</param>
    /// <param name="y">Coordonée Y</param>
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
		reader.ReadStartElement();

		_x = int.Parse(reader.ReadElementString("X"));
		_y = int.Parse(reader.ReadElementString("Y"));

		reader.ReadEndElement(); 
	}

	public void WriteXml(XmlWriter writer)
	{
		writer.WriteElementString("X", X.ToString());
		writer.WriteElementString("Y", Y.ToString());
	}

    /// <summary>
    /// Opérateur de comparaison Position à Position
    /// </summary>
    /// <param name="a">La première position</param>
    /// <param name="b">La deuxième position</param>
    /// <returns>un booléen d'égalité</returns>
    public static bool operator ==(Position a, Position b)
	{
		return a.X == b.X && a.Y == b.Y;
	}

    /// <summary>
    /// Opérateur de comparaison inégale Position à Position
    /// </summary>
    /// <param name="a">La première position</param>
    /// <param name="b">La deuxième position</param>
    /// <returns>un booléen d'inégalité</returns>
    public static bool operator !=(Position a, Position b)
	{
		return !(a == b);
	}

	/// <summary>
	/// Clone la position
	/// </summary>
	/// <returns>Une position avec les même coordonées</returns>
	public object Clone()
	{
		return new Position(X, Y);
	}
}