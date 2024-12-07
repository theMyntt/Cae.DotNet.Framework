using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.MappedExceptions.Specifics
{
    internal class NotFoundMappedException : MappedException
    {
        public NotFoundMappedException(string briefPublicMessage, string? details, Exception? originalException) : base(briefPublicMessage, details, originalException)
        {
        }
    }
}
