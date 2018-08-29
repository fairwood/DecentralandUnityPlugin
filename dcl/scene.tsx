import * as DCL from 'metaverse-api'

// This is an interface, you can use it to enforce the types of your state
export interface IState {
  isDoorClosed: boolean
}

export default class UnityScene extends DCL.ScriptableScene<any, IState> {
  async render() {

    return (
      <scene position={{x:5,y:0,z:5}}>
        <entity position={{x:0,y:1,z:-10}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <cone position={{x:3.55,y:0,z:-1.03}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} withCollisions={true}></cone>
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
          <cylinder position={{x:0,y:1.2,z:0}} scale={{x:0.2,y:1.2,z:0.2}} rotation={{x:0,y:0,z:0}} radius={0.5} withCollisions={true} material="#Rod"></cylinder>
          <text position={{x:-0.061,y:2.97,z:-0.134}} scale={{x:2.187967,y:2.187967,z:2.187967}} rotation={{x:0,y:24.42181,z:0}} value="Decentraland" width={2.324235} color="#00FF28"></text>
        </entity>
        <gltf-model position={{x:0,y:0,z:0}} scale={{x:0,y:0,z:0}} rotation={{x:0,y:0,z:0}} src="./unity_assets/Tree01.gltf"></gltf-model>
        <gltf-model position={{x:0,y:0,z:0}} scale={{x:0,y:0,z:0}} rotation={{x:0,y:0,z:0}} src="./unity_assets/pyramid01 (1).gltf"></gltf-model>
        <gltf-model position={{x:0,y:0,z:0}} scale={{x:0,y:0,z:0}} rotation={{x:0,y:0,z:0}} src="./unity_assets/pyramid01 (2).gltf"></gltf-model>
        <material id="Gray" albedoColor="#4A4A4A" emissiveColor="#000000"/>
        <material id="Blue" albedoColor="#3C4C70" emissiveColor="#3A00FF"/>
        <material id="Rod" albedoColor="#1C0000" emissiveColor="#000000"/>
      </scene>
    )
  }
}
