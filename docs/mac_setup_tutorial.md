# mac set up tutorial


### 1.set NODE_HOME in PATH
##### 1.1 get node home
```
which node
/Users/dev/local/node-v8.12.0-darwin-x64/bin/node
``` 
then NODE_HOME var is ``` /Users/dev/local/node-v8.12.0-darwin-x64 ```
Note: this string not contains ``` bin```

##### 1.2 add NODE_HOME to PATH
```
echo "export NODE_HOME=\$HOME/local/node-v8.12.0-darwin-x64" >> ~/.bash_profile
echo "export PATH=\$PATH:\$NODE_HOME/bin" >> ~/.bash_profile
```
##### 1.3 veryfy PATH and NODE_HOME env var
```
source ~/.bash_profile
echo $NODE_HOME
// if NODE_HOME is set successfully then it will print below
/Users/dev/local/node-v8.12.0-darwin-x64
echo $PATH
......:/Users/dev/local/node-v8.12.0-darwin-x64/bin
```

### 2 init a sample scene using dcl command in a empty path
- using Unity open project ``` UnityProject```
- open DCL Exporter pannel,and choose  ``` DCL Project Path```
- click ```Init Project ``` button
- when open ``` Finer``` automatic,and then drag target path to ``` Terminal``` app
- type ``` dcl init``` and follow the guide

### 3 run dcl application
- click ```Run Project ``` button
- when open ``` Finer``` automatic,and then drag target path to ``` Terminal``` app
- type ``` dcl start```,you can see result in brower
