using UnityEngine;

[ExecuteInEditMode] // エディターでもスクリプトが実行される
[RequireComponent(typeof(LineRenderer))]
public class WireframeCube : MonoBehaviour
{
    public float size = 1f;
    public Color color = Color.white;

    private void OnEnable()
    {
        DrawWireframe();
    }

    private void OnValidate()
    {
        DrawWireframe(); // Inspector上の変更もすぐ反映
    }

    private void DrawWireframe()
    {
        var lr = GetComponent<LineRenderer>();
        if (lr == null) return;

        lr.useWorldSpace = false;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = color;
        lr.endColor = color;
        lr.widthMultiplier = 0.02f;
        lr.loop = false;

        float h = size / 2f;

        Vector3[] p = new Vector3[]
        {
            new Vector3(-h, -h, -h), new Vector3(h, -h, -h),
            new Vector3(h, -h, h),  new Vector3(-h, -h, h),
            new Vector3(-h, h, -h), new Vector3(h, h, -h),
            new Vector3(h, h, h),   new Vector3(-h, h, h)
        };

        Vector3[] edges = new Vector3[]
        {
            p[0], p[1], p[1], p[2], p[2], p[3], p[3], p[0],
            p[4], p[5], p[5], p[6], p[6], p[7], p[7], p[4],
            p[0], p[4], p[1], p[5], p[2], p[6], p[3], p[7]
        };

        lr.positionCount = edges.Length;
        lr.SetPositions(edges);
    }
}
