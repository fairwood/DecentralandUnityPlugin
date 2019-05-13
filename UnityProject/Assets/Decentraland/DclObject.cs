using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Dcl
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    [AddComponentMenu("DclObject", 0)]
    public class DclObject : MonoBehaviour
    {
        public bool visible = true;

        [Tooltip("Only available for primitives")]
        public bool withCollision = false;
		[SerializeField]
		private DclPrimitiveType m_primitiveType = DclPrimitiveType.other;
		public DclPrimitiveType dclPrimitiveType { 
			get{return m_primitiveType;} 
			set{m_primitiveType = value;}
		}

        public EDclNodeType dclNodeType; //for Hierarchy icon
        
        public void Start(){

		}

        protected void Update()
        {
            var rdrr = GetComponent<Renderer>();
            if (rdrr)
            {
                var dclObjects = GetComponentsInParent<DclObject>();
                var rdrrVisible = true;
                foreach (var dclObject in dclObjects)
                {
                    if (!dclObject.visible)
                    {
                        rdrrVisible = false;
                        break;
                    }
                }

                rdrr.enabled = rdrrVisible;
            }
        }
    }
}