using System;

namespace Aspose.ThreeD.Utilities
{
    public struct Vector4 : IComparable<Vector4>
    {
        public double X;
        public double Y;
        public double Z;
        public double W;

        public Vector4(Vector3 vec, double w)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            this.W = w;
        }

        public Vector4(Vector3 vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = 1.0;
        }

        public Vector4(FVector4 vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
            W = vec.W;
        }

        public Vector4(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1.0;
        }

        public Vector4(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public double Length => Math.Sqrt(X * X + Y * Y + Z * Z + W * W);

        public void Set(double newX, double newY, double newZ)
        {
            X = newX;
            Y = newY;
            Z = newZ;
            W = 1.0;
        }

        public void Set(double newX, double newY, double newZ, double newW)
        {
            X = newX;
            Y = newY;
            Z = newZ;
            W = newW;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector4 other && X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, W);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z}, {W})";
        }

        public int CompareTo(Vector4 other)
        {
            int cmp = X.CompareTo(other.X);
            if (cmp != 0) return cmp;
            cmp = Y.CompareTo(other.Y);
            if (cmp != 0) return cmp;
            cmp = Z.CompareTo(other.Z);
            if (cmp != 0) return cmp;
            return W.CompareTo(other.W);
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }

        public static Vector4 operator *(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z, lhs.W * rhs.W);
        }

        public static Vector4 operator *(Vector4 lhs, double rhs)
        {
            return new Vector4(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs, lhs.W * rhs);
        }

        public static explicit operator FVector4(Vector4 v)
        {
            return new FVector4(v);
        }
    }
}
