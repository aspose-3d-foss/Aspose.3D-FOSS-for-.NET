using System;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Information of asset.
    /// Asset information can be attached to a Node.
    /// Child Node can have its own AssetInfo to override parent's definition.
    /// </summary>
    public class AssetInfo : A3DObject, INamedObject
    {
        private Nullable<DateTime> _creationTime;
        private Nullable<DateTime> _modificationTime;
        private Nullable<Vector4> _ambient;
        private string _url;
        private string _applicationVendor;
        private string _copyright;
        private string _applicationName;
        private string _applicationVersion;
        private string _title;
        private string _subject;
        private string _author;
        private string _keywords;
        private string _revision;
        private string _comment;
        private string _unitName;
        private double _unitScaleFactor = 1.0;
        private Nullable<CoordinateSystem> _coordinateSystem;
        private Nullable<Axis> _upVector;
        private Nullable<Axis> _frontVector;
        private AxisSystem _axisSystem = new AxisSystem();

        /// <summary>
        /// Initializes a new instance of the AssetInfo class.
        /// </summary>
        public AssetInfo() : base("AssetInfo")
        {
        }

        /// <summary>
        /// Initializes a new instance of the AssetInfo class.
        /// </summary>
        public AssetInfo(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets or Sets the creation time of this asset
        /// </summary>
        public Nullable<DateTime> CreationTime
        {
            get => _creationTime;
            set => _creationTime = value;
        }

        /// <summary>
        /// Gets or Sets the modification time of this asset
        /// </summary>
        public Nullable<DateTime> ModificationTime
        {
            get => _modificationTime;
            set => _modificationTime = value;
        }

        /// <summary>
        /// Gets or Sets the default ambient color of this asset
        /// </summary>
        public Nullable<Vector4> Ambient
        {
            get => _ambient;
            set => _ambient = value;
        }

        /// <summary>
        /// Gets or Sets the URL of this asset.
        /// </summary>
        public string Url
        {
            get => _url;
            set => _url = value;
        }

        /// <summary>
        /// Gets or sets the application vendor's name
        /// </summary>
        public string ApplicationVendor
        {
            get => _applicationVendor;
            set => _applicationVendor = value;
        }

        /// <summary>
        /// Gets or sets the document's copyright
        /// </summary>
        public string Copyright
        {
            get => _copyright;
            set => _copyright = value;
        }

        /// <summary>
        /// Gets or sets the application that created this asset
        /// </summary>
        public string ApplicationName
        {
            get => _applicationName;
            set => _applicationName = value;
        }

        /// <summary>
        /// Gets or sets the version of the application that created this asset.
        /// </summary>
        public string ApplicationVersion
        {
            get => _applicationVersion;
            set => _applicationVersion = value;
        }

        /// <summary>
        /// Gets or sets the title of this asset
        /// </summary>
        public string Title
        {
            get => _title;
            set => _title = value;
        }

        /// <summary>
        /// Gets or sets the subject of this asset
        /// </summary>
        public string Subject
        {
            get => _subject;
            set => _subject = value;
        }

        /// <summary>
        /// Gets or sets the author of this asset
        /// </summary>
        public string Author
        {
            get => _author;
            set => _author = value;
        }

        /// <summary>
        /// Gets or sets the keywords of this asset
        /// </summary>
        public string Keywords
        {
            get => _keywords;
            set => _keywords = value;
        }

        /// <summary>
        /// Gets or sets the revision number of this asset, usually used in version control system.
        /// </summary>
        public string Revision
        {
            get => _revision;
            set => _revision = value;
        }

        /// <summary>
        /// Gets or sets the comment of this asset.
        /// </summary>
        public string Comment
        {
            get => _comment;
            set => _comment = value;
        }

        /// <summary>
        /// Gets or sets the unit of length used in this asset.
        /// e.g. cm/m/km/inch/feet
        /// </summary>
        public string UnitName
        {
            get => _unitName;
            set => _unitName = value;
        }

        /// <summary>
        /// Gets or sets the scale factor to real-world meter.
        /// </summary>
        public double UnitScaleFactor
        {
            get => _unitScaleFactor;
            set => _unitScaleFactor = value;
        }

        /// <summary>
        /// Gets or sets the coordinate system used in this asset.
        /// </summary>
        public Nullable<CoordinateSystem> CoordinateSystem
        {
            get => _coordinateSystem;
            set => _coordinateSystem = value;
        }

        /// <summary>
        /// Gets or sets the up-vector used in this asset.
        /// </summary>
        public Nullable<Axis> UpVector
        {
            get => _upVector;
            set => _upVector = value;
        }

        /// <summary>
        /// Gets or sets the front-vector used in this asset.
        /// </summary>
        public Nullable<Axis> FrontVector
        {
            get => _frontVector;
            set => _frontVector = value;
        }

        /// <summary>
        /// Gets or sets the coordinate system/up vector/front vector of the asset info.
        /// </summary>
        public AxisSystem AxisSystem
        {
            get => _axisSystem;
            set => _axisSystem = value;
        }
    }
}
