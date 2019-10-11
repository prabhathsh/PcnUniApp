using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Exceptions
{
    public class DuplicateCourseCodeException : Exception
    {
        public DuplicateCourseCodeException(string message) : base(message)
        {

        }
    }
}
