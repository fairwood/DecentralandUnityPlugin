#SDK概述

## 介绍

**Decentraland SDK**包含alpha版本的API、CLI等工具，以及所有支持文档和示例。您需要这些文档和示例在Decentraland中创建、测试、管理和部署3D内容。SDK允许内容创建者和开发人员创建静态或动态场景，这些场景将在Decentraland平台上运行。


### 需求

请注意，开发一个场景并不需要土地。开发和测试一个场景可以完全脱机完成，而不需要将场景部署到Ethereum网络(用于土地确权的区块链系统)或IPFS(用于分发和传输内容的P2P网络)。

这个SDK是为了让开发人员或用户能够轻松地使用代码和终端。我们的大多数工具都构建在TypeScript和node.js生态之上。这就是为什么需要安装npm来开发场景，甚至是使用markup而不是代码构建的基本静态场景。


### 功能

在非常高的层次上，该SDK允许您执行以下操作:


* 生成一个默认项目，其中包含渲染和运行内容所需的资产集合。

* 在web浏览器中构建、测试和预览场景内容——完全脱机，无需进行任何Ethereum交易或自己的土地。

* 使用API编写TypeScript脚本，向场景添加交互和动态行为。

* 将场景内容上传到IPFS。

* 将您的土地与您上传的内容的IPFS URL链接。

### 场景是什么?

Decentraland中的**场景Scene**是在一个或多个地块上呈现的3D对象、贴图和音频的集合。场景可以:

* 本地场景：用于在用户的客户端内部运行。你的场景在WebWorker中运行，这意味着你不需要任何服务器来创建一个游戏。

* 远程场景：用于创建更丰富的游戏体验，比如需要控制很多场景状态或者游戏逻辑不能再客户端执行的游戏。这些场景在Node.js服务器运行，通过WebSockets和客户端连接。

* 静态：只包含3D对象和音频，没有交互。

使用CLI可在“projects”中创建场景。

How will users be able to see and interact with these scenes?
We are developing the web client that will allow users to explore Decentraland. All of the content you upload to your LAND will be rendered and viewable through this client. We have included a preview tool in the SDK so that you can preview, test, and interact with your content in the meantime.

The Decentraland client is still under active development. We’re shooting for a public release by the end of 2018. Stay tuned for future updates!

For additional terms, definitions, and explanations, please refer to our complete Glossary.


##### 这些场景会在哪里运行?

场景被部署到地块Parcel上。地块是10米×10米的虚拟土地，使用Ethereum智能合约确权，是一种稀缺且不可替代的资产。这些虚拟空间是您最终上传并与您用SDK创建的内容交互的地方。

##### 用户将如何看到这些场景并与之交互?

我们正在开发web客户端，让用户可以探索Decentraland。你上传到你的土地上的所有内容都将通过这个客户端呈现给用户。SDK包含一个预览工具，以便您可以随时预览、测试和与内容交互。


#### Decentraland客户端仍在积极开发中。我们计划在2018年底之前发布。请继续关注未来的更新!

For additional terms, definitions, and explanations, please refer to our complete Glossary.

有关其他术语、定义和解释，请参阅我们[完整的术语表](https://docs.decentraland.org/decentraland/glossary/)。

## 安装SDK

SDK包含许多不同的部件和组件。有关如何在SDK中下载和安装所有内容的详细、分步说明，请参阅SDK快速启动指南。


CLI

分权命令行接口(CLI)允许您在不位于块链或IPFS(星际文件系统)的开发环境中创建、部署和管理场景。


在您自己的机器上本地生成新的分散场景之后，您可以立即开始使用您选择的文本编辑器编辑场景。在本地测试场景之后，您可以使用CLI将内容上载到IPFS。


有关安装CLI的详细说明，请阅读我们的SDK快速入门指南或CLI教程


API

metaverse-api(通常称为API)是包含帮助器方法库的TypeScript包的名称，它允许您创建交互式的单人和多人体验。该API包括允许您在您的土地上创建和操作对象的方法，以及帮助促进用户或其他应用程序之间的实际事务的方法。