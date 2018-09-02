using System;
namespace Dcl
{
    /// <summary>
    /// 
    /// <sphere position={{ x: 5, y: 0, z: 2 }} color="#ff00aa" scale={2} />
    /// </summary>
    public class DclSphereEntity:DclEntity
    {

        public string Color { get; set; }

        public string Material { get; set; }

        public bool WithCollisions { get; set; }

        public DclSphereEntity()
        {
            this.Tag = TAG_SPHERE;
        }
    }
}
