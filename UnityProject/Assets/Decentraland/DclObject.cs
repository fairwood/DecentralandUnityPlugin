using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class DclObject : MonoBehaviour
{
    [Tooltip("Only available for primitives")]
    public bool withCollision;
}
