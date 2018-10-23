# Properties4Net
include 2 files
-  Properties.cs
-  MessageSource.cs

### Properties.cs
```
string path = ...;
Properties properties = new Properties(path);
// print properties
Console.WriteLine(properties);

// get by key
string v = properties["key"];
Console.WriteLine(v);
```

### MessageSource.cs
```
string dir = ...
MessageSource ms = new MessageSource(dir,"message");
Console.WriteLine(ms);
// get default value by def locale(message.properties))
Console.WriteLine(ms.GetMessage("greet", new string[] { "alking" }, ""));

// get default value by locale zh_CN(message_zh_CN.properties)
Console.WriteLine(ms.GetMessage("greet", new string[]{"alking"}, "zh_CN"));
```