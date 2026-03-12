using System;

namespace Aspose.ThreeD.Utilities
{
    public struct FMatrix4 : IEquatable<FMatrix4>
    {
        public float M00, M01, M02, M03;
        public float M10, M11, M12, M13;
        public float M20, M21, M22, M23;
        public float M30, M31, M32, M33;

        public FMatrix4(
            float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23,
            float m30, float m31, float m32, float m33)
        {
            M00 = m00; M01 = m01; M02 = m02; M03 = m03;
            M10 = m10; M11 = m11; M12 = m12; M13 = m13;
            M20 = m20; M21 = m21; M22 = m22; M23 = m23;
            M30 = m30; M31 = m31; M32 = m32; M33 = m33;
        }

        public FMatrix4(Matrix4 mat)
        {
            M00 = mat.M11; M01 = mat.M12; M02 = mat.M13; M03 = mat.M14;
            M10 = mat.M21; M11 = mat.M22; M12 = mat.M23; M13 = mat.M24;
            M20 = mat.M31; M21 = mat.M32; M22 = mat.M33; M23 = mat.M34;
            M30 = mat.M41; M31 = mat.M42; M32 = mat.M43; M33 = mat.M44;
        }

        public FMatrix4(FVector4 r0, FVector4 r1, FVector4 r2, FVector4 r3)
        {
            M00 = r0.X; M01 = r0.Y; M02 = r0.Z; M03 = r0.W;
            M10 = r1.X; M11 = r1.Y; M12 = r1.Z; M13 = r1.W;
            M20 = r2.X; M21 = r2.Y; M22 = r2.Z; M23 = r2.W;
            M30 = r3.X; M31 = r3.Y; M32 = r3.Z; M33 = r3.W;
        }

        public static FMatrix4 Identity => new FMatrix4(
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
        );

        public FMatrix4 Concatenate(FMatrix4 m2)
        {
            return this * m2;
        }

        public FMatrix4 Concatenate(Matrix4 m2)
        {
            return this * new FMatrix4(m2);
        }

        public FMatrix4 Transpose()
        {
            return new FMatrix4(
                M00, M10, M20, M30,
                M01, M11, M21, M31,
                M02, M12, M22, M32,
                M03, M13, M23, M33
            );
        }

        public FMatrix4 Inverse()
        {
            float det = Determinant();
            if (det == 0)
                throw new InvalidOperationException("Matrix is not invertible");

            float invDet = 1.0f / det;
            FMatrix4 result;

            result.M00 = (M11 * (M22 * M33 - M23 * M32) - M12 * (M21 * M33 - M23 * M31) + M13 * (M21 * M32 - M22 * M31)) * invDet;
            result.M01 = (M02 * (M21 * M33 - M23 * M31) - M01 * (M22 * M33 - M23 * M32) + M03 * (M22 * M31 - M21 * M32)) * invDet;
            result.M02 = (M01 * (M12 * M33 - M13 * M32) - M02 * (M11 * M33 - M13 * M31) + M03 * (M11 * M32 - M12 * M31)) * invDet;
            result.M03 = (M02 * (M11 * M23 - M13 * M21) - M01 * (M12 * M23 - M13 * M22) + M03 * (M12 * M21 - M11 * M22)) * invDet;
            result.M10 = (M12 * (M20 * M33 - M23 * M30) - M10 * (M22 * M33 - M23 * M32) + M13 * (M22 * M30 - M20 * M32)) * invDet;
            result.M11 = (M00 * (M22 * M33 - M23 * M32) - M02 * (M20 * M33 - M23 * M30) + M03 * (M20 * M32 - M22 * M30)) * invDet;
            result.M12 = (M02 * (M10 * M33 - M13 * M30) - M00 * (M12 * M33 - M13 * M32) + M03 * (M12 * M30 - M10 * M32)) * invDet;
            result.M13 = (M00 * (M12 * M23 - M13 * M22) - M02 * (M10 * M23 - M13 * M20) + M03 * (M10 * M22 - M12 * M20)) * invDet;
            result.M20 = (M10 * (M21 * M33 - M23 * M31) - M11 * (M20 * M33 - M23 * M30) + M13 * (M20 * M31 - M21 * M30)) * invDet;
            result.M21 = (M01 * (M20 * M33 - M23 * M30) - M00 * (M21 * M33 - M23 * M31) + M03 * (M21 * M30 - M20 * M31)) * invDet;
            result.M22 = (M00 * (M11 * M33 - M13 * M31) - M01 * (M10 * M33 - M13 * M30) + M03 * (M10 * M31 - M11 * M30)) * invDet;
            result.M23 = (M01 * (M10 * M23 - M13 * M20) - M00 * (M11 * M23 - M13 * M21) + M03 * (M11 * M20 - M10 * M21)) * invDet;
            result.M30 = (M11 * (M20 * M32 - M22 * M30) - M10 * (M21 * M32 - M22 * M31) + M12 * (M21 * M30 - M20 * M31)) * invDet;
            result.M31 = (M00 * (M21 * M32 - M22 * M31) - M01 * (M20 * M32 - M22 * M30) + M02 * (M20 * M31 - M21 * M30)) * invDet;
            result.M32 = (M01 * (M10 * M32 - M12 * M30) - M00 * (M11 * M32 - M12 * M31) + M02 * (M11 * M30 - M10 * M31)) * invDet;
            result.M33 = (M00 * (M11 * M22 - M12 * M21) - M01 * (M10 * M22 - M12 * M20) + M02 * (M10 * M21 - M11 * M20)) * invDet;

            return result;
        }

        private float Determinant()
        {
            return
                M00 * (M11 * (M22 * M33 - M23 * M32) - M12 * (M21 * M33 - M23 * M31) + M13 * (M21 * M32 - M22 * M31)) -
                M01 * (M10 * (M22 * M33 - M23 * M32) - M12 * (M20 * M33 - M23 * M30) + M13 * (M20 * M32 - M22 * M30)) +
                M02 * (M10 * (M21 * M33 - M23 * M31) - M11 * (M20 * M33 - M23 * M30) + M13 * (M20 * M31 - M21 * M30)) -
                M03 * (M10 * (M21 * M32 - M22 * M31) - M11 * (M20 * M32 - M22 * M30) + M12 * (M20 * M31 - M21 * M30));
        }

        public static FMatrix4 operator *(FMatrix4 left, FMatrix4 right)
        {
            return new FMatrix4(
                left.M00 * right.M00 + left.M01 * right.M10 + left.M02 * right.M20 + left.M03 * right.M30,
                left.M00 * right.M01 + left.M01 * right.M11 + left.M02 * right.M21 + left.M03 * right.M31,
                left.M00 * right.M02 + left.M01 * right.M12 + left.M02 * right.M22 + left.M03 * right.M32,
                left.M00 * right.M03 + left.M01 * right.M13 + left.M02 * right.M23 + left.M03 * right.M33,
                left.M10 * right.M00 + left.M11 * right.M10 + left.M12 * right.M20 + left.M13 * right.M30,
                left.M10 * right.M01 + left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31,
                left.M10 * right.M02 + left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32,
                left.M10 * right.M03 + left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33,
                left.M20 * right.M00 + left.M21 * right.M10 + left.M22 * right.M20 + left.M23 * right.M30,
                left.M20 * right.M01 + left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31,
                left.M20 * right.M02 + left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32,
                left.M20 * right.M03 + left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33,
                left.M30 * right.M00 + left.M31 * right.M10 + left.M32 * right.M20 + left.M33 * right.M30,
                left.M30 * right.M01 + left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31,
                left.M30 * right.M02 + left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32,
                left.M30 * right.M03 + left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33
            );
        }

        public static FMatrix4 operator *(FMatrix4 lhs, float v)
        {
            return new FMatrix4(
                lhs.M00 * v, lhs.M01 * v, lhs.M02 * v, lhs.M03 * v,
                lhs.M10 * v, lhs.M11 * v, lhs.M12 * v, lhs.M13 * v,
                lhs.M20 * v, lhs.M21 * v, lhs.M22 * v, lhs.M23 * v,
                lhs.M30 * v, lhs.M31 * v, lhs.M32 * v, lhs.M33 * v
            );
        }

        public static FVector3 operator *(FMatrix4 lhs, FVector3 v)
        {
            float x = lhs.M00 * v.X + lhs.M01 * v.Y + lhs.M02 * v.Z + lhs.M03;
            float y = lhs.M10 * v.X + lhs.M11 * v.Y + lhs.M12 * v.Z + lhs.M13;
            float z = lhs.M20 * v.X + lhs.M21 * v.Y + lhs.M22 * v.Z + lhs.M23;
            float w = lhs.M30 * v.X + lhs.M31 * v.Y + lhs.M32 * v.Z + lhs.M33;

            if (w != 0)
            {
                x /= w;
                y /= w;
                z /= w;
            }

            return new FVector3(x, y, z);
        }

        public bool Equals(FMatrix4 other)
        {
            return M00 == other.M00 && M01 == other.M01 && M02 == other.M02 && M03 == other.M03 &&
                   M10 == other.M10 && M11 == other.M11 && M12 == other.M12 && M13 == other.M13 &&
                   M20 == other.M20 && M21 == other.M21 && M22 == other.M22 && M23 == other.M23 &&
                   M30 == other.M30 && M31 == other.M31 && M32 == other.M32 && M33 == other.M33;
        }

        public override bool Equals(object? obj)
        {
            return obj is FMatrix4 other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(M00); hash.Add(M01); hash.Add(M02); hash.Add(M03);
            hash.Add(M10); hash.Add(M11); hash.Add(M12); hash.Add(M13);
            hash.Add(M20); hash.Add(M21); hash.Add(M22); hash.Add(M23);
            hash.Add(M30); hash.Add(M31); hash.Add(M32); hash.Add(M33);
            return hash.ToHashCode();
        }
    }
}
