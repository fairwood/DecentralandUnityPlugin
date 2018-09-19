using UnityEngine;

namespace Dcl
{
    public class DclCylinder : DclObject
    {
        public float radius = 1;

        public float arc = 360/(Mathf.PI*2);

        public bool isTruncatedCone = false;

        public float radiusTop = 1;

        /** Radius of the bottom face (meters) */
        public float radiusBottom;

            /** Radial segments of the geometry. 4 will render a tetrahedron. */
        public int segmentsRadial;
        
        public int segmentsHeight; //以4棱柱为例：-1两个单面薄片8三角；0，1都正常16三角；2是24三角

            /** Render caps */
        //public bool openEnded = true; //not work in DCL yet
    }
}