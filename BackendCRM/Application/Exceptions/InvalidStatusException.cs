using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidStatusException : Exception
    {
        public InvalidStatusException() : base("El Id del estado seleccionado no existe.") { }
    }
}
