using System.IO;
/// <summary>
/// 抽象Writer
/// 使用方法：
/// 可以通过传入不同的的Stream，来实现文件写入，或者网络写入
/// 如果内容除了Node信息之外，还有其他数据，可以覆写方法：PreWrite,PostWrite
/// </summary>
public  abstract class AbsWriter
{
	private StreamWriter stream;

	public AbsWriter(Stream stream)
	{
		this.stream = new StreamWriter(stream, System.Text.Encoding.UTF8);
	}

	public void PreWrite(StreamWriter stream) { }

	public void PostWrite(StreamWriter stream) { }

	public void Write(WriteableNode node)
	{
		PreWrite(stream);
		node.Write(stream);
		PostWrite(stream);
		stream.Flush();
	}

}
