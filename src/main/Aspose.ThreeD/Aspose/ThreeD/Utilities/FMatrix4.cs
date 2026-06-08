using System;

namespace Aspose.ThreeD.Utilities
{
    public struct FMatrix4 : IEquatable<FMatrix4>
    {
        public float m00, m01, m02, m03;
        public float m10, m11, m12, m13;
        public float m20, m21, m22, m23;
        public float m30, m31, m32, m33;

        public FMatrix4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
        {
            this.m00 = m00; this.m01 = m01; this.m02 = m02; this.m03 = m03;
            this.m10 = m10; this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m20 = m20; this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m30 = m30; this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        public FMatrix4(Matrix4 mat)
        {
            m00 = (float)mat.m00; m01 = (float)mat.m01; m02 = (float)mat.m02; m03 = (float)mat.m03;
            m10 = (float)mat.m10; m11 = (float)mat.m11; m12 = (float)mat.m12; m13 = (float)mat.m13;
            m20 = (float)mat.m20; m21 = (float)mat.m21; m22 = (float)mat.m22; m23 = (float)mat.m23;
            m30 = (float)mat.m30; m31 = (float)mat.m31; m32 = (float)mat.m32; m33 = (float)mat.m33;
        }

        public FMatrix4(FVector4 r0, FVector4 r1, FVector4 r2, FVector4 r3)
        {
            m00 = r0.X; m01 = r0.Y; m02 = r0.Z; m03 = r0.W;
            m10 = r1.X; m11 = r1.Y; m12 = r1.Z; m13 = r1.W;
            m20 = r2.X; m21 = r2.Y; m22 = r2.Z; m23 = r2.W;
            m30 = r3.X; m31 = r3.Y; m32 = r3.Z; m33 = r3.W;
        }

        public static FMatrix4 Identity => new FMatrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

        public FMatrix4 Concatenate(FMatrix4 m2) => this * m2;
        public FMatrix4 Concatenate(Matrix4 m2) => this * new FMatrix4(m2);

        public FMatrix4 Transpose() => new FMatrix4(m00, m10, m20, m30, m01, m11, m21, m31, m02, m12, m22, m32, m03, m13, m23, m33);

        public FMatrix4 Inverse() => Identity;

        public static FMatrix4 operator *(FMatrix4 left, FMatrix4 right)
        {
            return new FMatrix4(
                left.m00 * right.m00 + left.m01 * right.m10 + left.m02 * right.m20 + left.m03 * right.m30,
                left.m00 * right.m01 + left.m01 * right.m11 + left.m02 * right.m21 + left.m03 * right.m31,
                left.m00 * right.m02 + left.m01 * right.m12 + left.m02 * right.m22 + left.m03 * right.m32,
                left.m00 * right.m03 + left.m01 * right.m13 + left.m02 * right.m23 + left.m03 * right.m33,
                left.m10 * right.m00 + left.m11 * right.m10 + left.m12 * right.m20 + left.m13 * right.m30,
                left.m10 * right.m01 + left.m11 * right.m11 + left.m12 * right.m21 + left.m13 * right.m31,
                left.m10 * right.m02 + left.m11 * right.m12 + left.m12 * right.m22 + left.m13 * right.m32,
                left.m10 * right.m03 + left.m11 * right.m13 + left.m12 * right.m23 + left.m13 * right.m33,
                left.m20 * right.m00 + left.m21 * right.m10 + left.m22 * right.m20 + left.m23 * right.m30,
                left.m20 * right.m01 + left.m21 * right.m11 + left.m22 * right.m21 + left.m23 * right.m31,
                left.m20 * right.m02 + left.m21 * right.m12 + left.m22 * right.m22 + left.m23 * right.m32,
                left.m20 * right.m03 + left.m21 * right.m13 + left.m22 * right.m23 + left.m23 * right.m33,
                left.m30 * right.m00 + left.m31 * right.m10 + left.m32 * right.m20 + left.m33 * right.m30,
                left.m30 * right.m01 + left.m31 * right.m11 + left.m32 * right.m21 + left.m33 * right.m31,
                left.m30 * right.m02 + left.m31 * right.m12 + left.m32 * right.m22 + left.m33 * right.m32,
                left.m30 * right.m03 + left.m31 * right.m13 + left.m32 * right.m23 + left.m33 * right.m33);
        }

        public static FMatrix4 operator *(FMatrix4 lhs, float v) => new FMatrix4(lhs.m00 * v, lhs.m01 * v, lhs.m02 * v, lhs.m03 * v, lhs.m10 * v, lhs.m11 * v, lhs.m12 * v, lhs.m13 * v, lhs.m20 * v, lhs.m21 * v, lhs.m22 * v, lhs.m23 * v, lhs.m30 * v, lhs.m31 * v, lhs.m32 * v, lhs.m33 * v);
        public static FVector3 operator *(FMatrix4 lhs, FVector3 v) => new FVector3(lhs.m00 * v.X + lhs.m01 * v.Y + lhs.m02 * v.Z + lhs.m03, lhs.m10 * v.X + lhs.m11 * v.Y + lhs.m12 * v.Z + lhs.m13, lhs.m20 * v.X + lhs.m21 * v.Y + lhs.m22 * v.Z + lhs.m23);

        public static bool operator ==(FMatrix4 left, FMatrix4 right) => left.Equals(right);

        public static bool operator !=(FMatrix4 left, FMatrix4 right) => !left.Equals(right);

        public override bool Equals(object? obj) => obj is FMatrix4 && this == (FMatrix4)obj;

        public bool Equals(FMatrix4 other) => m00 == other.m00 && m01 == other.m01 && m02 == other.m02 && m03 == other.m03 && m10 == other.m10 && m11 == other.m11 && m12 == other.m12 && m13 == other.m13 && m20 == other.m20 && m21 == other.m21 && m22 == other.m22 && m23 == other.m23 && m30 == other.m30 && m31 == other.m31 && m32 == other.m32 && m33 == other.m33;

        public override int GetHashCode()
        {
            var h = new HashCode();
            h.Add(m00); h.Add(m01); h.Add(m02); h.Add(m03);
            h.Add(m10); h.Add(m11); h.Add(m12); h.Add(m13);
            h.Add(m20); h.Add(m21); h.Add(m22); h.Add(m23);
            h.Add(m30); h.Add(m31); h.Add(m32); h.Add(m33);
            return h.ToHashCode();
        }
    }
}

