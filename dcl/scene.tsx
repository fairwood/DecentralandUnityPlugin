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
        <entity position={{x:0,y:3,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:50,y:330,z:0}}></entity>
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <box position={{x:0,y:0,z:-0.12}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} material="#Board"></box>
        <cone position={{x:1.015023,y:0.4215235,z:-1.400313}} scale={{x:1,y:1,z:1}} rotation={{x:49.90312,y:0,z:0}}></cone>
        <material id="Board" albedoColor="#FFFFFF" albedoTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/colormap.png" bumpTexture="./unity_assets/Assets/Decentraland/Sample - 01/Materials/bump.jpg" emissiveColor="#000000" metallic={0} roughness={0.794}/>
      </scene>
    )
  }
}
