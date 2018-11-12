using System.IO;
public class FileXmlWriter : AbsWriter
{
	private FileStream fs;

	public FileXmlWriter(Stream stream) : base(stream)
	{
		if (stream is FileStream)
		{
			this.fs = stream as FileStream;
		}
	}

	public FileXmlWriter(string path) : this(new FileStream(path, FileMode.OpenOrCreate))
	{

	}

	public override void PreWrite(StreamWriter stream)
	{
		stream.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
	}

	public override void Write(WriteableNode node)
	{
		base.Write(node);
		if (fs != null)
		{
			fs.Dispose();
		}
	}

}
