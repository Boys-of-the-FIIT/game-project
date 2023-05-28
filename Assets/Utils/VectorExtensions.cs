using UnityEngine;

namespace Utils
{
    public static class VectorExtensions
    {
        public static Vector3 WithZeroZ(this Vector3 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }
        
        public static Vector3 GetDirectionWithSpeed(this Vector3 direction, float speed)
        {
            return Time.deltaTime * speed * direction.normalized;
        }
    }
}