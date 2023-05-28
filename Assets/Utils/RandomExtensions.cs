using UnityEngine;
using Utils;

public static class RandomExtensions
{
    public static Vector3 GetRandomPositionInCircle(Vector3 center, float offset, float radius)
    {
        var randomPosition =
            Random.insideUnitSphere * (radius + offset) + center;
        return randomPosition.WithZeroZ();
    }
}