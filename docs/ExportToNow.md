# Export and Publish to Now.sh Workflow

1. Install Unity

https://store.unity.com/download

(Personal license is OK)

2. Install Now.sh Client

https://zeit.co/download

When finishing installation, you should see an Now.sh icon in the taskbar (both Windows and Mac)

![](./docs/installed_now_client.png)

You need to finish all the registration yourselves.

## Download Decentraland-Unity Plugin

[Decentraland-Unity Plugin](https://github.com/fairwood/DecentralandUnityPlugin/blob/master/downloads/DecentralandUnityExporter.unitypackage)

## Open the exporter and create a Unity scene

First, create a Unity project, better empty.

Then drag the downloaded **DecentralandUnityExporter.unitypackage** file into Unity or use "Import Assets.." in Unity. That will extract all assets into your Unity project.

After a while, you should see a new tab in the menu bar like below.

![](./docs/exporter_in_menu.png)

Click the "Scene Exporter" will open the exporter.

**Note:** an auto-generated GameObject called ".dcl" will be created in the hierarchy. Don't edit it.

You can create a new scene or open the sample scene:

![Exporter UI](./docs/samplescene.jpg)

The exporter looks like this:

![Exporter UI](./docs/exportergui.png)

## Export & Publish

Choose an empty folder as project folder. Then, click ```Export```.

![ExportToNow](./docs/export_to_now_part.png)

![](./docs/open_now_upload.png)

Select the project folder to deploy.

![](.docs/now_upgrade_or_deploy.png)

Just click ```Deploy``` if you see this dialog.

Then, a web page will be opened showing a lot of logs like below.

![](.docs/now_deploy_logs.png)

Wait for some minutes and you will see the scene!

You can share the address to others now!