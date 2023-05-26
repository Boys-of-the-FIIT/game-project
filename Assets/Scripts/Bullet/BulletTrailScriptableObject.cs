using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Trail Config", menuName = "ScriptableObject/Bullet Trail Config")]
public class BulletTrailScriptableObject : ScriptableObject
{

    public AnimationCurve widthCurve;
    public float durationTime = 0.5f;
    public float minVertexDistance = 0.1f;
    public Gradient gradient;
    public Material material;
    public int cornerVertices;
    public int endCapVertices;

    public void SetUpTrail(TrailRenderer trailRenderer)
    {
        trailRenderer.widthCurve = widthCurve;
        trailRenderer.time = durationTime;
        trailRenderer.minVertexDistance = minVertexDistance;
        trailRenderer.colorGradient = gradient;
        trailRenderer.sharedMaterial = material;
        trailRenderer.numCornerVertices = cornerVertices;
        trailRenderer.numCapVertices = endCapVertices;
    }
}
