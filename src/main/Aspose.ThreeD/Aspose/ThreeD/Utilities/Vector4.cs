using System;

namespace Aspose.ThreeD.Utilities
{
    public struct Vector4 : IComparable<Vector4>, IEquatable<Vector4>
    {
        public double x;
        public double y;
        public double z;
        public double w;

        public Vector4(Vector3 vec, double w)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
            this.w = w;
        }

        public Vector4(Vector3 vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
            w = 1.0;
        }

        public Vector4(FVector4 vec)
        {
            x = vec.X;
            y = vec.Y;
            z = vec.Z;
            w = vec.W;
        }

        public Vector4(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            w = 1.0;
        }

        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public double Length => Math.Sqrt(x * x + y * y + z * z + w * w);

        public void Set(double newX, double newY, double newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = 1.0;
        }

        public void Set(double newX, double newY, double newZ, double newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
        }

        public bool Equals(object? obj)
        {
            return obj is Vector4 other && Equals(other);
        }

        public bool Equals(Vector4 rhs)
        {
            return x == rhs.x && y == rhs.y && z == rhs.z && w == rhs.w;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z, w);
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z}, {w})";
        }

        public int CompareTo(Vector4 other)
        {
            int cmp = x.CompareTo(other.x);
            if (cmp != 0) return cmp;
            cmp = y.CompareTo(other.y);
            if (cmp != 0) return cmp;
            cmp = z.CompareTo(other.z);
            if (cmp != 0) return cmp;
            return w.CompareTo(other.w);
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        public static Vector4 operator *(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
        }

         public static Vector4 operator *(Vector4 lhs, double rhs)
         {
             return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
         }

         public static Vector4 operator *(double lhs, Vector4 rhs)
         {
             return new Vector4(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs, rhs.w * lhs);
         }

         public static Vector4 operator *(Vector4 lhs, float rhs)
         {
             return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
         }

         public static Vector4 operator *(float lhs, Vector4 rhs)
         {
             return new Vector4(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs, rhs.w * lhs);
         }

         public static explicit operator FVector4(Vector4 v)
         {
             return new FVector4(v);
         }
     }
 }
