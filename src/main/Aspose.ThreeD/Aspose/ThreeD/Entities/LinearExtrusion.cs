using System;
using Aspose.ThreeD.Profiles;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Linear extrusion takes a 2D shape as input and extends the shape in the 3rd dimension.
    /// </summary>
    public class LinearExtrusion : Entity, INamedObject, IMeshConvertible
    {
        private Profile _shape;
        private Vector3 _direction;
        private double _height;
        private int _slices;
        private bool _center;
        private Vector3 _twistOffset;
        private double _twist;

        /// <summary>
        /// Constructor of instance
        /// </summary>
        public LinearExtrusion() : this("LinearExtrusion")
        {
            _shape = null;
            _direction = Vector3.UnitZ;
            _height = 1.0;
            _slices = 1;
            _center = false;
            _twistOffset = Vector3.Zero;
            _twist = 0;
        }

        /// <summary>
        /// Constructor of instance
        /// </summary>
        /// <param name="shape">The base shape to be extruded</param>
        /// <param name="height">The height of the extruded geometry</param>
        public LinearExtrusion(Profile shape, double height) : this("LinearExtrusion")
        {
            _shape = shape;
            _direction = Vector3.UnitZ;
            _height = height;
            _slices = 1;
            _center = false;
            _twistOffset = Vector3.Zero;
            _twist = 0;
        }

        /// <summary>
        /// Constructor of instance
        /// </summary>
        /// <param name="name">Entity name</param>
        protected LinearExtrusion(string name) : base(name)
        {
            _shape = null;
            _direction = Vector3.UnitZ;
            _height = 1.0;
            _slices = 1;
            _center = false;
            _twistOffset = Vector3.Zero;
            _twist = 0;
        }

        /// <summary>
        /// The base shape to be extruded.
        /// </summary>
        public Profile Shape
        {
            get => _shape;
            set => _shape = value;
        }

        /// <summary>
        /// The direction of extrusion, default value is (0, 0, 1)
        /// </summary>
        public Vector3 Direction
        {
            get => _direction;
            set => _direction = value;
        }

        /// <summary>
        /// The height of the extruded geometry, default value is 1.0
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// The slices of the twisted extruded geometry, default value is 1.
        /// </summary>
        public int Slices
        {
            get => _slices;
            set => _slices = value;
        }

        /// <summary>
        /// If this value is false, the linear extrusion Z range is from 0 to height, otherwise the range is from -height/2 to height/2.
        /// </summary>
        public bool Center
        {
            get => _center;
            set => _center = value;
        }

        /// <summary>
        /// The offset that used in twisting, default value is (0, 0, 0).
        /// </summary>
        public Vector3 TwistOffset
        {
            get => _twistOffset;
            set => _twistOffset = value;
        }

        /// <summary>
        /// The number of degrees of through which the shape is extruded.
        /// </summary>
        public double Twist
        {
            get => _twist;
            set => _twist = value;
        }

        /// <summary>
        /// Convert the extrusion to mesh.
        /// </summary>
        public Mesh ToMesh()
        {
            // If no shape is defined, return an empty mesh
            if (_shape == null)
            {
                return new Mesh(Name);
            }

            // Handle common parameterized profiles
            if (_shape is RectangleShape rectShape)
            {
                return CreateRectangleExtrusion(rectShape);
            }
            else if (_shape is CircleShape circleShape)
            {
                return CreateCircleExtrusion(circleShape);
            }
            
            // For other profile types or unsupported profiles, return empty mesh
            return new Mesh(Name);
        }

        /// <summary>
        /// Create extrusion from RectangleShape
        /// </summary>
        private Mesh CreateRectangleExtrusion(RectangleShape rectShape)
        {
            var mesh = new Mesh(Name);
            
            // Get dimensions from the rectangle
            var xDim = rectShape.XDim;
            var yDim = rectShape.YDim;
            var halfWidth = (float)(xDim / 2);
            var halfHeight = (float)(yDim / 2);
            
            // Calculate extrusion direction
            var dir = Direction.Normalize();
            var extrudeHeight = (float)_height;
            
            // Create the two faces of the extrusion
            // Base face (at start)
            var baseOffset = _center ? -extrudeHeight / 2 : 0;
            
            // Calculate perpendicular vectors for the extrusion plane
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
            
            // Generate the four corners of the base rectangle
            var p0 = dir * baseOffset + uDir * -halfWidth + vDir * -halfHeight;
            var p1 = dir * baseOffset + uDir * halfWidth + vDir * -halfHeight;
            var p2 = dir * baseOffset + uDir * halfWidth + vDir * halfHeight;
            var p3 = dir * baseOffset + uDir * -halfWidth + vDir * halfHeight;
            
            // Top face (at end)
            var topOffset = baseOffset + extrudeHeight;
            var p4 = dir * topOffset + uDir * -halfWidth + vDir * -halfHeight;
            var p5 = dir * topOffset + uDir * halfWidth + vDir * -halfHeight;
            var p6 = dir * topOffset + uDir * halfWidth + vDir * halfHeight;
            var p7 = dir * topOffset + uDir * -halfWidth + vDir * halfHeight;
            
            // Add control points
            mesh.ControlPoints.Add(new Vector4((float)p0.X, (float)p0.Y, (float)p0.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p1.X, (float)p1.Y, (float)p1.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p2.X, (float)p2.Y, (float)p2.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p3.X, (float)p3.Y, (float)p3.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p4.X, (float)p4.Y, (float)p4.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p5.X, (float)p5.Y, (float)p5.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p6.X, (float)p6.Y, (float)p6.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p7.X, (float)p7.Y, (float)p7.Z, 1));
            
            // Create faces (quads)
            // Bottom face
            mesh.CreatePolygon(0, 1, 2, 3);
            // Top face
            mesh.CreatePolygon(4, 5, 6, 7);
            // Side faces
            mesh.CreatePolygon(0, 1, 5, 4);
            mesh.CreatePolygon(1, 2, 6, 5);
            mesh.CreatePolygon(2, 3, 7, 6);
            mesh.CreatePolygon(3, 0, 4, 7);
            
            return mesh;
        }
        
        /// <summary>
        /// Create extrusion from CircleShape
        /// </summary>
        private Mesh CreateCircleExtrusion(CircleShape circleShape)
        {
            var mesh = new Mesh(Name);
            
            // For now, create a simple cylinder-like extrusion
            // Get radius from GetExtent
            var extent = circleShape.GetExtent();
            var radius = (float)(extent.X / 2);
            
            // Default to 16 segments for circle approximation
            var segments = 16;
            var angleStep = (Math.PI * 2) / segments;
            
            // Calculate extrusion
            var dir = Direction.Normalize();
            var extrudeHeight = (float)_height;
            var baseOffset = _center ? -extrudeHeight / 2 : 0;
            
            // Create perpendicular vectors
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
            
            // Generate vertices for bottom and top circles
            for (int i = 0; i < 2; i++)
            {
                var zOffset = baseOffset + i * extrudeHeight;
                var pos = dir * zOffset;
                
                for (int s = 0; s < segments; s++)
                {
                    var angle = s * angleStep;
                    var x = (float)(Math.Cos(angle) * radius);
                    var y = (float)(Math.Sin(angle) * radius);
                    
                    var point = pos + uDir * x + vDir * y;
                    mesh.ControlPoints.Add(new Vector4((float)point.X, (float)point.Y, (float)point.Z, 1));
                }
            }
            
            // Create side polygons (quads)
            var bottomStart = 0;
            var topStart = segments;
            for (int s = 0; s < segments; s++)
            {
                var next = (s + 1) % segments;
                
                // Bottom face (if center is true, we might want caps)
                // For now, just create the side surface
                mesh.CreatePolygon(
                    bottomStart + s,
                    bottomStart + next,
                    topStart + next,
                    topStart + s
                );
            }
            
            return mesh;
        }
    }
}
