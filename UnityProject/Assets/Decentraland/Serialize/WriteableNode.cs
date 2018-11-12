using System.IO;
using System.Collections.Generic;

/// <summary>
/// 节点抽象类
/// 写入顺序:
/// 1.PreWrite
/// 2.WriteChildren 
///   2.1 BeforeChild
///   2.2 Child.Write
///   2.3 AfterChild
/// 3.PostWrite
/// </summary>
public abstract class WriteableNode
{
	void PreWrite(StreamWriter stream) { }

	void PostWrite(StreamWriter stream) { }

	void BeforeChild(StreamWriter stream, WriteableNode child) { }

	public abstract List<WriteableNode> Children();

	void AfterChild(StreamWriter stream, WriteableNode child) { }

	/// <summary>
	/// 建造者模式
	/// </summary>
	/// <param name="stream"></param>
	public void Write(StreamWriter stream)
	{
		PreWrite(stream);

		List<WriteableNode> children = Children();

		foreach (WriteableNode node in children)
		{
			BeforeChild(stream,node);

			node.Write(stream);

			AfterChild(stream,node);
	
		}
		PostWrite(stream);
	}
}
