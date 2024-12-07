using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.MappedExceptions.Specifics
{
    public class InputMappedException : MappedException
    {
        public InputMappedException(string briefPublicMessage, string? details, Exception? originalException) : base(briefPublicMessage, details, originalException)
        {
        }
    }
}
