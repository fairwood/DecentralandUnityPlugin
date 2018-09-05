# Decentraland Unity Exporter

## What you can do

### 1. Export these elements

* Box

* Sphere

* Plane

* Cylinder

* Cone (UV is not correct yet)

* TextMesh (custom font is not supported)

* Standard Materials

* Other models will be exported as glTF models (animations are not supported)

* Lights are not supported!

**Note**: Sphere, Cylinder and Cone have a lot of triangles that might exceed dcl limit, so use them carefully.

**Note**: Non-scene assets (e.g. models, materials, textures) should not have same names though duplicated names are available in different folders.

### 2. Check whether you obey the scene limitation

![](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/docs/statsgui.png)

All potential errors will be warned right in Unity.

### 3. Create & preview a local scene

If you don't want to use command line tools.

![](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/docs/exportgui.png)

### 4. Edit the land info

e.g. Parcel coordinates, ETH address, Owner's name & email


## Installation Guide

You should prepare these tools on your own:

1. [dcl SDK](https://docs.decentraland.org/documentation/installation-guide/)

1. [Unity 5.x\2017\2018 or higher](https://unity3d.com/)

Then, download the Exporter which is inside a Unity Package. [Download the Exporter](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/downloads/DecentralandUnityExporter.unitypackage)


## Exporter Guide

### Open the exporter and create a Unity scene

First, create a Unity project, better empty.

Then drag the .unitypackage file into Unity or use "Import Assets.." in Unity. That will extract all assets into your Unity project.

After a while, you should see a new tab in the menu bar like below.

![](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/docs/exporter_in_menu.png)

Click the "Scene Exporter" will open the exporter.

**Note:** an auto-generated GameObject called ".dcl" will be created in the hierarchy. Don't edit it.

You can create a new scene or open the sample scene:

![Exporter UI](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/docs/samplescene.jpg)

The exporter looks like this:

![Exporter UI](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/docs/exportergui.png)

### Input land infomation

Edit your parcels' coordinates in this format:
```
12,-21
12,-22
13,-21
13,-22
...
```

**The first line will be the "base" parcel and set as the center in your scene.**

You can also fill up the Owner Info part if you want to publish the scene.

### Create shapes

You must use the specific GameObjects to refer to the DCL primitives. To create a DCL primitive, you need to go to the following menu.

![](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/docs/dclprimitives_in_menu.png)

If you want to convert a lot of Unity primitives into DCL primitives, there is a 'Convert' function in Decentraland tab in the menubar.

*Why don't we use Unity primitves? Because the primitives between Unity and DCL have a little difference. For example, the Unity Cube and the DCL Box have different UV map, that will make your scene look different in two platforms.*

Then, build your world as you like.

You can use models from outer model files (Unity does not support importing glTF, but we can export things as glTF). However, only the Unity Standard Shader is supported to export. That is enough to make a nice scene.

Most properties of the Standard Material can be well exported, but things might still look a bit different in DCL. We will improve the consistency all the time.

### Important notice about non-primitives

The exporter traverses the whole scene. When it finds a non-primitive model, it will pack the model all the model's children and export one gltf file. That means, GameObjects under a non-primitive model will not generate their own node, even if they are primitives themselves. Instead, their data will be contained in the parent's gltf file.

### Before export

Before export, you should check the statistics part. That shows some important indexes with their limitations. If something is wrong, you will see bright yellow warnings.

![](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/docs/statsgui.png)

Then, you can also go through the hierarchy view where will tell you what type of node will be generated from each GameObject.

![](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/docs/hierarchy-node-icon.png)

### Export

Input or select the path of the folder to export files.

If you select an empty folder, you maybe want to create a DCL project there. This can be done by click the 'Init Project' button instead of using command line tools (only supported on Windows yet).

2 files and 1 folder will be exported and override all old files:

* scene.tsx

* scene.json

* unity_assets/(.gltf and textures)

Click "Export" button to export. If success, a log will be shown in Unity console.

Finally, you can click 'Run Project' to see it in the browser (need to wait some seconds).

*If you want to publish the scene to IPFS, you should do it in the command line.*

## More Tools to Learn

### [ProBuilder](https://assetstore.unity.com/packages/tools/modeling/probuilder-111418)

**ProBuilder** is a very famous 3D building tool in Unity Asset Store. It is very convenient for level design or prototyping and can be a substitution to 3D modeling software like 3DS MAX. And, it is free now!

## Special Thanks to

### Support from Decentraland Team

Ari Meilich

[Esteban Ordano](https://github.com/eordano)

Matias Bargas

Chris Chapman

Jayson Hu

Diff

### Test Users

时光倒流

不异

### Unity-glTF Tools

[@neil3d/Unity-glTF-Exporter](https://github.com/neil3d/Unity-glTF-Exporter)