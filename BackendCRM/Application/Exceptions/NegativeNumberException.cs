using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException() : base("No puede ingresarse un numero negativo en la paginacion.") { }
    }
}
