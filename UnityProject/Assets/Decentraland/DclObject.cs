using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[DisallowMultipleComponent]
[AddComponentMenu("DclObject")]
public class DclObject : MonoBehaviour
{
    public bool visible = true;

    [Tooltip("Only available for primitives")]
    public bool withCollision = false;


    void Update()
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
