using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidProjectException : Exception
    {
        public InvalidProjectException() : base("El id del proyecto no existe.") { }
    }
}
