using System;

namespace Aspose.ThreeD.Utilities
{
    public struct FVector4 : IComparable<FVector4>
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public FVector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public FVector4(FVector3 xyz, float w)
        {
            X = xyz.X;
            Y = xyz.Y;
            Z = xyz.Z;
            W = w;
        }

        public FVector4(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1.0f;
        }

        public FVector4(Vector4 vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
            W = (float)vec.W;
        }

        public FVector4(Vector3 vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
            W = 1.0f;
        }

        public FVector4(Vector3 vec, float w)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
            W = w;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z}, {W})";
        }

        public int CompareTo(FVector4 other)
        {
            int cmp = X.CompareTo(other.X);
            if (cmp != 0) return cmp;
            cmp = Y.CompareTo(other.Y);
            if (cmp != 0) return cmp;
            cmp = Z.CompareTo(other.Z);
            if (cmp != 0) return cmp;
            return W.CompareTo(other.W);
        }

        public static explicit operator Vector4(FVector4 v)
        {
            return new Vector4(v.X, v.Y, v.Z, v.W);
        }

        public static FVector4 operator +(FVector4 lhs, FVector4 rhs)
        {
            return new FVector4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }

        public static FVector4 operator -(FVector4 lhs, FVector4 rhs)
        {
            return new FVector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }

        public static FVector4 operator *(FVector4 lhs, FVector4 rhs)
        {
            return new FVector4(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z, lhs.W * rhs.W);
        }

        public static FVector4 operator *(FVector4 lhs, float rhs)
        {
            return new FVector4(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs, lhs.W * rhs);
        }

        public static FVector4 operator *(float lhs, FVector4 rhs)
        {
            return new FVector4(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z, lhs * rhs.W);
        }
    }
}
