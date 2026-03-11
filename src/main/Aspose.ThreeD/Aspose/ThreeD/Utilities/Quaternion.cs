using System;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// A quaternion is usually used to represent a rotation in 3D space.
    /// </summary>
    public struct Quaternion : IEquatable<Quaternion>
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static readonly Quaternion Identity = new Quaternion(0, 0, 0, 1);

        public bool Equals(Quaternion other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        public override bool Equals(object? obj)
        {
            return obj is Quaternion other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, W);
        }

        public static bool operator ==(Quaternion left, Quaternion right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Quaternion left, Quaternion right)
        {
            return !left.Equals(right);
        }
    }
}
