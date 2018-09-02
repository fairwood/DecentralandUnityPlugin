using System;
namespace Dcl
{
    public class DclPlaneEntity:DclEntity
    {
        public string Color { get; set; }

        public string Material { get; set; }

        public bool WithCollisions { get; set; }

        public DclPlaneEntity()
        {
            this.Tag = TAG_PLANE;
        }
    }
}
