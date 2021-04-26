using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbpVnextPro.GUI.Domain.Exceptions
{
    public class ZipException : Exception
    {
        public ZipException()
        {
        }

        public ZipException(string message) : base(message)
        {
        }

        public ZipException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZipException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
