using System;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Lion.CodeGenerator.EntityFrameworkCore.BusinessLines
{
    public class BusinessLineDomainException : UserFriendlyException
    {
        public BusinessLineDomainException(string message, string code = null, string details = null,
             Exception innerException = null, LogLevel logLevel = LogLevel.Warning) : base(message, code, details,
             innerException, logLevel)
        {
        }

        public BusinessLineDomainException(SerializationInfo serializationInfo, StreamingContext context) : base(
            serializationInfo, context)
        {
        }
    }
}
