import * as DCL from 'metaverse-api'

// This is an interface, you can use it to enforce the types of your state
export interface IState {
  isDoorClosed: boolean
}

export default class UnityScene extends DCL.ScriptableScene<any, IState> {
  async render() {
    const doorRotation = {
      x: 0,
      y: this.state.isDoorClosed ? 0 : 90,
      z: 0
    }

    return (
      <scene position={{ x: 5, y: 0, z: 5 }}>
        <entity rotation={doorRotation} transition={{ rotation: { duration: 1000, timing: 'ease-in' } }}>
          <box id="door" scale={{ x: 1, y: 2, z: 0.05 }} position={{ x: 0.5, y: 1, z: 0 }} color="#00FF00" />
        </entity>
        <box position={{ x: 2, y: 1, z: 0 }} scale={{ x: 2, y: 2, z: 0.05 }} rotation={{ x: 0, y: 0, z: 0 }} color="#0000FF" />
        <box position={{ x: -1, y: 1, z: 0 }} scale={{ x: 2, y: 2.5, z: 0.05 }} color="#00AAAA"></box >
        <sphere position={{ x: 1, y: 1, z: 2 }} scale={{ x: 1, y: 1, z: 1 }} color="#00AAAA"></sphere >
        <cylinder position={{ x: -1, y: 1, z: 3 }} scale={{ x: 1, y: 1, z: 1 }} color="#00AAAA"></cylinder >
        <plane position={{ x: -1, y: 1, z: -3 }} scale={{ x: 1, y: 1, z: 1 }} color="#00AA00"></plane >
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
