using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbpVnextPro.GUI.Domain.Exceptions
{
    public class GenerateTemplateException : Exception
    {
        public GenerateTemplateException()
        {
        }

        public GenerateTemplateException(string message) : base(message)
        {
        }

        public GenerateTemplateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GenerateTemplateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
