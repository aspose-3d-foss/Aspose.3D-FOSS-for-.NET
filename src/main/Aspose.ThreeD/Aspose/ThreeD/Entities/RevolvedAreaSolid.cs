using System;
using Aspose.ThreeD.Profiles;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// This class represents a solid model by revolving a cross section provided by a profile about an axis.
    /// </summary>
    public class RevolvedAreaSolid : Entity, INamedObject, IMeshConvertible
    {
        private Profile _shape;
        private Vector3 _axis;
        private Vector3 _origin;
        private double _angleStart;
        private double _angleEnd;

        /// <summary>
        /// Constructor of RevolvedAreaSolid
        /// </summary>
        public RevolvedAreaSolid() : this("RevolvedAreaSolid")
        {
        }

        /// <summary>
        /// Constructor of RevolvedAreaSolid
        /// </summary>
        /// <param name="name">Entity name</param>
        protected RevolvedAreaSolid(string name) : base(name)
        {
            _shape = null;
            _axis = Vector3.UnitY;
            _origin = Vector3.Zero;
            _angleStart = 0;
            _angleEnd = Math.PI;
        }

        /// <summary>
        /// Gets or sets the starting angle of the revolving procedure, measured in radian, default value is 0.
        /// </summary>
        public double AngleStart
        {
            get => _angleStart;
            set => _angleStart = value;
        }

        /// <summary>
        /// Gets or sets the ending angle of the revolving procedure, measured in radian, default value is pi.
        /// </summary>
        public double AngleEnd
        {
            get => _angleEnd;
            set => _angleEnd = value;
        }

        /// <summary>
        /// Gets or sets the axis direction, default value is (0, 1, 0).
        /// </summary>
        public Vector3 Axis
        {
            get => _axis;
            set => _axis = value;
        }

        /// <summary>
        /// Gets or sets the origin point of the revolving, default value is (0, 0, 0).
        /// </summary>
        public Vector3 Origin
        {
            get => _origin;
            set => _origin = value;
        }

        /// <summary>
        /// Gets or sets the base profile used to revolve.
        /// </summary>
        public Profile Shape
        {
            get => _shape;
            set => _shape = value;
        }

        /// <summary>
        /// Convert the RevolvedAreaSolid into a mesh.
        /// </summary>
        public Mesh ToMesh()
        {
            // If no shape is defined, return an empty mesh
            if (_shape == null)
            {
                return new Mesh(Name);
            }

            // Handle common parameterized profiles
            if (_shape is CircleShape circleShape)
            {
                return CreateCircleRevolution(circleShape);
            }
            else if (_shape is RectangleShape rectShape)
            {
                return CreateRectangleRevolution(rectShape);
            }
            
            // For other profile types or unsupported profiles, return empty mesh
            return new Mesh(Name);
        }

        /// <summary>
        /// Create revolution from CircleShape (like a torus)
        /// </summary>
        private Mesh CreateCircleRevolution(CircleShape circleShape)
        {
            var mesh = new Mesh(Name);
            
            // Get circle radius from GetExtent
            var extent = circleShape.GetExtent();
            var radius = (float)(extent.X / 2);
            
            // Default to 16 segments for circle and 16 for revolution
            var circleSegments = 16;
            var revolveSegments = 16;
            
            var angleStart = (float)_angleStart;
            var angleEnd = (float)_angleEnd;
            var angleRange = angleEnd - angleStart;
            
            var axis = Axis.Normalize();
            
            // Create perpendicular vectors for the revolution plane
            Vector3 uDir, vDir;
            if (Math.Abs(axis.Y) > 0.99f)
            {
                uDir = axis.Cross(Vector3.UnitZ).Normalize();
                vDir = axis.Cross(uDir).Normalize();
            }
            else
            {
                uDir = axis.Cross(Vector3.UnitY).Normalize();
                vDir = axis.Cross(uDir).Normalize();
            }
            
            // Generate vertices for each revolution slice
            for (int r = 0; r <= revolveSegments; r++)
            {
                var angle = angleStart + angleRange * r / revolveSegments;
                var cosAngle = (float)Math.Cos(angle);
                var sinAngle = (float)Math.Sin(angle);
                
                // Create a rotation matrix for this angle
                // The revolution creates circles perpendicular to the axis
                for (int c = 0; c < circleSegments; c++)
                {
                    var circleAngle = (Math.PI * 2 * c) / circleSegments;
                    var circleCos = (float)Math.Cos(circleAngle);
                    var circleSin = (float)Math.Sin(circleAngle);
                    
                    // Position on the circle, offset from the origin by the revolution radius
                    // For a circle profile, the revolution radius is the distance from origin
                    var revolveRadius = radius; // Simplified - actual implementation would use profile geometry
                    
                    // Calculate the point in 3D space
                    var point = _origin + uDir * (revolveRadius + circleCos * radius) + vDir * (sinAngle * revolveRadius);
                    
                    mesh.ControlPoints.Add(new Vector4((float)point.X, (float)point.Y, (float)point.Z, 1));
                }
            }
            
            // Create polygons connecting adjacent slices
            for (int r = 0; r < revolveSegments; r++)
            {
                for (int c = 0; c < circleSegments; c++)
                {
                    var nextR = r + 1;
                    var nextC = (c + 1) % circleSegments;
                    
                    var p0 = r * circleSegments + c;
                    var p1 = r * circleSegments + nextC;
                    var p2 = nextR * circleSegments + nextC;
                    var p3 = nextR * circleSegments + c;
                    
                    mesh.CreatePolygon(p0, p1, p2, p3);
                }
            }
            
            return mesh;
        }
        
        /// <summary>
        /// Create revolution from RectangleShape (like a pipe or rectangular ring)
        /// </summary>
        private Mesh CreateRectangleRevolution(RectangleShape rectShape)
        {
            var mesh = new Mesh(Name);
            
            // Get rectangle dimensions
            var xDim = rectShape.XDim;
            var yDim = rectShape.YDim;
            var halfWidth = (float)(xDim / 2);
            var halfHeight = (float)(yDim / 2);
            
            // Default to 16 segments for revolution
            var segments = 16;
            var angleStart = (float)_angleStart;
            var angleEnd = (float)_angleEnd;
            var angleRange = angleEnd - angleStart;
            
            var axis = Axis.Normalize();
            
            // Create perpendicular vectors
            Vector3 uDir, vDir;
            if (Math.Abs(axis.Y) > 0.99f)
            {
                uDir = axis.Cross(Vector3.UnitZ).Normalize();
                vDir = axis.Cross(uDir).Normalize();
            }
            else
            {
                uDir = axis.Cross(Vector3.UnitY).Normalize();
                vDir = axis.Cross(uDir).Normalize();
            }
            
            // For a rectangular profile, we need to revolve the four corners
            // and create the surfaces between them
            // Simplified: create a rectangular ring
            
            // The revolution radius is the distance from the origin to the rectangle center
            // For now, use half the width as the revolution radius
            var revolveRadius = halfWidth;
            
            // Generate vertices for each revolution slice (4 corners per slice)
            for (int s = 0; s <= segments; s++)
            {
                var angle = angleStart + angleRange * s / segments;
                var cosAngle = (float)Math.Cos(angle);
                var sinAngle = (float)Math.Sin(angle);
                
                // Create rotation matrix for this angle
                // Four corners of the rectangle profile
                // Corners relative to origin: (-halfWidth, -halfHeight), (halfWidth, -halfHeight), 
                //                             (halfWidth, halfHeight), (-halfWidth, halfHeight)
                
                // Apply revolution to each corner
                var corners = new[]
                {
                    new Vector3(-halfWidth, 0, -halfHeight),
                    new Vector3(halfWidth, 0, -halfHeight),
                    new Vector3(halfWidth, 0, halfHeight),
                    new Vector3(-halfWidth, 0, halfHeight)
                };
                
                foreach (var corner in corners)
                {
                    // Revolve the corner around the axis
                    var point = _origin + uDir * (revolveRadius + corner.X) + vDir * (sinAngle * corner.Z);
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
    }
}
