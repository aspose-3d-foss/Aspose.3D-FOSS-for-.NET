using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Parameterized dish.
    /// </summary>
    public class Dish : Primitive, INamedObject, IMeshConvertible
    {
        private double _radius;
        private double _height;
        private int _widthSegments;
        private int _heightSegments;

        /// <summary>
        /// Create a new dish instance with default radius(10) and default height(5)
        /// </summary>
        public Dish() : this("Dish", 10, 5, 32, 16)
        {
        }

        /// <summary>
        /// Create a new dish instance with specified radius and height
        /// </summary>
        /// <param name="radius">Radius of the dish</param>
        /// <param name="height">Height of the dish</param>
        public Dish(double radius, double height) : this("Dish", radius, height, 32, 16)
        {
        }

        /// <summary>
        /// Create a new dish instance with specified radius and height
        /// </summary>
        /// <param name="name">Name of the dish</param>
        /// <param name="radius">Radius of the dish</param>
        /// <param name="height">Height of the dish</param>
        /// <param name="widthSegments">Width segments</param>
        /// <param name="heightSegments">Height segments</param>
        public Dish(string name, double radius, double height, int widthSegments, int heightSegments) : base(name)
        {
            _radius = radius;
            _height = height;
            _widthSegments = widthSegments;
            _heightSegments = heightSegments;
        }

        /// <summary>
        /// Radius of the dish
        /// </summary>
        public double Radius
        {
            get => _radius;
            set => _radius = value;
        }

        /// <summary>
        /// Height of the dish
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// Gets or sets the width segments
        /// </summary>
        public int WidthSegments
        {
            get => _widthSegments;
            set => _widthSegments = value;
        }

        /// <summary>
        /// Gets or sets the height segments
        /// </summary>
        public int HeightSegments
        {
            get => _heightSegments;
            set => _heightSegments = value;
        }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public override Mesh ToMesh()
        {
            var mesh = new Mesh(Name);
            var radius = (float)_radius;
            var height = (float)_height;

            // Calculate the angle for the spherical cap
            // The dish height is the sagitta (depth) of the spherical cap
            // We need to calculate the radius of the base and the sphere angle
            // Using the formula: r_base^2 = 2 * R * h - h^2 where r_base is the base radius
            var baseRadius = (float)Math.Sqrt(2 * _radius * _height - _height * _height);

            // We'll generate vertices for the dome surface
            // The dish starts from the base (z = -height/2) to the top (z = height/2)
            // Actually, for a dish, height is typically the sagitta from base to top
            // So vertices go from z=0 (base) to z=height (top)

            for (int lat = 0; lat <= _heightSegments; lat++)
            {
                // Calculate the angle from the top of the sphere
                // lat=0 is at the top (z=height), lat=_heightSegments is at the base (z=0)
                var t = (double)lat / _heightSegments;
                
                // Calculate the z coordinate from the top
                var z = height * t;

                // Calculate the radius at this height
                // Using sphere equation: r^2 + (R - z)^2 = R^2
                // r^2 = R^2 - (R - z)^2 = 2*R*z - z^2
                var r = (float)Math.Sqrt(2 * _radius * z - z * z);

                for (int lon = 0; lon <= _widthSegments; lon++)
                {
                    var angle = 2 * Math.PI * lon / _widthSegments;
                    var x = r * (float)Math.Cos(angle);
                    var y = r * (float)Math.Sin(angle);

                    mesh.ControlPoints.Add(new Vector4(x, y, z, 1));
                }
            }

            // Create polygons connecting the vertices
            for (int lat = 0; lat < _heightSegments; lat++)
            {
                for (int lon = 0; lon < _widthSegments; lon++)
                {
                    var first = lat * (_widthSegments + 1) + lon;
                    var second = first + _widthSegments + 1;

                    mesh.CreatePolygon(first, second, second + 1, first + 1);
                }
            }

            return mesh;
        }
    }
}
