using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.CCS.Exceptions
{
    public class ValidationExceptions : Exception
    {
        public ValidationExceptions()
        {
        }

        public ValidationExceptions(string? message) : base(message)
        {
        }

        public ValidationExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ValidationExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
