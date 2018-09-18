using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DclObject : MonoBehaviour
{
    public bool visible = true;

    [Tooltip("Only available for primitives")]
    public bool withCollision = false;


    void Update()
    {
        var rdrr = GetComponent<Renderer>();
        if (rdrr) rdrr.enabled = visible;
    }
}
