using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EmptyFieldException : Exception
    {
        public EmptyFieldException(string fieldName)
        : base(GenerateMessage(fieldName)) { }

        private static string GenerateMessage(string fieldName)
        {       
            return $"El campo '{fieldName}' no puede estar vacío.";
        }
    }
}
