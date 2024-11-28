using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidClientException : Exception
    {
        public InvalidClientException() : base ("El Id del cliente no existe.") { }
    }
}
