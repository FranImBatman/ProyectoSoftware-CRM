using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidTaskException : Exception
    {
        public InvalidTaskException() : base("El id de la tarea no existe.") { }
    }
}
