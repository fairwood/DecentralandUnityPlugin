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
        <cone position={{x:3.55,y:0,z:-1.03}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Board"></cone>
        <gltf-model position={{x:0,y:0,z:0}} scale={{x:0,y:0,z:0}} rotation={{x:0,y:0,z:0}} src="./unity_assets/pyramid01.gltf"></gltf-model>
        <entity position={{x:1.341,y:6.197,z:-2.323}} scale={{x:1,y:1,z:1}} rotation={{x:50,y:330,z:0}}></entity>
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <box position={{x:-1.21,y:0.6264758,z:0}} scale={{x:0.16804,y:0.2136183,z:9.6}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray">
          <box position={{x:0,y:-1.748332,z:0.3875}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:-1.748332,z:0.2629166}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:-1.748332,z:0.1523958}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:-1.748332,z:0.05020833}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:-1.748332,z:-0.04145833}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:-1.748332,z:-0.1340625}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:-1.748332,z:-0.221875}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:-1.748332,z:-0.3052083}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:-1.748332,z:-0.3880208}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
          <box position={{x:0,y:-1.748332,z:-0.4737499}} scale={{x:0.5950964,y:2.602451,z:0.01041667}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Gray"></box>
        </box>
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}>
          <box position={{x:0,y:2.97,z:0}} scale={{x:2.7033,y:1.1506,z:0.2454139}} rotation={{x:0,y:24.42181,z:0}} withCollisions={true} material="#Blue"></box>
          <cylinder position={{x:0,y:1.2,z:0}} scale={{x:0.1,y:1.2,z:0.1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></cylinder>
          <text position={{x:-0.061,y:2.97,z:-0.134}} scale={{x:2.187967,y:2.187967,z:2.187967}} rotation={{x:0,y:24.42181,z:0}} value="Decentraland" width={1.162118} height={0.244437} color="#00FF28"></text>
        </entity>
        <gltf-model position={{x:0,y:0,z:0}} scale={{x:0,y:0,z:0}} rotation={{x:0,y:0,z:0}} src="./unity_assets/pyramid01 (1).gltf"></gltf-model>
        <gltf-model position={{x:0,y:0,z:0}} scale={{x:0,y:0,z:0}} rotation={{x:0,y:0,z:0}} src="./unity_assets/pyramid01 (2).gltf"></gltf-model>
        <sphere position={{x:1.4,y:0.69,z:-2.263}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Rod"></sphere>
        <box position={{x:5.5,y:0.5,z:-3.5}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Board"></box>
        <plane position={{x:9.5,y:1.939861,z:-0.4372959}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Board"></plane>
        <cylinder position={{x:3.281,y:18.566,z:-3.761227}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true} material="#Board"></cylinder>
        <cylinder position={{x:8,y:1,z:-3}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:343.7085}} withCollisions={true} material="#Board"></cylinder>
        <material id="Board" albedoColor="#FFFFFF" albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/colormap.png" bumpTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/bump.jpg" emissiveColor="#000000" metallic={0} roughness={0.794}/>
        <material id="Gray" albedoColor="#4A4A4A" emissiveColor="#000000" metallic={0} roughness={0.5}/>
        <material id="Blue" albedoColor="#3C4C70" emissiveColor="#2C00BF" metallic={0} roughness={0.5}/>
        <material id="Rod" albedoColor="#FFFFFF" albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/colormap.png" emissiveColor="#000000" metallic={0.206} roughness={0.186}/>
      </scene>
    )
  }
}
