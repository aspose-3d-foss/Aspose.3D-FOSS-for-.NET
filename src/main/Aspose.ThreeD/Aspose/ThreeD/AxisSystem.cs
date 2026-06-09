using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Coordinate system
    /// </summary>
    public enum CoordinateSystem
    {
        /// <summary>
        /// Left-handed coordinate system
        /// </summary>
        LeftHanded,
        /// <summary>
        /// Right-handed coordinate system
        /// </summary>
        RightHanded
    }

    /// <summary>
    /// Axis
    /// </summary>
    public enum Axis
    {
        /// <summary>
        /// X axis
        /// </summary>
        XAxis,
        /// <summary>
        /// Y axis
        /// </summary>
        YAxis,
        /// <summary>
        /// Z axis
        /// </summary>
        ZAxis,
        /// <summary>
        /// Negative X axis
        /// </summary>
        NegativeXAxis,
        /// <summary>
        /// Negative Y axis
        /// </summary>
        NegativeYAxis,
        /// <summary>
        /// Negative Z axis
        /// </summary>
        NegativeZAxis
    }

    /// <summary>
    /// Axis system is an combination of coordinate system, up vector and front vector.
    /// </summary>
    public class AxisSystem
    {
        private readonly CoordinateSystem _coordinateSystem;
        private readonly Axis _up;
        private readonly Axis _front;

        /// <summary>
        /// Constructs a new axis system
        /// </summary>
        public AxisSystem(CoordinateSystem coordinateSystem, Axis up, Axis front)
        {
            _coordinateSystem = coordinateSystem;
            _up = up;
            _front = front;
        }

        /// <summary>
        /// Constructs a new axis system
        /// </summary>
        public AxisSystem(CoordinateSystem coordinateSystem, Axis up)
        {
            _coordinateSystem = coordinateSystem;
            _up = up;
            _front = Axis.ZAxis;
        }

        /// <summary>
        /// Constructs a new axis system
        /// </summary>
        public AxisSystem(Axis up, Axis? front = null)
        {
            _coordinateSystem = CoordinateSystem.RightHanded;
            _up = up;
            _front = front ?? Axis.ZAxis;
        }

        /// <summary>
        /// Constructs a new axis system
        /// </summary>
        public AxisSystem(CoordinateSystem? coordinateSystem = null, Axis? up = null, Axis? front = null)
        {
            _coordinateSystem = coordinateSystem ?? CoordinateSystem.RightHanded;
            _up = up ?? Axis.YAxis;
            _front = front ?? Axis.ZAxis;
        }

        /// <summary>
        /// Gets the coordinate system of this axis system.
        /// </summary>
        public CoordinateSystem CoordinateSystem => _coordinateSystem;

        /// <summary>
        /// Gets the up vector of this axis system.
        /// </summary>
        public Axis Up => _up;

        /// <summary>
        /// Gets the front vector of this axis system
        /// </summary>
        public Axis Front => _front;

        /// <summary>
        /// Create a matrix used to convert from current axis system to target axis system.
        /// </summary>
        public Matrix4 TransformTo(AxisSystem targetSystem)
        {
            return Matrix4.Identity;
        }

        /// <summary>
        /// Create AxisSystem from AssetInfo
        /// </summary>
        public static AxisSystem FromAssetInfo(AssetInfo assetInfo)
        {
            return new AxisSystem();
        }
    }
}
