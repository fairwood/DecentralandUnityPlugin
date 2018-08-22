import * as DCL from 'metaverse-api'

// This is an interface, you can use it to enforce the types of your state
export interface IState {
  isDoorClosed: boolean
}

export default class UnityScene extends DCL.ScriptableScene<any, IState> {
  async render() {

    return (
      <scene position={{ x: 5, y: 0, z: 5 }}>
        <entity position={{ x: 0, y: 1, z: -10 }} scale={{ x: 1, y: 1, z: 1 }} rotation={{ x: 0, y: 0, z: 0 }}></entity>
        <entity position={{ x: 1.341, y: 6.197, z: -2.323 }} scale={{ x: 1, y: 1, z: 1 }} rotation={{ x: 50, y: 330, z: 0 }}></entity>
        <entity position={{ x: 0, y: 0, z: 0 }} scale={{ x: 1, y: 1, z: 1 }} rotation={{ x: 0, y: 0, z: 0 }}></entity>
        <box position={{ x: 0, y: 2.97, z: 0 }} scale={{ x: 2.7033, y: 1.1506, z: 0.2454139 }} rotation={{ x: 0, y: 24.42181, z: 0 }}></box>
        <entity position={{ x: -14.07, y: -0.2600312, z: 7.6 }} scale={{ x: 1, y: 1, z: 1 }} rotation={{ x: 0, y: 0, z: 0 }}></entity>
        <entity position={{ x: 0, y: 0, z: 0 }} scale={{ x: 1, y: 1, z: 1 }} rotation={{ x: 0, y: 0, z: 0 }}></entity>
        <cylinder position={{ x: 0, y: 1.2, z: 0 }} scale={{ x: 0.2, y: 1.2, z: 0.2 }} rotation={{ x: 0, y: 0, z: 0 }} radius={0.5}></cylinder>
        <box position={{ x: -1.21, y: 0.6264758, z: 0 }} scale={{ x: 0.16804, y: 0.2136183, z: 9.6 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <box position={{ x: -1.21, y: 0.253, z: 3.72 }} scale={{ x: 0.1, y: 0.5559312, z: 0.1 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <box position={{ x: -1.21, y: 0.253, z: 2.524 }} scale={{ x: 0.1, y: 0.5559312, z: 0.1 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <box position={{ x: -1.21, y: 0.253, z: 1.463 }} scale={{ x: 0.1, y: 0.5559312, z: 0.1 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <box position={{ x: -1.21, y: 0.253, z: 0.482 }} scale={{ x: 0.1, y: 0.5559312, z: 0.1 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <box position={{ x: -1.21, y: 0.253, z: -0.398 }} scale={{ x: 0.1, y: 0.5559312, z: 0.1 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <box position={{ x: -1.21, y: 0.253, z: -1.287 }} scale={{ x: 0.1, y: 0.5559312, z: 0.1 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <box position={{ x: -1.21, y: 0.253, z: -2.13 }} scale={{ x: 0.1, y: 0.5559312, z: 0.1 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <box position={{ x: -1.21, y: 0.253, z: -2.93 }} scale={{ x: 0.1, y: 0.5559312, z: 0.1 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <box position={{ x: -1.21, y: 0.253, z: -3.725 }} scale={{ x: 0.1, y: 0.5559312, z: 0.1 }} rotation={{ x: 0, y: 0, z: 0 }}></box>
        <text value="TEST 1,2,3" position={{ x: -1.21, y: 0.253, z: -4.548 }} rotation={{ x: 0, y: 0, z: 0 }}></text>
        <gltf-model
          position={{ x: 4, y: 1, z: 4 }}
          scale={0.5}
          src="models/testscene001.gltf"
        />
        
    <gltf-model
      src="https://caza.la/decentraland-shoal-scene/bichi.gltf"
      position={{ x:-4, y:1, z:-4 }}
      scale={1}
      transition={{
        position: { duration: 200 },
        rotation: { duration: 200 }
      }}
      skeletalAnimation={[{ clip: 'animation_0', playing: true, weight: 10 }]}
    />
      </scene>
    )
  }
}
