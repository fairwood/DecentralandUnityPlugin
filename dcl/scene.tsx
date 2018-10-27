import * as DCL from 'decentraland-api'

// This is an interface, you can use it to enforce the types of your state
export interface IState {
  isDoorClosed: boolean
}

export default class UnityScene extends DCL.ScriptableScene<any, IState> {
  async render() {

    return (
      <scene position={{x:5,y:0,z:5}}>
        <entity position={{x:10,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <plane position={{x:-5,y:3.68928,z:-4.97}} scale={{x:19.94,y:0.8,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true}></plane>
          <plane position={{x:-5,y:3.68928,z:4.97}} scale={{x:19.94,y:0.8,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true}></plane>
          <plane position={{x:-14.97,y:3.68928,z:0}} scale={{x:9.970012,y:0.8,z:1}} rotation={{x:0,y:90,z:0}} withCollisions={true}></plane>
          <plane position={{x:4.97,y:3.68928,z:0}} scale={{x:9.970012,y:0.8,z:1}} rotation={{x:0,y:90,z:0}} withCollisions={true}></plane>
          <box position={{x:-14.958,y:2,z:-4.95}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:-4.956539,y:2,z:-4.95}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:4.935,y:2,z:-4.95}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:-14.958,y:2,z:4.952}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:-4.956539,y:2,z:4.952}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:4.935,y:2,z:4.952}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <plane position={{x:-5,y:3.5,z:-4.98}} scale={{x:19.94,y:0.04,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#BlueLight"></plane>
          <plane position={{x:-5,y:3.5,z:4.98}} scale={{x:19.94,y:0.04,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#BlueLight"></plane>
          <plane position={{x:-14.98,y:3.5,z:0}} scale={{x:9.970014,y:0.04,z:1}} rotation={{x:0,y:90,z:0}} withCollisions={true} material="#BlueLight"></plane>
          <plane position={{x:4.98,y:3.5,z:0}} scale={{x:9.970014,y:0.04,z:1}} rotation={{x:0,y:90,z:0}} withCollisions={true} material="#BlueLight"></plane>
          <text position={{x:-10,y:3.755,z:-4.999}} scale={{x:0.1846309,y:0.1846309,z:0.1846309}} rotation={{x:0,y:0,z:0}} value="DCL UNITY EXPORTER" width={32} height={5.3625} fontSize={912} color="#2C00BF"></text>
          <text position={{x:0,y:3.755,z:-4.999}} scale={{x:0.1846309,y:0.1846309,z:0.1846309}} rotation={{x:0,y:0,z:0}} value="DCL UNITY EXPORTER" width={32} height={5.3625} fontSize={912} color="#2C00BF"></text>
          <plane position={{x:-5,y:4.1,z:0}} scale={{x:19.97,y:9.98,z:1}} rotation={{x:270,y:0,z:0}} withCollisions={true}></plane>
        </entity>
        <entity position={{x:2.106,y:0.5,z:-4.657}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <plane position={{x:-1,y:0.06,z:-0.3309999}} scale={{x:0.5617885,y:0.5617885,z:0.5617885}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Logo"></plane>
          <box position={{x:0,y:0,z:0}} scale={{x:3.0906,y:1,z:0.6410449}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Desk">
            <plane position={{x:0.001,y:-0.345,z:-0.5038648}} scale={{x:1,y:0.04,z:1.559953}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#BlueLight"></plane>
          </box>
          <text position={{x:0.355,y:0.04500002,z:-0.342}} scale={{x:0.133473,y:0.133473,z:0.133473}} rotation={{x:0,y:0,z:0}} value="FAIRWOOD" width={26.6} height={5.3625} fontSize={912} color="#007619"></text>
        </entity>
        <entity position={{x:-3.41,y:0,z:-3.984}} scale={{x:1.3902,y:1.3902,z:1.3902}} rotation={{x:0,y:330.0001,z:0}}>
          <plane position={{x:0,y:1.065,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:5.862269,y:0,z:0}} withCollisions={true} material="#Map"></plane>
          <box position={{x:-0.25,y:0.4,z:-0.03399992}} scale={{x:0.04000001,y:0.8256255,z:0.03999999}} rotation={{x:4.424723,y:-1.070407E-07,z:350.8755}} withCollisions={true}></box>
          <box position={{x:0.25,y:0.4,z:-0.034}} scale={{x:0.04000001,y:0.8256252,z:0.03999999}} rotation={{x:4.424723,y:2.676018E-08,z:9.123996}} withCollisions={true}></box>
          <box position={{x:0,y:0.392,z:0.205}} scale={{x:0.04,y:0.8888682,z:0.04}} rotation={{x:331.5615,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:0,y:0.788,z:-0.004}} scale={{x:0.04000001,y:0.6386578,z:0.03999999}} rotation={{x:0,y:0,z:89.99983}} withCollisions={true}></box>
        </entity>
        <entity position={{x:-1.62,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <entity position={{x:1.93,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
            <cylinder position={{x:-3.43,y:0.4,z:-1.532}} scale={{x:0.02,y:0.4,z:0.02}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
            <cylinder position={{x:5.57,y:0.4,z:-1.532}} scale={{x:0.02,y:0.4,z:0.02}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
            <cylinder position={{x:-3.43,y:0.4,z:0.89}} scale={{x:0.02,y:0.4,z:0.02}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
            <cylinder position={{x:5.57,y:0.4,z:0.89}} scale={{x:0.02,y:0.4,z:0.02}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
            <plane position={{x:1.07,y:0.65,z:-1.532}} scale={{x:8.986068,y:0.08110655,z:1}} rotation={{x:0,y:0,z:0}} material="#Tape">
              <text position={{x:-0.3521428,y:0,z:-0.004700065}} scale={{x:0.004800823,y:0.4143409,z:0.03360576}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={32} height={5.3625} fontSize={912} color="#FF0017"></text>
              <text position={{x:-0.1297143,y:0,z:-0.004700065}} scale={{x:0.004801428,y:0.4143932,z:0.03361}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={32} height={5.3625} fontSize={912} color="#FF0017"></text>
              <text position={{x:0.08285712,y:0,z:-0.004700065}} scale={{x:0.004801428,y:0.4143932,z:0.03361}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={32} height={5.3625} fontSize={912} color="#FF0017"></text>
              <text position={{x:0.282,y:0,z:-0.004700065}} scale={{x:0.004801428,y:0.4143932,z:0.03361}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={32} height={5.3625} fontSize={912} color="#FF0017"></text>
            </plane>
            <plane position={{x:1.07,y:0.65,z:0.89}} scale={{x:8.986068,y:0.08111,z:1}} rotation={{x:0,y:180,z:0}} material="#Tape"></plane>
            <plane position={{x:-3.427,y:0.65,z:-0.323}} scale={{x:2.389797,y:0.08111,z:1}} rotation={{x:0,y:90,z:0}} material="#Tape"></plane>
            <plane position={{x:5.572,y:0.65,z:-0.323}} scale={{x:2.389802,y:0.08111,z:1}} rotation={{x:0,y:90,z:0}} material="#Tape"></plane>
          </entity>
          <box position={{x:-0.661,y:0,z:-1.064}} scale={{x:0.4868,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.505}} scale={{x:0.1082157,y:0.3369947,z:0.1082157}} rotation={{x:0,y:0,z:0}} value="box" width={7.6} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <box position={{x:0.689,y:0,z:-1.064}} scale={{x:0.4868,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.505}} scale={{x:0.1082157,y:0.3369947,z:0.1082157}} rotation={{x:0,y:0,z:0}} value="sphere" width={14.4} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <box position={{x:2.105,y:0,z:-1.064}} scale={{x:0.4868,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.505}} scale={{x:0.1082157,y:0.3369947,z:0.1082157}} rotation={{x:0,y:0,z:0}} value="cylinder" width={16.2} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <box position={{x:3.413,y:0,z:-1.064}} scale={{x:0.4868,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.505}} scale={{x:0.1082157,y:0.3369947,z:0.1082157}} rotation={{x:0,y:0,z:0}} value="cone" width={10.2} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <box position={{x:4.701,y:0,z:-1.064}} scale={{x:0.4868,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.505}} scale={{x:0.1082157,y:0.3369947,z:0.1082157}} rotation={{x:0,y:0,z:0}} value="plane" width={11.4} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <box position={{x:-0.656,y:0.423,z:0}} scale={{x:0.8517668,y:0.8517668,z:0.8517668}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#DemoMat"></box>
          <plane position={{x:4.826,y:0.512,z:0}} scale={{x:0.7253101,y:0.7253101,z:0.72531}} rotation={{x:0,y:0,z:350.1897}} withCollisions={true} material="#DemoMat"></plane>
          <sphere position={{x:0.752,y:0.469,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#DemoMat"></sphere>
          <cylinder position={{x:2.148,y:0.479,z:0}} scale={{x:0.43202,y:0.4320199,z:0.4320199}} rotation={{x:13.88124,y:0,z:0}} withCollisions={true} material="#DemoMat"></cylinder>
          <cone position={{x:3.44,y:0.19,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:347.4469,y:0,z:0}} withCollisions={true} material="#DemoMat"></cone>
          <box position={{x:6.34,y:0.48,z:0}} scale={{x:0.6975996,y:0.6975996,z:0.6975996}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Metal"></box>
          <box position={{x:6.345,y:0,z:-1.064}} scale={{x:1.06,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.5050002}} scale={{x:0.04969757,y:0.3369948,z:0.1082157}} rotation={{x:0,y:0,z:0}} value="special material" width={32} height={3.791861} fontSize={912} color="#20209C"></text>
          </box>
        </entity>
        <entity position={{x:10.6,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <box position={{x:-2.091,y:0.867,z:-0.725}} scale={{x:0.7059714,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.5050002}} scale={{x:0.07461976,y:0.3369948,z:0.1082158}} rotation={{x:0,y:0,z:0}} value="gltf-model" width={20.8} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <box position={{x:-0.606,y:1.8781,z:1.71}} scale={{x:0.5407659,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.5050003}} scale={{x:0.0974161,y:0.3369948,z:0.1082158}} rotation={{x:0,y:0,z:0}} value="video" width={11.2} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <entity position={{x:-0.5608654,y:1.0374,z:1.317482}} scale={{x:0.1754544,y:0.1754544,z:0.1754544}} rotation={{x:0,y:180,z:0}}>
            <gltf-model position={{x:12.11426,y:5.309812,z:-3.49059}} scale={{x:0.1367972,y:0.1367972,z:0.1367972}} rotation={{x:270,y:328.5754,z:0}} src="./unity_assets/Cube_00012372.gltf"></gltf-model>
            <gltf-model position={{x:0.2170952,y:-0.5116696,z:0.5035708}} scale={{x:1,y:1,z:1}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_00112684.gltf"></gltf-model>
            <gltf-model position={{x:0.1646543,y:5.259673,z:-5.59996}} scale={{x:0.1243247,y:0.1243247,z:0.1243247}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_00212540.gltf"></gltf-model>
            <gltf-model position={{x:10.1875,y:-0.1889177,z:-11.27131}} scale={{x:2.081236,y:2.081236,z:2.081236}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_00512224.gltf"></gltf-model>
            <gltf-model position={{x:-7.849312,y:8.45981,z:-4.598763}} scale={{x:2.751107,y:2.751107,z:2.751106}} rotation={{x:270,y:218.9466,z:0}} src="./unity_assets/Cube_01112148.gltf"></gltf-model>
            <gltf-model position={{x:-7.849312,y:8.45981,z:-4.598763}} scale={{x:2.751107,y:2.751107,z:2.751106}} rotation={{x:270,y:218.9466,z:0}} src="./unity_assets/Cube_01212018.gltf"></gltf-model>
            <gltf-model position={{x:12.11426,y:5.309812,z:-3.49059}} scale={{x:0.1367972,y:0.1367972,z:0.1367972}} rotation={{x:270,y:328.5754,z:0}} src="./unity_assets/Cube_01312096.gltf"></gltf-model>
            <gltf-model position={{x:0.1646543,y:5.259673,z:-5.59996}} scale={{x:0.1243247,y:0.1243247,z:0.1243247}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_01912392.gltf"></gltf-model>
            <gltf-model position={{x:-2.820696,y:8.664126,z:-5.094779}} scale={{x:0.2064836,y:0.2064836,z:0.2064836}} rotation={{x:23.96987,y:357.3994,z:90}} src="./unity_assets/Cylinder_00212676.gltf"></gltf-model>
          </entity>
          <box position={{x:-0.7281885,y:0.1298423,z:-2.920463}} scale={{x:2.489491,y:0.4594609,z:2.993707}} rotation={{x:339.8728,y:0,z:0}} withCollisions={true} material="#Floor"></box>
          <cylinder position={{x:-0.6813383,y:-3.212592,z:0.7820497}} scale={{x:2.712223,y:4.079235,z:2.712223}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Floor"></cylinder>
          <video position={{x:-0.5682278,y:2.449601,z:2.158779}} rotation={{x:0,y:0,z:0}} scale={{x:0.6625971,y:0.6625971,z:0.6625971}} width={1.98} height={1.08} src="http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4" play={true} volume={20}></video>
          <entity position={{x:-0.06900024,y:2.568,z:2.109}} rotation={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} sound={{loop: true, playing: true, src: "https://github.com/fairwood/DecentralandUnityPlugin/blob/master/resources/bgm.mp3"}}></entity>
          <text position={{x:-0.5459995,y:1.287,z:2.516}} scale={{x:0.05583001,y:0.05583001,z:0.05583001}} rotation={{x:0,y:180,z:0}} value="https://sketchfab.com/models/691
45aa6647a42849487b6c3404f5075" width={32} height={10.88203} fontSize={912} color="#000000"></text>
          <box position={{x:4.348,y:0.001,z:-1.322}} scale={{x:0.9,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.5050003}} scale={{x:0.05853257,y:0.3369948,z:0.1082158}} rotation={{x:0,y:0,z:0}} value="out of range" width={25.4} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <box position={{x:4.33,y:0.968467,z:0.05}} scale={{x:1,y:1,z:1}} rotation={{x:322.2388,y:26.56494,z:320.7686}} withCollisions={true}></box>
        </entity>
        <material id="BlueLight" albedoColor="#000000" alpha={1} emissiveColor="#2C00BF" metallic={0} roughness={0.5}/>
        <material id="Logo" albedoColor="#000000" alpha={1} emisiveTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/fairwood_logo.jpg" emissiveColor="#FFFFFF" metallic={0} roughness={0.5}/>
        <material id="Desk" albedoColor="#E4E3DF" alpha={1} emissiveColor="#000000" metallic={0} roughness={0.11}/>
        <material id="Map" albedoColor="#FFFFFF" alpha={1} albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/dcl_map.png" hasAlpha={false} emissiveColor="#000000" metallic={0} roughness={0.5}/>
        <material id="Rod" albedoColor="#654E13" alpha={1} emissiveColor="#000000" metallic={1} roughness={0.331}/>
        <material id="Tape" albedoColor="#5E579E" alpha={0.2784314} emissiveColor="#000000" metallic={0} roughness={0.5}/>
        <material id="DemoMat" albedoColor="#FFFFFF" alpha={1} albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/colormap.png" hasAlpha={false} emissiveColor="#000000" metallic={0} roughness={0.07999998}/>
        <material id="Metal" albedoColor="#676767" alpha={1} bumpTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/bump.jpg" emissiveColor="#000000" metallic={1} roughness={0.43}/>
        <material id="Floor" albedoColor="#CCCCCC" alpha={1} albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Gamer/Floor.jpg" hasAlpha={false} emissiveColor="#000000" metallic={0} roughness={1}/>
      </scene>
    )
  }
}
