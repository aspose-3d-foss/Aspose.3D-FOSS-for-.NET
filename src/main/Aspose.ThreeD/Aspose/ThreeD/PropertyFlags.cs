using System;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Property flags
    /// </summary>
    [Flags]
    public enum PropertyFlags
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// The property is hidden
        /// </summary>
        Hidden = 1,

        /// <summary>
        /// The property is read-only
        /// </summary>
        ReadOnly = 2,

        /// <summary>
        /// The property is required
        /// </summary>
        Required = 4,

        /// <summary>
        /// The property is user data
        /// </summary>
        UserData = 8
    }
}
