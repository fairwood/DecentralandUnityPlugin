using System.IO;
using System.Collections.Generic;

/// <summary>
/// 节点抽象类
/// 写入顺序:
/// 1.BeforeChildren
/// 2.WriteChildren 
///   2.1 BeforeChild
///   2.2 Child.Write
///   2.3 AfterChild
/// 3.AfterChildren
/// </summary>
public abstract class WriteableNode
{
	public virtual void BeforeChildren(StreamWriter stream) { }

	public virtual void AfterChildren(StreamWriter stream) { }

	public virtual void BeforeChild(StreamWriter stream, WriteableNode child) { }

	public abstract List<WriteableNode> Children();

	public virtual void AfterChild(StreamWriter stream, WriteableNode child) { }

	/// <summary>
	/// 建造者模式
	/// </summary>
	/// <param name="stream"></param>
	public void Write(StreamWriter stream)
	{
		BeforeChildren(stream);

		List<WriteableNode> children = Children();

		foreach (WriteableNode node in children)
		{
			BeforeChild(stream,node);

			node.Write(stream);

			AfterChild(stream,node);
	
		}
		AfterChildren(stream);
	}
}
