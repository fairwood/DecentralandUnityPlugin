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
		private DclPrimitiveType m_primitiveType = DclPrimitiveType.other;
		public DclPrimitiveType dclPrimitiveType { 
			get{return m_primitiveType;} 
			set{m_primitiveType = value;}
		}

		public void Start(){
			//由于之前的方式没有正确序列化m_primitiveType,这里重新赋值
			//Debug.Log(this.transform.gameObject.name + " DclObject start");
			var meshFilter = GetComponent<MeshFilter>();
			if(meshFilter!=null){
				for(int i =0; i<System.Enum.GetValues(typeof(DclPrimitiveType)).Length; ++i){
					DclPrimitiveType dclPT = (DclPrimitiveType)i;
					//Debug.Log(this.transform.gameObject.name + " "+i);
					if (meshFilter.sharedMesh == DclPrimitiveHelper.GetDclPrimitiveMesh (dclPT)) {
						//Debug.Log(this.transform.gameObject.name + " DclObject set primitiveType");
						m_primitiveType = dclPT;
					}
				}
			}
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