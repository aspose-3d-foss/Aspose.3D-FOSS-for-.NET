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
    }

    /// <summary>
    /// Trial exception
    /// </summary>
    public class TrialException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the TrialException class
        /// </summary>
        public TrialException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the TrialException class
        /// </summary>
        public TrialException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TrialException class
        /// </summary>
        public TrialException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Import exception
    /// </summary>
    public class ImportException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the ImportException class
        /// </summary>
        public ImportException() : base()
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
        public ImportException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Export exception
    /// </summary>
    public class ExportException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the ExportException class
        /// </summary>
        public ExportException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ExportException class
        /// </summary>
        public ExportException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ExportException class
        /// </summary>
        public ExportException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
