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
        <entity position={{x:6.13,y:6.46,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:45,y:270,z:0}}></entity>
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <box position={{x:-1.45,y:1.601,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:340.3932,y:0,z:0}}>
          <cylinder position={{x:2.72,y:0.07,z:-0.16}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}} radius={0.5}></cylinder>
        </box>
        <sphere position={{x:2.93,y:1.74,z:-0.273499}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></sphere>
        <entity position={{x:-14.07,y:-0.2600312,z:7.6}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <sphere position={{x:2.93,y:1.74,z:-1.26}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></sphere>
      </scene>
    )
  }
}
