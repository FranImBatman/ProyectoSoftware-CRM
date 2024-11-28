using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException() : base("El Id del usuario no existe.") { }
    }
}
