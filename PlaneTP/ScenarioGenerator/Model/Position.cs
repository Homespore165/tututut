﻿using System.Xml;
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
	/// <summary>
	/// Constructeur
	/// </summary>
	/// <param name="x">position en X</param>
	/// <param name="y">position en Y</param>
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
    /// Lire une position à partir d'un fichier XML
    /// </summary>
    /// <param name="reader"></param>
	public void ReadXml(XmlReader reader)
	{
		reader.ReadStartElement();

		_x = int.Parse(reader.ReadElementString("X"));
		_y = int.Parse(reader.ReadElementString("Y"));

		reader.ReadEndElement(); 
	}
	/// <summary>
	///  Enregistrer une position en XML
	/// </summary>
	/// <param name="writer">le fichier XML</param>
	public void WriteXml(XmlWriter writer)
	{
		writer.WriteElementString("X", X.ToString());
		writer.WriteElementString("Y", Y.ToString());
	}
}