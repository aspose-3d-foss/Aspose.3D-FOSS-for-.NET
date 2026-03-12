using System;

namespace Aspose.ThreeD.Utilities
{
    public class MathUtils
    {
        public static Vector3 CalcNormal(Vector3[] points)
        {
            if (points.Length < 3)
                throw new ArgumentException("At least 3 points are required to calculate a normal");

            Vector3 v1 = points[1] - points[0];
            Vector3 v2 = points[2] - points[0];
            Vector3 normal = v1.Cross(v2).Normalize();
            return normal;
        }

        public static int FindIntersection(Vector2 p0, Vector2 d0, Vector2 p1, Vector2 d1, Vector2[] results)
        {
            double det = d0.x * d1.y - d0.y * d1.x;
            if (det == 0)
                return 0;

            Vector2 dp = p1 - p0;
            double t = (dp.x * d1.y - dp.y * d1.x) / det;
            double u = (dp.x * d0.y - dp.y * d0.x) / det;

            if (results != null && results.Length > 0)
            {
                results[0] = p0 + d0 * t;
            }

            return 1;
        }

        public static bool PointInsideTriangle(Vector2 p, Vector2 p0, Vector2 p1, Vector2 p2)
        {
            double d1 = Sign(p, p0, p1);
            double d2 = Sign(p, p1, p2);
            double d3 = Sign(p, p2, p0);

            bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(hasNeg && hasPos);
        }

        private static double Sign(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
        }

        public static Vector2? RayIntersect(Vector2 origin, Vector2 dir, Vector2 a, Vector2 b)
        {
            Vector2 v1 = origin - a;
            Vector2 v2 = b - a;
            Vector2 v3 = new Vector2(-dir.y, dir.x);

            double dot = v2.x * v3.x + v2.y * v3.y;
            if (Math.Abs(dot) < 0.00001)
                return null;

            double t1 = (v2.x * v1.y - v2.y * v1.x) / dot;
            double t2 = (v1.x * v3.x + v1.y * v3.y) / dot;

            if (t1 >= 0 && (t2 >= 0 && t2 <= 1))
                return origin + dir * t1;

            return null;
        }

        public static double Clamp(double val, double min, double max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }

        public static Vector3 ToDegree(Vector3 radian)
        {
            return new Vector3(
                radian.x * 180.0 / Math.PI,
                radian.y * 180.0 / Math.PI,
                radian.z * 180.0 / Math.PI
            );
        }

        public static Vector3 ToRadian(Vector3 degree)
        {
            return new Vector3(
                degree.x * Math.PI / 180.0,
                degree.y * Math.PI / 180.0,
                degree.z * Math.PI / 180.0
            );
        }

        public static float ToDegree(float radian)
        {
            return (float)(radian * 180.0 / Math.PI);
        }

        public static double ToDegree(double radian)
        {
            return radian * 180.0 / Math.PI;
        }

        public static Vector3 ToDegree(double x, double y, double z)
        {
            return new Vector3(
                x * 180.0 / Math.PI,
                y * 180.0 / Math.PI,
                z * 180.0 / Math.PI
            );
        }

        public static float ToRadian(float degree)
        {
            return (float)(degree * Math.PI / 180.0);
        }

        public static double ToRadian(double degree)
        {
            return degree * Math.PI / 180.0;
        }

        public static Vector3 ToRadian(double x, double y, double z)
        {
            return new Vector3(
                x * Math.PI / 180.0,
                y * Math.PI / 180.0,
                z * Math.PI / 180.0
            );
        }
    }
}
