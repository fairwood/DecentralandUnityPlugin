using System.Collections.Generic;
using UnityEngine;

namespace Dcl
{
    public class SceneWarningRecorder
    {
        //多处发生---
        //超出parcels
        public class OutOfLand
        {
            public MeshRenderer meshRenderer;

            public OutOfLand(MeshRenderer meshRenderer)
            {
                this.meshRenderer = meshRenderer;
            }
        }
        //Shader不支持
        public class UnsupportedShader
        {
            public Material renderer;

            public UnsupportedShader(Material renderer)
            {
                this.renderer = renderer;
            }
        }
        //贴图尺寸不合规，太大
        public class InvalidTexture
        {
            public Texture renderer;

            public InvalidTexture(Texture renderer)
            {
                this.renderer = renderer;
            }
        }

        public readonly List<OutOfLand> OutOfLandWarnings = new List<OutOfLand>();
        public readonly List<UnsupportedShader> UnsupportedShaderWarnings = new List<UnsupportedShader>();
        public readonly List<InvalidTexture> InvalidTextureWarnings = new List<InvalidTexture>();

        //单次---
        //6种指标超出
    }
}