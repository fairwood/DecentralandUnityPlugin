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
          <plane position={{x:0,y:4.1,z:0}} scale={{x:30,y:10,z:1}} rotation={{x:270,y:0,z:0}} withCollisions={true}></plane>
        </entity>
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <video position={{x:9.21,y:2.38,z:0.44}} rotation={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} id="myVideo" width={4} src="xxxxx"></video>
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
        <entity position={{x:-3.41,y:0,z:-3.984}} scale={{x:1.3902,y:1.3902,z:1.3902}} rotation={{x:0,y:330.0001,z:0}}>
          <plane position={{x:0,y:1.065,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:5.862269,y:0,z:0}} withCollisions={true} material="#Map"></plane>
          <box position={{x:-0.25,y:0.4,z:-0.03399992}} scale={{x:0.04000001,y:0.8256255,z:0.03999999}} rotation={{x:4.424723,y:-1.070407E-07,z:350.8755}} withCollisions={true}></box>
          <box position={{x:0.25,y:0.4,z:-0.034}} scale={{x:0.04000001,y:0.8256252,z:0.03999999}} rotation={{x:4.424723,y:2.676018E-08,z:9.123996}} withCollisions={true}></box>
          <box position={{x:0,y:0.392,z:0.205}} scale={{x:0.04,y:0.8888682,z:0.04}} rotation={{x:331.5615,y:0,z:0}} withCollisions={true}></box>
          <box position={{x:0,y:0.788,z:-0.004}} scale={{x:0.04000001,y:0.6386578,z:0.03999999}} rotation={{x:0,y:0,z:89.99983}} withCollisions={true}></box>
        </entity>
        <material id="BlueLight" albedoColor="#000000" alpha={1} emissiveColor="#2C00BF" metallic={0} roughness={0.5}/>
        <material id="Logo" albedoColor="#000000" alpha={1} emisiveTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/fairwood_logo.jpg" emissiveColor="#FFFFFF" metallic={0} roughness={0.5}/>
        <material id="Rod" albedoColor="#654E13" alpha={1} emissiveColor="#000000" metallic={1} roughness={0.331}/>
        <material id="Tape" albedoColor="#5E579E" alpha={0.2784314} emissiveColor="#000000" metallic={0} roughness={0.5}/>
        <material id="MatDemo" albedoColor="#FFFFFF" alpha={1} albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/colormap.png" hasAlpha={false} bumpTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/bump.jpg" emissiveColor="#000000" metallic={0} roughness={0.794}/>
        <material id="Map" albedoColor="#FFFFFF" alpha={1} albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/dcl_map.png" hasAlpha={false} emissiveColor="#000000" metallic={0} roughness={0.5}/>
      </scene>
    )
  }
}
