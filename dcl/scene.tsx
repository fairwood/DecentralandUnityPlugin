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
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <box position={{x:0,y:2.97,z:0}} scale={{x:2.7033,y:1.1506,z:0.2454139}} rotation={{x:0,y:24.42181,z:0}} withCollisions={true} material="#Blue"></box>
          <cylinder position={{x:0,y:1.2,z:0}} scale={{x:0.1,y:1.2,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
          <text position={{x:-0.069,y:2.97,z:-0.152}} scale={{x:0.1823306,y:0.1823306,z:0.1823306}} rotation={{x:0,y:24.42181,z:0}} value="Decentraland" width={25.49474} height={5.3625} fontSize={912} color="#00FF28"></text>
        </entity>
        <gltf-model position={{x:-3.5,y:0.39,z:0.56}} scale={{x:1,y:1,z:1}} rotation={{x:270,y:0,z:0}} src="./unity_assets/pyramid012428.gltf"></gltf-model>
        <gltf-model position={{x:-3.17,y:0.17,z:-2.09}} scale={{x:1,y:1,z:1}} rotation={{x:270,y:25.88162,z:0}} src="./unity_assets/pyramid_shouldpackchildren41940.gltf"></gltf-model>
        <gltf-model position={{x:9.09,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} src="./unity_assets/tree12146.gltf"></gltf-model>
        <video position={{x:9.21,y:2.38,z:0.44}} rotation={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} id="myVideo" width={4} src="xxxxx"></video>
        <box position={{x:2,y:1,z:-3.21}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Board"></box>
        <entity position={{x:-1.12,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <box position={{x:0,y:0.4,z:3}} scale={{x:0.1,y:0.8,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:0.4,z:2}} scale={{x:0.1,y:0.8,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:0.4,z:1}} scale={{x:0.1,y:0.8,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:0.4,z:0}} scale={{x:0.1,y:0.8,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:0.4,z:-1}} scale={{x:0.1,y:0.8,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:0.4,z:-2}} scale={{x:0.1,y:0.8,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:0.4,z:-3}} scale={{x:0.1,y:0.8,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:0.4,z:-4}} scale={{x:0.1,y:0.8,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:0.4,z:4}} scale={{x:0.1,y:0.8,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:0.8,z:0}} scale={{x:0.15,y:0.15,z:9}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
        </entity>
        <plane position={{x:4,y:1,z:-3.457}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:350.1897}} withCollisions={true} material="#Board"></plane>
        <sphere position={{x:5.51,y:1,z:-3.389}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Board"></sphere>
        <cylinder position={{x:7.92,y:1,z:-3.29}} scale={{x:1,y:1,z:1}} rotation={{x:13.88124,y:0,z:0}} withCollisions={true} material="#Board"></cylinder>
        <cone position={{x:10,y:1,z:-3.389}} scale={{x:1,y:1,z:1}} rotation={{x:347.4469,y:0,z:0}} withCollisions={true} material="#Board"></cone>
        <material id="Blue" albedoColor="#3C4C70" alpha={1} emissiveColor="#2C00BF" metallic={0} roughness={0.5}/>
        <material id="Rod" albedoColor="#563131" alpha={1} emissiveColor="#000000" metallic={0.206} roughness={0.186}/>
        <material id="Board" albedoColor="#FFFFFF" alpha={1} albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/colormap.png" hasAlpha={false} bumpTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/bump.jpg" emissiveColor="#000000" metallic={0} roughness={0.794}/>
        <material id="Gray" albedoColor="#4A4A4A" alpha={1} emissiveColor="#000000" metallic={0} roughness={0.5}/>
      </scene>
    )
  }
}
