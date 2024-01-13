using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Exceptions
{
    internal class NullReferenceExceptionHandling : ApplicationException
    {
        public NullReferenceExceptionHandling() { }

        public NullReferenceExceptionHandling(string message) : base(message) { }
    }
}
