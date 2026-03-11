using System;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// The bounding box of the entity
    /// </summary>
    public class BoundingBox
    {
        private FVector3 _minimum;
        private FVector3 _maximum;

        /// <summary>
        /// Initializes a new instance of the BoundingBox class
        /// </summary>
        public BoundingBox()
        {
            _minimum = FVector3.Zero;
            _maximum = FVector3.Zero;
        }

        /// <summary>
        /// Initializes a new instance of the BoundingBox class
        /// </summary>
        public BoundingBox(FVector3 minimum, FVector3 maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
        }

        /// <summary>
        /// Gets or sets the minimum corner of the bounding box
        /// </summary>
        public FVector3 Minimum
        {
            get => _minimum;
            set => _minimum = value;
        }

        /// <summary>
        /// Gets or sets the maximum corner of the bounding box
        /// </summary>
        public FVector3 Maximum
        {
            get => _maximum;
            set => _maximum = value;
        }
    }
}
