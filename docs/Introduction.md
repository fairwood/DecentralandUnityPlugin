
# More about Decentraland Unity Plugin

## Introduction: What can you do

### 1. Export these elements

* Box

* Sphere

* Plane

* Cylinder

* Cone

* TextMesh (custom font is not supported; some SDK bugs remaining)

* Standard Materials

* Other models will be exported as glTF models (animations are not supported)

* AudioSource (NEW SUPPORTED!)

* Lights are not supported

**Note**: Sphere, Cylinder and Cone have a lot of triangles that might exceed dcl limit, so use them carefully.

**Note**: Non-scene assets (e.g. models, materials, textures) should not have same names though duplicated names are available in different folders.

### 2. Check whether you obey the scene limitation

![](./statsgui.png)

All potential errors will be warned right in Unity.

### 3. Create & preview a local scene

You can initialize an new dcl project and run a project right in Unity, if you have setup DCL SDK.

![](./exportgui.png)

**On Mac**, however, you need to run a script to let the ```Init Project``` and ```Start Project``` functions work. Just double-click the ```set_path.command``` file in Unity or in Finder.

![Set Path on Mac](./mac_set_path.png)

A terminal window will open saying the process is completed. Close it.

### 4. Edit land info

e.g. Parcel coordinates, ETH address, Owner's name & email

Edit your parcels' coordinates in this format:
```
12,-21
12,-22
13,-21
13,-22
```

**The first line will be the "base" parcel and set as the center in your scene.**

You can also fill up the Owner Info part if you want to publish the scene.

### Create Decentraland shapes and nodes

You must use the specific GameObjects to refer to the DCL primitives. To create a DCL primitive, you need to go to the following menu.

![](./dclprimitives_in_menu.png)


*Why don't we use Unity primitves? Because the primitives between Unity and DCL are different. For example, the Unity Cube and the DCL Box have different UV map, that will make your scene look different in two platforms.*

### Important notice about non-primitives

The exporter traverses the whole scene. When it finds a non-primitive model, it will pack the model all the model's children and export one gltf file. That means, GameObjects under a non-primitive model will not generate their own node, even if they are primitives themselves. Instead, their data will be contained in the parent's gltf file.

### Check what kinds of nodes will be exported

 you can also go through the hierarchy view where will tell you what type of node will be generated from each GameObject.

![](./hierarchy-node-icon.png)

### What are exported

2 files and 1 folder will be exported and all old files will be overridden:

* scene.tsx

* scene.json

* unity_assets/(.gltf and textures)

*If you want to publish the scene to IPFS, you should do it in the command line.*

## More Tools to Learn

### [ProBuilder](https://assetstore.unity.com/packages/tools/modeling/probuilder-111418)

**ProBuilder** is a very famous 3D building tool in Unity Asset Store. It is very convenient for level design or prototyping and can be a substitution to 3D modeling software like 3DS MAX. And, it is free now!
