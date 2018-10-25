import * as DCL from 'decentraland-api'

// This is an interface, you can use it to enforce the types of your state
export interface IState {
  isDoorClosed: boolean
}

export default class UnityScene extends DCL.ScriptableScene<any, IState> {
  async render() {

    return (
      <scene position={{x:5,y:0,z:5}}>
        <entity position={{x:0,y:1,z:-10}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <entity position={{x:1.341,y:6.197,z:-2.323}} scale={{x:1,y:1,z:1}} rotation={{x:50,y:330,z:0}}></entity>
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <entity position={{x:10,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <plane position={{x:0,y:3.68928,z:-4.97}} scale={{x:29.94,y:0.8,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true}></plane>
          <plane position={{x:0,y:3.68928,z:4.97}} scale={{x:29.94,y:0.8,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true}></plane>
          <plane position={{x:-14.97,y:3.68928,z:0}} scale={{x:9.970012,y:0.8,z:1}} rotation={{x:0,y:90,z:0}} withCollisions={true}></plane>
          <plane position={{x:14.97,y:3.68928,z:0}} scale={{x:9.970012,y:0.8,z:1}} rotation={{x:0,y:90,z:0}} withCollisions={true}></plane>
          <box position={{x:-14.958,y:2,z:-4.95}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:-4.956539,y:2,z:-4.95}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:5.043462,y:2,z:-4.95}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:14.96246,y:2,z:-4.95}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:-14.958,y:2,z:4.952}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:-4.956539,y:2,z:4.952}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:5.043462,y:2,z:4.952}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:14.958,y:2,z:4.952}} scale={{x:0.04,y:4,z:0.04}} rotation={{x:0,y:0,z:0}} withCollisions={true}></box>
          <plane position={{x:0,y:3.5,z:-4.98}} scale={{x:29.94,y:0.04,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#BlueLight"></plane>
          <plane position={{x:0,y:3.5,z:4.98}} scale={{x:29.94,y:0.04,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#BlueLight"></plane>
          <plane position={{x:-14.98,y:3.5,z:0}} scale={{x:9.970014,y:0.04,z:1}} rotation={{x:0,y:90,z:0}} withCollisions={true} material="#BlueLight"></plane>
          <plane position={{x:14.98,y:3.5,z:0}} scale={{x:9.970014,y:0.04,z:1}} rotation={{x:0,y:90,z:0}} withCollisions={true} material="#BlueLight"></plane>
          <text position={{x:-10,y:3.755,z:-4.999}} scale={{x:0.1846309,y:0.1846309,z:0.1846309}} rotation={{x:0,y:0,z:0}} value="DCL UNITY EXPORTER" width={53} height={5.3625} fontSize={912} color="#2C00BF"></text>
          <text position={{x:0,y:3.755,z:-4.999}} scale={{x:0.1846309,y:0.1846309,z:0.1846309}} rotation={{x:0,y:0,z:0}} value="DCL UNITY EXPORTER" width={53} height={5.3625} fontSize={912} color="#2C00BF"></text>
          <text position={{x:10,y:3.755,z:-4.999}} scale={{x:0.1846309,y:0.1846309,z:0.1846309}} rotation={{x:0,y:0,z:0}} value="DCL UNITY EXPORTER" width={53} height={5.3625} fontSize={912} color="#2C00BF"></text>
        </entity>
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <entity position={{x:0.5759439,y:-1.021851,z:7.30887}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <entity position={{x:2.106,y:0.5,z:-4.657}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <plane position={{x:-1,y:0.06,z:-0.3309999}} scale={{x:0.5617885,y:0.5617885,z:0.5617885}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Logo"></plane>
          <box position={{x:0,y:0,z:0}} scale={{x:3.0906,y:1,z:0.6410449}} rotation={{x:0,y:0,z:0}} withCollisions={true}>
            <plane position={{x:0.001,y:-0.345,z:-0.5038648}} scale={{x:1,y:0.04,z:1.559953}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#BlueLight"></plane>
          </box>
          <text position={{x:0.355,y:0.04500002,z:-0.342}} scale={{x:0.133473,y:0.133473,z:0.133473}} rotation={{x:0,y:0,z:0}} value="FAIRWOOD" width={26.6} height={5.3625} fontSize={912} color="#007619"></text>
        </entity>
        <entity position={{x:-1.62,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <entity position={{x:1.93,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
            <cylinder position={{x:-3.43,y:0.4,z:-1.532}} scale={{x:0.02,y:0.4,z:0.02}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
            <cylinder position={{x:3.57,y:0.4,z:-1.532}} scale={{x:0.02,y:0.4,z:0.02}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
            <cylinder position={{x:-3.43,y:0.4,z:0.89}} scale={{x:0.02,y:0.4,z:0.02}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
            <cylinder position={{x:3.57,y:0.4,z:0.89}} scale={{x:0.02,y:0.4,z:0.02}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
            <plane position={{x:0.07000005,y:0.65,z:-1.532}} scale={{x:7,y:0.08110655,z:1}} rotation={{x:0,y:0,z:0}} material="#Tape">
              <text position={{x:-0.3521428,y:0,z:-0.004700065}} scale={{x:0.004800823,y:0.4143409,z:0.03360576}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={37.2} height={5.3625} fontSize={912} color="#FF0017"></text>
              <text position={{x:-0.1297143,y:0,z:-0.004700065}} scale={{x:0.004801428,y:0.4143932,z:0.03361}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={37.2} height={5.3625} fontSize={912} color="#FF0017"></text>
              <text position={{x:0.08285712,y:0,z:-0.004700065}} scale={{x:0.004801428,y:0.4143932,z:0.03361}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={37.2} height={5.3625} fontSize={912} color="#FF0017"></text>
              <text position={{x:0.282,y:0,z:-0.004700065}} scale={{x:0.004801428,y:0.4143932,z:0.03361}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={37.2} height={5.3625} fontSize={912} color="#FF0017"></text>
            </plane>
            <plane position={{x:0.07000005,y:0.65,z:0.89}} scale={{x:7,y:0.08111,z:1}} rotation={{x:0,y:180,z:0}} material="#Tape">
              <text position={{x:-0.3521428,y:0,z:-0.004700065}} scale={{x:0.004800823,y:0.4143409,z:0.03360576}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={37.2} height={5.3625} fontSize={912} color="#FF0017"></text>
              <text position={{x:-0.1297143,y:0,z:-0.004700065}} scale={{x:0.004801428,y:0.4143932,z:0.03361}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={37.2} height={5.3625} fontSize={912} color="#FF0017"></text>
              <text position={{x:0.08285712,y:0,z:-0.004700065}} scale={{x:0.004801428,y:0.4143932,z:0.03361}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={37.2} height={5.3625} fontSize={912} color="#FF0017"></text>
              <text position={{x:0.282,y:0,z:-0.004700065}} scale={{x:0.004801428,y:0.4143932,z:0.03361}} rotation={{x:0,y:0,z:0}} value="DO NOT TOUCH" width={37.2} height={5.3625} fontSize={912} color="#FF0017"></text>
            </plane>
            <plane position={{x:-3.427,y:0.65,z:-0.323}} scale={{x:2.389797,y:0.08111,z:1}} rotation={{x:0,y:90,z:0}} material="#Tape"></plane>
            <plane position={{x:3.572,y:0.65,z:-0.323}} scale={{x:2.389802,y:0.08111,z:1}} rotation={{x:0,y:90,z:0}} material="#Tape"></plane>
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
          <box position={{x:-0.656,y:0.423,z:0}} scale={{x:0.8517668,y:0.8517668,z:0.8517668}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#MatDemo"></box>
          <plane position={{x:4.826,y:0.512,z:0}} scale={{x:0.7253101,y:0.7253101,z:0.72531}} rotation={{x:0,y:0,z:350.1897}} withCollisions={true} material="#MatDemo"></plane>
          <sphere position={{x:0.752,y:0.469,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#MatDemo"></sphere>
          <cylinder position={{x:2.148,y:0.479,z:0}} scale={{x:0.43202,y:0.4320199,z:0.4320199}} rotation={{x:13.88124,y:0,z:0}} withCollisions={true} material="#MatDemo"></cylinder>
          <cone position={{x:3.44,y:0.19,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:347.4469,y:0,z:0}} withCollisions={true} material="#MatDemo"></cone>
        </entity>
        <entity position={{x:10.08,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <box position={{x:-2.091,y:0.867,z:-0.725}} scale={{x:0.7059714,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.5050002}} scale={{x:0.07461976,y:0.3369948,z:0.1082158}} rotation={{x:0,y:0,z:0}} value="gltf-model" width={20.8} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <box position={{x:-0.606,y:1.8781,z:1.71}} scale={{x:0.5407659,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.5050003}} scale={{x:0.0974161,y:0.3369948,z:0.1082158}} rotation={{x:0,y:0,z:0}} value="video" width={11.2} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
          <box position={{x:2.529,y:0,z:-1.265}} scale={{x:0.70597,y:0.14604,z:0.14604}} rotation={{x:45,y:0,z:0}} withCollisions={true}>
            <text position={{x:0,y:0,z:-0.5050002}} scale={{x:0.07461976,y:0.3369948,z:0.1082158}} rotation={{x:0,y:0,z:0}} value="customized" width={24} height={3.79186} fontSize={912} color="#20209C"></text>
          </box>
        </entity>
        <entity position={{x:-3.41,y:0,z:-3.984}} scale={{x:1.3902,y:1.3902,z:1.3902}} rotation={{x:0,y:330.0001,z:0}}>
          <plane position={{x:0,y:1.065,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:5.862269,y:0,z:0}} withCollisions={true} material="#Map"></plane>
          <box position={{x:-0.25,y:0.4,z:-0.03399992}} scale={{x:0.04000001,y:0.8256255,z:0.03999999}} rotation={{x:4.424723,y:-1.070407E-07,z:350.8755}} withCollisions={true}></box>
          <box position={{x:0.25,y:0.4,z:-0.034}} scale={{x:0.04000001,y:0.8256252,z:0.03999999}} rotation={{x:4.424723,y:2.676018E-08,z:9.123996}} withCollisions={true}></box>
          <box position={{x:0,y:0.392,z:0.205}} scale={{x:0.04,y:0.8888682,z:0.04}} rotation={{x:331.5615,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:0,y:0.788,z:-0.004}} scale={{x:0.04000001,y:0.6386578,z:0.03999999}} rotation={{x:0,y:0,z:89.99983}} withCollisions={true}></box>
        </entity>
        <entity position={{x:9.74,y:0,z:1.96}} scale={{x:0.66929,y:0.66929,z:0.66929}} rotation={{x:0,y:0,z:0}}>
          <entity position={{x:-0.3299999,y:1.55,z:-0.96}} scale={{x:0.26215,y:0.26215,z:0.26215}} rotation={{x:0,y:180,z:0}}>
            <entity position={{x:-21.69661,y:21.91057,z:34.66195}} scale={{x:0.9999999,y:0.9999999,z:1}} rotation={{x:26.21716,y:147.9982,z:0.000775616}}></entity>
            <gltf-model position={{x:0.169058,y:-4.459234,z:-3.515694}} scale={{x:0.1541671,y:0.1541671,z:0.1541671}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube17526.gltf"></gltf-model>
            <gltf-model position={{x:12.11426,y:5.309812,z:-3.49059}} scale={{x:0.1367972,y:0.1367972,z:0.1367972}} rotation={{x:270,y:328.5754,z:0}} src="./unity_assets/Cube_00017330.gltf"></gltf-model>
            <gltf-model position={{x:0.2170952,y:-0.5116696,z:0.5035708}} scale={{x:1,y:1,z:1}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_00117642.gltf"></gltf-model>
            <gltf-model position={{x:0.1646543,y:5.259673,z:-5.59996}} scale={{x:0.1243247,y:0.1243247,z:0.1243247}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_00217498.gltf"></gltf-model>
            <gltf-model position={{x:10.1875,y:-0.1889177,z:-11.27131}} scale={{x:2.081236,y:2.081236,z:2.081236}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_00517180.gltf"></gltf-model>
            <gltf-model position={{x:-2.714492,y:-1.024216,z:-5.571743}} scale={{x:0.1946046,y:0.1946046,z:0.1946046}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_00717740.gltf"></gltf-model>
            <gltf-model position={{x:-3.949322,y:4.926924,z:-1.458153}} scale={{x:0.1817786,y:0.1817786,z:0.1817786}} rotation={{x:270,y:71.13519,z:0}} src="./unity_assets/Cube_00816940.gltf"></gltf-model>
            <gltf-model position={{x:0.2170952,y:-0.5116696,z:0.5035708}} scale={{x:1,y:1,z:1}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_00917490.gltf"></gltf-model>
            <gltf-model position={{x:-7.849312,y:8.45981,z:-4.598763}} scale={{x:2.751107,y:2.751107,z:2.751106}} rotation={{x:270,y:218.9466,z:0}} src="./unity_assets/Cube_01117096.gltf"></gltf-model>
            <gltf-model position={{x:-7.849312,y:8.45981,z:-4.598763}} scale={{x:2.751107,y:2.751107,z:2.751106}} rotation={{x:270,y:218.9466,z:0}} src="./unity_assets/Cube_01216966.gltf"></gltf-model>
            <gltf-model position={{x:12.11426,y:5.309812,z:-3.49059}} scale={{x:0.1367972,y:0.1367972,z:0.1367972}} rotation={{x:270,y:328.5754,z:0}} src="./unity_assets/Cube_01317044.gltf"></gltf-model>
            <gltf-model position={{x:0.1646543,y:5.259673,z:-5.59996}} scale={{x:0.1243247,y:0.1243247,z:0.1243247}} rotation={{x:270,y:0,z:0}} src="./unity_assets/Cube_01917350.gltf"></gltf-model>
            <gltf-model position={{x:-2.820696,y:8.664126,z:-5.094779}} scale={{x:0.2064836,y:0.2064836,z:0.2064836}} rotation={{x:23.96987,y:357.3994,z:90}} src="./unity_assets/Cylinder_00217634.gltf"></gltf-model>
          </entity>
          <box position={{x:-0.5799999,y:0.194,z:-7.292}} scale={{x:3.7196,y:0.68649,z:4.47296}} rotation={{x:339.8728,y:0,z:0}} withCollisions={true} material="#Floor"></box>
          <cylinder position={{x:-0.51,y:-4.8,z:-1.76}} scale={{x:4.052388,y:6.094869,z:4.052388}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Floor"></cylinder>
          <video position={{x:-0.341,y:3.66,z:0.297}} rotation={{x:0,y:0,z:0}} scale={{x:0.99,y:0.99,z:0.99}} width={1.98} height={1.08} src="http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4" play={true} volume={20}></video>
          <text position={{x:-0.3077879,y:1.922933,z:0.830731}} scale={{x:0.08341676,y:0.08341676,z:0.08341676}} rotation={{x:0,y:180,z:0}} value="https://sketchfab.com/models/691
45aa6647a42849487b6c3404f5075" width={74} height={10.88203} fontSize={912} color="#000000"></text>
        </entity>
        <material id="BlueLight" albedoColor="#000000" alpha={1} emissiveColor="#2C00BF" metallic={0} roughness={0.5}/>
        <material id="Logo" albedoColor="#000000" alpha={1} emisiveTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/fairwood_logo.jpg" emissiveColor="#FFFFFF" metallic={0} roughness={0.5}/>
        <material id="Rod" albedoColor="#654E13" alpha={1} emissiveColor="#000000" metallic={1} roughness={0.331}/>
        <material id="Tape" albedoColor="#5E579E" alpha={0.2784314} emissiveColor="#000000" metallic={0} roughness={0.5}/>
        <material id="MatDemo" albedoColor="#FFFFFF" alpha={1} albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/colormap.png" hasAlpha={false} bumpTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/bump.jpg" emissiveColor="#000000" metallic={0} roughness={0.794}/>
        <material id="Map" albedoColor="#FFFFFF" alpha={1} albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/dcl_map.png" hasAlpha={false} emissiveColor="#000000" metallic={0} roughness={0.5}/>
        <material id="Floor" albedoColor="#CCCCCC" alpha={1} albedoTexture="./unity_assets/Assets/Decentraland/Sample - 02/source/Floor.jpg" hasAlpha={false} emissiveColor="#000000" metallic={0} roughness={1}/>
      </scene>
    )
  }
}
