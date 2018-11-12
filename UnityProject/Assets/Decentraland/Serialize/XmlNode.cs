
using System.Collections.Generic;
using System.IO;
using System.Text;


public class XmlNode : WriteableNode
{
	private int x = 0;

	private int y = 0;

	private int z = 0;

	public XmlNode(int x, int y, int z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public override void AfterChildren(StreamWriter stream)
	{

		stream.WriteLine("</node>");
	}

	public override void BeforeChildren(StreamWriter stream)
	{
		string s = string.Format("< node x=\"{0}\" y=\"{1}\" z=\"{2}\" >", x, y, z);
		stream.WriteLine(s);
	}

	public override List<WriteableNode> Children()
	{
		return new List<WriteableNode>();
	}
}
