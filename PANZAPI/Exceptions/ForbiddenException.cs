using System.Runtime.Serialization;

namespace PANZAPI.Exceptions
{
    public class ForbiddenException : Exception
    {
        protected ForbiddenException(SerializationInfo info, StreamingContext context): base(info, context) { }
        public ForbiddenException() { }
        public ForbiddenException(string message) : base(message) { }
        public ForbiddenException(string message, Exception innerException) : base(message, innerException) { }
    }
}
