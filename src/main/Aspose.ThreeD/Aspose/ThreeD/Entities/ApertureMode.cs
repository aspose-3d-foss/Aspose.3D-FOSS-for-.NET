namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Camera aperture modes.
    /// The aperture mode determines which values drive the camera aperture. 
    /// If the aperture mode is HorizAndVert, Horizontal, or Vertical, then the field of view is used. 
    /// If the aperture mode is FocalLength, then the focal length is used.
    /// </summary>
    public enum ApertureMode
    {
        /// <summary>
        /// Horizontal and vertical aperture mode
        /// </summary>
        HorizAndVert,

        /// <summary>
        /// Horizontal aperture mode
        /// </summary>
        Horizontal,

        /// <summary>
        /// Vertical aperture mode
        /// </summary>
        Vertical,

        /// <summary>
        /// Focal length aperture mode
        /// </summary>
        FocalLength,
    }
}
