using System;
namespace Dcl
{
    public class DclCylinderEntity:DclEntity
    {
        public string Color { get; set; }

        public string Material { get; set; }

        public bool WithCollisions { get; set; }

        public DclCylinderEntity()
        {
        }
    }
}
