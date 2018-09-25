# mac set up tutorial

### 1. set up ```nodejs``` and ```npm```

##### 1. download file from [https://nodejs.org/en/download/](https://nodejs.org/en/download/)
choose macOS Binary ```tar.gz``` file, for example ```node-v8.12.0-darwin-x64.tar.gz```
and then copy to path you wanted for example ```local```
```
cd ~/local
tar -xf node-v8.12.0-darwin-x64.tar.gz
```

##### 2. add node to your path
```
echo "export NODE_HOME=\$HOME/local/node-v8.12.0-darwin-x64" >> ~/.bash_profile
echo "export PATH=\$PATH:\$NODE_HOME/bin" >> ~/.bash_profile

```

##### 3.verify node and npm is works
```
source ~/.bash_profile
node -v
v8.12.0

npm -v
6.4.1

```
congratulations it works

### 2. set up dcl env
##### 2.1[link](https://docs.decentraland.org/getting-started/create-scene/#install-the-cli)
```
npm install -g decentraland
// wait for a moment
```
##### 2.2 verify ``` dcl ``` works
type ``` dcl -v``` in shell mode
```
dcl -v

  Decentraland CLI v1.3.0

  Commands:

    help [command...]   Provides help for a given command.
    exit                Exits application.
    init [options]      Generates new Decentraland scene.
    preview [options]   Starts local development server.
    deploy [options]    Uploads scene to IPFS and updates IPNS.
    pin [options]       Notifies an external IPFS node to pin local files.
    link [options]      Link scene to Ethereum.
    info [target]       Displays information about the project, a LAND or a LAND owner
                        
    status [target]     Displays the deployment status of the project or a given LAND
```
ongratulations,dcl works now!

### 3 init a sample scene using dcl command in a empty path
- using Unity open project ``` UnityProject```
- open DCL Exporter pannel,and choose  ``` DCL Project Path```
- click ```Init Project ``` button
- when open ``` Finer``` automatic,and then drag target path to ``` Terminal``` app
- type ``` dcl init``` and follow the guide

### 4 run dcl application
- click ```Run Project ``` button
- when open ``` Finer``` automatic,and then drag target path to ``` Terminal``` app
- type ``` dcl start```,you can see result in brower