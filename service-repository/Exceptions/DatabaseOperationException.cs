using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Exceptions
{
    public class DatabaseOperationException : Exception
    {
        public string message { get; set; }
        public Exception innerException { get; set; }

        public DatabaseOperationException() { }
        public DatabaseOperationException(string message, Exception innerException)
        {
            this.message = message;
            this.innerException = innerException;    
        }
    }
}
