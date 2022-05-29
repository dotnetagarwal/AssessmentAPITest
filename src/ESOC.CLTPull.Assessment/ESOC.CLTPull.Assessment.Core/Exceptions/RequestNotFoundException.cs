using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Exceptions
{
    public class RequestNotFoundException : Exception
    {
        public RequestNotFoundException(int requestid) : base($"No request found with id {requestid}")
        {
        }

        protected RequestNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public RequestNotFoundException(string message) : base(message)
        {
        }

        public RequestNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
