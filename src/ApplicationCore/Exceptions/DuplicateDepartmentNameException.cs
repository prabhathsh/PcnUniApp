using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Exceptions
{
    public class DuplicateDepartmentNameException : Exception
    {
        public DuplicateDepartmentNameException(string message) : base(message)
        {

        }
    }
}
