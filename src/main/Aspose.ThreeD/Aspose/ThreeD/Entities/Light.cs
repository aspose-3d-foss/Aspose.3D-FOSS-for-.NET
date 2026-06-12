using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// The light illuminates the scene.
    /// The formula to calculate the total attenuation of light is:
    /// A = ConstantAttenuation + (Dist * LinearAttenuation) + ((Dist^2) * QuadraticAttenuation)
    /// </summary>
    public class Light : Frustum, INamedObject, IOrientable
    {
        private LightType _lightType = LightType.Point;
        private Vector3 _color = Vector3.One;
        private double _intensity = 100.0;
        private double _hotSpot = 45.0;
        private double _falloff = 45.0;
        private double _constantAttenuation = 1.0;
        private double _linearAttenuation = 0.0;
        private double _quadraticAttenuation = 0.0;
        private bool _castLight = true;
        private bool _castShadows = false;
        private Vector3 _shadowColor = new Vector3(0, 0, 0);

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Light() : this("Light")
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Light(string name) : this(name, LightType.Point)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Light(string name, LightType type) : base(name)
        {
            _lightType = type;
        }

        /// <summary>
        /// Gets or sets the light's color
        /// </summary>
        public Vector3 Color
        {
            get => _color;
            set => _color = value;
        }

        /// <summary>
        /// Gets or sets the light's type
        /// </summary>
        public LightType LightType
        {
            get => _lightType;
            set => _lightType = value;
        }

        /// <summary>
        /// Gets or sets if the current light instance can illuminate other objects.
        /// </summary>
        public bool CastLight
        {
            get => _castLight;
            set => _castLight = value;
        }

        /// <summary>
        /// Gets or sets the light's intensity, default value is 100
        /// </summary>
        public double Intensity
        {
            get => _intensity;
            set => _intensity = value;
        }

        /// <summary>
        /// Gets or sets the hot spot cone angle(in degrees).
        /// </summary>
        public double HotSpot
        {
            get => _hotSpot;
            set => _hotSpot = value;
        }

        /// <summary>
        /// Gets or sets the falloff cone angle (in degrees).
        /// </summary>
        public double Falloff
        {
            get => _falloff;
            set => _falloff = value;
        }

        /// <summary>
        /// Gets or sets the constant attenuation to calculate the total attenuation of the light
        /// </summary>
        public double ConstantAttenuation
        {
            get => _constantAttenuation;
            set => _constantAttenuation = value;
        }

        /// <summary>
        /// Gets or sets the linear attenuation to calculate the total attenuation of the light
        /// </summary>
        public double LinearAttenuation
        {
            get => _linearAttenuation;
            set => _linearAttenuation = value;
        }

        /// <summary>
        /// Gets or sets the quadratic attenuation to calculate the total attenuation of the light
        /// </summary>
        public double QuadraticAttenuation
        {
            get => _quadraticAttenuation;
            set => _quadraticAttenuation = value;
        }

        /// <summary>
        /// Gets or sets if the light can cast shadows on other objects.
        /// </summary>
        public bool CastShadows
        {
            get => _castShadows;
            set => _castShadows = value;
        }

        /// <summary>
        /// Gets or sets the shadow's color.
        /// </summary>
        public Vector3 ShadowColor
        {
            get => _shadowColor;
            set => _shadowColor = value;
        }
    }
}
