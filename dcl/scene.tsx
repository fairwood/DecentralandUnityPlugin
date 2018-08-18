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
        <entity position={{x:0,y:3,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:50,y:330,z:0}}></entity>
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <box position={{x:0,y:1.601,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:340.3932,y:0,z:0}}>
          <cylinder position={{x:1.73,y:-0.2600312,z:-0.273499}} scale={{x:1,y:1,z:1}} rotation={{x:1.008312,y:6.339324,z:341.9426}} radius={0.5}></cylinder>
        </box>
        <sphere position={{x:3.53,y:1.61,z:-0.273499}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></sphere>
        <entity position={{x:-14.07,y:-0.2600312,z:7.6}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <entity position={{x:0,y:0,z:0}} scale={{x:1,y:1,z:1}} rotation={{x:0,y:0,z:0}}></entity>
        <plane position={{x:-2.531,y:1.340969,z:-0.273499}} scale={{x:1,y:1.4595,z:1}} rotation={{x:0,y:0,z:12.78434}}></plane>
      </scene>
    )
  }
}
