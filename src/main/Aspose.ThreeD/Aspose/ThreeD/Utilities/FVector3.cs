using System;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// Represents a 3D vector
    /// </summary>
    public struct FVector3 : IEquatable<FVector3>
    {
        public float X;
        public float Y;
        public float Z;

        public FVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static readonly FVector3 Zero = new FVector3(0, 0, 0);
        public static readonly FVector3 One = new FVector3(1, 1, 1);

        public bool Equals(FVector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object? obj)
        {
            return obj is FVector3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public static bool operator ==(FVector3 left, FVector3 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FVector3 left, FVector3 right)
        {
            return !left.Equals(right);
        }
    }
}
