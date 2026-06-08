using System.IO;

namespace Aspose.ThreeD.Utilities
{
    public sealed class IOExtension
    {
        public static void Write(BinaryWriter writer, Matrix4 mat)
        {
            writer.Write(mat.M11);
            writer.Write(mat.M12);
            writer.Write(mat.M13);
            writer.Write(mat.M14);
            writer.Write(mat.M21);
            writer.Write(mat.M22);
            writer.Write(mat.M23);
            writer.Write(mat.M24);
            writer.Write(mat.M31);
            writer.Write(mat.M32);
            writer.Write(mat.M33);
            writer.Write(mat.M34);
            writer.Write(mat.M41);
            writer.Write(mat.M42);
            writer.Write(mat.M43);
            writer.Write(mat.M44);
        }

        public static void Write(BinaryWriter writer, FMatrix4 mat)
        {
            writer.Write(mat.M00);
            writer.Write(mat.M01);
            writer.Write(mat.M02);
            writer.Write(mat.M03);
            writer.Write(mat.M10);
            writer.Write(mat.M11);
            writer.Write(mat.M12);
            writer.Write(mat.M13);
            writer.Write(mat.M20);
            writer.Write(mat.M21);
            writer.Write(mat.M22);
            writer.Write(mat.M23);
            writer.Write(mat.M30);
            writer.Write(mat.M31);
            writer.Write(mat.M32);
            writer.Write(mat.M33);
        }

        public static void Write(BinaryWriter writer, FVector2 v)
        {
            writer.Write(v.X);
            writer.Write(v.Y);
        }

        public static void Write(BinaryWriter writer, FVector3 v)
        {
            writer.Write(v.X);
            writer.Write(v.Y);
            writer.Write(v.Z);
        }

        public static void Write(BinaryWriter writer, FVector4 v)
        {
            writer.Write(v.X);
            writer.Write(v.Y);
            writer.Write(v.Z);
            writer.Write(v.W);
        }

        public static void Write(BinaryWriter writer, Vector2 v)
        {
            writer.Write((float)v.X);
            writer.Write((float)v.Y);
        }

        public static void Write(BinaryWriter writer, Vector3 v)
        {
            writer.Write((float)v.X);
            writer.Write((float)v.Y);
            writer.Write((float)v.Z);
        }

        public static void Write(BinaryWriter writer, Vector4 v)
        {
            writer.Write((float)v.X);
            writer.Write((float)v.Y);
            writer.Write((float)v.Z);
            writer.Write((float)v.W);
        }
    }
}
