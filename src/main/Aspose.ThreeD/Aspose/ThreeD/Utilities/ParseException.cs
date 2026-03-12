using System;

namespace Aspose.ThreeD.Utilities
{
    public class ParseException : Exception
    {
        public ParseException(string msg) : base(msg)
        {
        }

        protected ParseException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
