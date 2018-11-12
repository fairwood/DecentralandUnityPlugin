using System.IO;
using System.Text;
/// <summary>
/// 抽象Writer
/// 使用方法：
/// 可以通过传入不同的的Stream，来实现文件写入，或者网络写入
/// 如果内容除了Node信息之外，还有其他数据，可以覆写方法：PreWrite,PostWrite
/// </summary>
public  abstract class AbsWriter
{

	private Stream stream;

	public AbsWriter(Stream stream)
	{
		this.stream = stream;
	}

	public virtual void PreWrite(StreamWriter stream) { }

	public virtual void PostWrite(StreamWriter stream) { }

	public virtual void Write(WriteableNode node)
	{

		using (StreamWriter writer = new StreamWriter(stream, UTF8Encoding.UTF8))
		{
			PreWrite(writer);
			node.Write(writer);
			PostWrite(writer);
			stream.Flush();
		}	
	}

}
