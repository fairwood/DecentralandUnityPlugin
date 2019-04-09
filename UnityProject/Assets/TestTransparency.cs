using UnityEngine;

public class TestTransparency : MonoBehaviour
{
    void Update()
    {
    }

    void OnGUI()
    {
        var rdrr = GetComponent<MeshRenderer>();
        if (rdrr && rdrr.sharedMaterial)
        {
            var material = rdrr.sharedMaterial;
            bool b0 = material.IsKeywordEnabled("_ALPHATEST_ON");
            var b1 = material.IsKeywordEnabled("_ALPHABLEND_ON");
            var b2 = material.IsKeywordEnabled("_ALPHAPREMULTIPLY_ON");
            GUILayout.Label(string.Format("{0}, {1}, {2}", b0, b1, b2));
        }
    }
}