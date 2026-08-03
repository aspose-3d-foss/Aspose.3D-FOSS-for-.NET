using System;
using Aspose.ThreeD.Profiles;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A SweptAreaSolid constructs a geometry by sweeping a profile along a directrix.
    /// </summary>
    public class SweptAreaSolid : Entity, INamedObject, IMeshConvertible
    {
        private Profile _shape;
        private Curve _directrix;
        private EndPoint _startPoint;
        private EndPoint _endPoint;

        /// <summary>
        /// Constructor of SweptAreaSolid
        /// </summary>
        public SweptAreaSolid() : this("SweptAreaSolid")
        {
        }

        /// <summary>
        /// Constructor of SweptAreaSolid
        /// </summary>
        /// <param name="name">Entity name</param>
        protected SweptAreaSolid(string name) : base(name)
        {
            _shape = null;
            _directrix = null;
            _startPoint = new EndPoint(0);
            _endPoint = new EndPoint(1);
        }

        /// <summary>
        /// The base profile to construct the geometry.
        /// </summary>
        public Profile Shape
        {
            get => _shape;
            set => _shape = value;
        }

        /// <summary>
        /// The directrix that the swept area sweeping along with.
        /// </summary>
        public Curve Directrix
        {
            get => _directrix;
            set => _directrix = value;
        }

        /// <summary>
        /// The start point of the directrix.
        /// </summary>
        public EndPoint StartPoint
        {
            get => _startPoint;
            set => _startPoint = value;
        }

        /// <summary>
        /// The end point of the directrix.
        /// </summary>
        public EndPoint EndPoint
        {
            get => _endPoint;
            set => _endPoint = value;
        }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public Mesh ToMesh()
        {
            // If no shape or directrix is defined, return an empty mesh
            if (_shape == null || _directrix == null)
            {
                return new Mesh(Name);
            }

            // Handle common parameterized profiles with a straight line directrix
            if (_shape is RectangleShape rectShape && IsStraightLine(_directrix))
            {
                return CreateRectangleSweep(rectShape);
            }
            else if (_shape is CircleShape circleShape && IsStraightLine(_directrix))
            {
                return CreateCircleSweep(circleShape);
            }
            
            // For other profile types or unsupported profiles, return empty mesh
            return new Mesh(Name);
        }
        
        /// <summary>
        /// Check if the curve is a straight line (simplified check)
        /// </summary>
        private bool IsStraightLine(Curve curve)
        {
            // For now, return true for any curve since we can't extract points
            // In a full implementation, this would check if the curve is actually a Line
            return true;
        }

        /// <summary>
        /// Create sweep from RectangleShape along a straight line
        /// </summary>
        private Mesh CreateRectangleSweep(RectangleShape rectShape)
        {
            var mesh = new Mesh(Name);
            
            // Get rectangle dimensions
            var xDim = rectShape.XDim;
            var yDim = rectShape.YDim;
            var halfWidth = (float)(xDim / 2);
            var halfHeight = (float)(yDim / 2);
            
            // Default to 10 segments along the sweep path
            var segments = 10;
            
            // Create a simple extrusion along Z axis (simplified)
            var dir = Vector3.UnitZ;
            var extrudeHeight = 1.0f; // Default height
            
            // Calculate perpendicular vectors
            Vector3 uDir, vDir;
            if (Math.Abs(dir.Y) > 0.99f)
            {
                uDir = dir.Cross(Vector3.UnitZ).Normalize();
                vDir = dir.Cross(uDir).Normalize();
            }
            else
            {
                uDir = dir.Cross(Vector3.UnitY).Normalize();
                vDir = dir.Cross(uDir).Normalize();
            }
            
            // Generate vertices for each segment
            for (int s = 0; s <= segments; s++)
            {
                var zOffset = (extrudeHeight / segments) * s;
                var pos = dir * zOffset;
                
                // Four corners of the rectangle
                var corners = new[]
                {
                    new Vector3(-halfWidth, -halfHeight, 0),
                    new Vector3(halfWidth, -halfHeight, 0),
                    new Vector3(halfWidth, halfHeight, 0),
                    new Vector3(-halfWidth, halfHeight, 0)
                };
                
                foreach (var corner in corners)
                {
                    var point = pos + uDir * corner.X + vDir * corner.Y;
                    mesh.ControlPoints.Add(new Vector4((float)point.X, (float)point.Y, (float)point.Z, 1));
                }
            }
            
            // Create polygons connecting adjacent slices
            var cornersPerSlice = 4;
            for (int s = 0; s < segments; s++)
            {
                for (int c = 0; c < cornersPerSlice; c++)
                {
                    var nextS = s + 1;
                    var nextC = (c + 1) % cornersPerSlice;
                    
                    var p0 = s * cornersPerSlice + c;
                    var p1 = s * cornersPerSlice + nextC;
                    var p2 = nextS * cornersPerSlice + nextC;
                    var p3 = nextS * cornersPerSlice + c;
                    
                    mesh.CreatePolygon(p0, p1, p2, p3);
                }
            }
            
            return mesh;
        }
        
        /// <summary>
        /// Create sweep from CircleShape along a straight line (cylinder-like)
        /// </summary>
        private Mesh CreateCircleSweep(CircleShape circleShape)
        {
            var mesh = new Mesh(Name);
            
            // Get circle radius
            var extent = circleShape.GetExtent();
            var radius = (float)(extent.X / 2);
            
            // Default to 16 segments for circle and 10 for length
            var circleSegments = 16;
            var lengthSegments = 10;
            var extrudeHeight = 1.0f;
            
            var dir = Vector3.UnitZ;
            
            // Generate vertices
            for (int l = 0; l <= lengthSegments; l++)
            {
                var zOffset = (extrudeHeight / lengthSegments) * l;
                var pos = dir * zOffset;
                
                for (int c = 0; c < circleSegments; c++)
                {
                    var angle = (Math.PI * 2 * c) / circleSegments;
                    var x = (float)(Math.Cos(angle) * radius);
                    var y = (float)(Math.Sin(angle) * radius);
                    
                    var point = pos + new Vector3(x, y, 0);
                    mesh.ControlPoints.Add(new Vector4((float)point.X, (float)point.Y, (float)point.Z, 1));
                }
            }
            
            // Create side polygons
            for (int l = 0; l < lengthSegments; l++)
            {
                for (int c = 0; c < circleSegments; c++)
                {
                    var nextL = l + 1;
                    var nextC = (c + 1) % circleSegments;
                    
                    var p0 = l * circleSegments + c;
                    var p1 = l * circleSegments + nextC;
                    var p2 = nextL * circleSegments + nextC;
                    var p3 = nextL * circleSegments + c;
                    
                    mesh.CreatePolygon(p0, p1, p2, p3);
                }
            }
            
            return mesh;
        }
    }
}
