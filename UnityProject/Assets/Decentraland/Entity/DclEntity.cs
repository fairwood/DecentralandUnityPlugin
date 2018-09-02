using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dcl
{
    public class DclEntity
    {
        public const string TAG_ENTITY = "entity";

        public const string TAG_BOX = "box";

        public const string TAG_SPHERE = "sphere";

        public const string TAG_PLANE = "plane";
        
        public string Tag { get; set; }

        private List<DclEntity> children = new List<DclEntity>();

        public List<DclEntity> Children { get { return this.children; } }

        public string ID { get; set; }

        public Vector3 Position { get; set; }

        public Vector3 Rotation { get; set; }

        public Vector3 Scale { get; set; }

        public bool Visible { get; set; }

        public DclEntity()
        {
            
        }

        public DclEntity(string tag){
            this.Tag = tag;
        }
    }
}
