using System;

namespace Aspose.ThreeD
{
    /// <summary>
    /// License management class (not available in FOSS version)
    /// </summary>
    public class License
    {
        /// <summary>
        /// Initializes a new instance of the License class
        /// </summary>
        public License()
        {
        }

        /// <summary>
        /// Sets the license (not available in FOSS version)
        /// </summary>
        public void SetLicense(string licenseName)
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }

        /// <summary>
        /// Sets the license from a stream (not available in FOSS version)
        /// </summary>
        public void SetLicense(System.IO.Stream stream)
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }
    }

    /// <summary>
    /// Metered license management class (not available in FOSS version)
    /// </summary>
    public class Metered
    {
        /// <summary>
        /// Initializes a new instance of the Metered class
        /// </summary>
        public Metered()
        {
        }

        /// <summary>
        /// Sets metered public and private key (not available in FOSS version)
        /// </summary>
        public void SetMeteredKey(string publicKey, string privateKey)
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }

        /// <summary>
        /// Gets consumed credit quantity (not available in FOSS version)
        /// </summary>
        public static decimal GetConsumptionCredit()
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }

        /// <summary>
        /// Gets consumption quantity (not available in FOSS version)
        /// </summary>
        public static decimal GetConsumptionQuantity()
        {
            throw new NotImplementedException(
                "This feature is not available in the FOSS version. " +
                "Consider using Aspose.3D's commercial On-Premise API for full functionality.");
        }

        /// <summary>
        /// Check whether metered is licensed
        /// </summary>
        public static bool IsMeteredLicensed()
        {
            return false;
        }
    }

    /// <summary>
    /// Trial exception
    /// </summary>
    public class TrialException : System.Exception
    {
        /// <summary>
        /// Sets this to true to suppress trial exception for unlicensed usage, but the restrictions will not be lifted.
        /// In order to lift the restrictions, please use a proper license.
        /// And sets this to true also means you're aware of the unlicensed restrictions.
        /// </summary>
        public static bool SuppressTrialException { get; set; }

        /// <summary>
        /// Constructor of
        /// </summary>
        public TrialException() : base()
        {
        }

        /// <summary>
        /// Constructor of
        /// </summary>
        public TrialException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Import exception
    /// </summary>
    public class ImportException : System.IO.IOException
    {
        /// <summary>
        /// Initializes a new instance of the ImportException class
        /// </summary>
        internal ImportException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ImportException class
        /// </summary>
        public ImportException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ImportException class
        /// </summary>
        internal ImportException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Export exception
    /// </summary>
    public class ExportException : System.IO.IOException, System.Runtime.Serialization.ISerializable
    {
        /// <summary>
        /// Initializes a new instance
        /// </summary>
        public ExportException(string msg) : base(msg)
        {
        }
    }
}
