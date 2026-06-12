using System;
using System.Collections.Generic;
using System.IO;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// File format instance for Microsoft 3MF with 3MF related utilities.
    /// </summary>
    public class Microsoft3MFFormat : FileFormat
    {
        public Microsoft3MFFormat() : base(
            "3mf",
            new[] { "3mf" },
            new Version(1, 0),
            true,
            true,
            FileContentType.Binary,
            new FileFormatType("3mf"))
        {
        }

        /// <summary>
        /// Check if this node is marked as a build.
        /// </summary>
        public bool IsBuildable(Node node)
        {
            throw new NotImplementedException("Microsoft 3MF buildable check not implemented in FOSS version");
        }

        /// <summary>
        /// Get transform matrix for node used in build.
        /// </summary>
        public Nullable<Matrix4> GetTransformForBuild(Node node)
        {
            throw new NotImplementedException("Microsoft 3MF transform not implemented in FOSS version");
        }

        public void SetBuildable(Node node, bool value, Nullable<Matrix4> transform)
        {
            throw new NotImplementedException("Microsoft 3MF buildable set not implemented in FOSS version");
        }

        /// <summary>
        /// Set the model type for specified node.
        /// Possible value:
        ///     model
        ///     surface
        ///     solidsupport
        ///     support
        ///     other
        /// </summary>
        public void SetObjectType(Node node, string modelType)
        {
            throw new NotImplementedException("Microsoft 3MF object type not implemented in FOSS version");
        }

        /// <summary>
        /// Gets the model type for specified node.
        /// </summary>
        public string GetObjectType(Node node)
        {
            throw new NotImplementedException("Microsoft 3MF object type not implemented in FOSS version");
        }
    }
}
