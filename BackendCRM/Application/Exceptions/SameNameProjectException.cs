using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class SameNameProjectException : Exception
    {
        public SameNameProjectException() : base("Ya existe un proyecto con ese nombre.") { }
    }
}
