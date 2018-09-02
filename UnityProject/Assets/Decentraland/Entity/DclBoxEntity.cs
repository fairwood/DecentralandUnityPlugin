using System;
namespace Dcl
{
    public class DclBoxEntity : DclEntity
    {
        public string Color { get; set; }

        public string Material { get; set; }

        public bool WithCollisions { get; set; }

        public DclBoxEntity()
        {
            this.Tag = TAG_BOX;
        }
    }
}
