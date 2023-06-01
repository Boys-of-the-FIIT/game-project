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

        public static Vector3 CalculateInterception(
            Vector3 shooterLocation, // Pc
            Vector3 targetLocation, // Pr
            float bulletSpeed, // Sc
            Vector3 targetVelocity // Vr
        )
        {
            var targetSpeed = targetVelocity.magnitude; // Sr

            var targetToShooterDirection = shooterLocation - targetLocation; // D
            var shooterToTargetDistance = targetToShooterDirection.magnitude; // d

            var a = bulletSpeed * bulletSpeed - targetSpeed * targetSpeed;
            var b = 2 * Vector3.Dot(targetToShooterDirection, targetVelocity);
            var c = -shooterToTargetDistance * shooterToTargetDistance;

            var b2 = b * b;
            var ac4 = 4 * a * c;
            var a2 = 2 * a;

            var t1 = (-b + Mathf.Sqrt(b2 - ac4)) / a2;
            var t2 = (-b - Mathf.Sqrt(b2 - ac4)) / a2;

            if (t1 < 0 && t2 < 0)
            {
                return targetLocation;
            }

            var t = t1 > 0 && t2 > 0
                ? Mathf.Min(t1, t2)
                : Mathf.Max(t1, t2);

            var pointIntersection = targetLocation + t * targetVelocity;

            return pointIntersection;
        }
    }
}