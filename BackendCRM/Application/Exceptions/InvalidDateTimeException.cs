using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidDateTimeException : Exception
    {
        public InvalidDateTimeException() : base("La fecha de finalizacion del proyecto no puede ser anterior a la fecha de inicio.") { }
    }
}
