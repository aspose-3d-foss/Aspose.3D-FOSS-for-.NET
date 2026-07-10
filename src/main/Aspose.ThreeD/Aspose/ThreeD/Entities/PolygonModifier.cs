using System;
using System.Collections.Generic;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Render;

namespace Aspose.ThreeD.Entities
{
    public static class PolygonModifier
    {
        public static void Triangulate(Scene scene)
        {
            throw new NotImplementedException();
        }

        public static Mesh Triangulate(Mesh mesh)
        {
            throw new NotImplementedException();
        }

        public static int[][] Triangulate(IList<Vector4> controlPoints, IList<int[]> polygons, bool generateNormals, ref Vector3[] nor_out)
        {
            throw new NotImplementedException();
        }

        public static int[][] Triangulate(IList<Vector4> controlPoints, IList<int[]> polygons)
        {
            throw new NotImplementedException();
        }

        public static int[][] Triangulate(IList<Vector4> controlPoints, int[] polygon)
        {
            throw new NotImplementedException();
        }

        public static int[][] Triangulate(IList<Vector4> controlPoints)
        {
            throw new NotImplementedException();
        }

        public static Mesh MergeMesh(Scene scene)
        {
            throw new NotImplementedException();
        }

        public static Mesh MergeMesh(IList<Node> nodes)
        {
            throw new NotImplementedException();
        }

        public static Mesh MergeMesh(Node node)
        {
            throw new NotImplementedException();
        }

        public static Scene Scale(Scene scene, Vector3 scale)
        {
            throw new NotImplementedException();
        }

        public static void Scale(Node node, Vector3 scale)
        {
            throw new NotImplementedException();
        }

        public static void ApplyTransform(Node node, Matrix4 transform)
        {
            throw new NotImplementedException();
        }

        public static VertexElementNormal GenerateNormal(Mesh mesh)
        {
            throw new NotImplementedException();
        }

        public static VertexElementUV GenerateUV(Mesh mesh, VertexElementNormal normals)
        {
            throw new NotImplementedException();
        }

        public static VertexElementUV GenerateUV(Mesh mesh)
        {
            throw new NotImplementedException();
        }

        public static void SplitMesh(Node node, SplitMeshPolicy policy, bool createChildNodes, bool removeOldMesh)
        {
            throw new NotImplementedException();
        }

        public static void SplitMesh(Scene scene, SplitMeshPolicy policy, bool removeOldMesh)
        {
            throw new NotImplementedException();
        }

        public static Mesh[] SplitMesh(Mesh mesh, SplitMeshPolicy policy)
        {
            throw new NotImplementedException();
        }

        public static void BuildTangentBinormal(Scene scene)
        {
            throw new NotImplementedException();
        }

        public static void BuildTangentBinormal(Mesh mesh)
        {
            throw new NotImplementedException();
        }
    }
}
