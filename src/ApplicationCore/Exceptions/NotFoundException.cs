using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string type, string id) : base($"{type} id {id} is not found.")
        {

        }
    }
}
