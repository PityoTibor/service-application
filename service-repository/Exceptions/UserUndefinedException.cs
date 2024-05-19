using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_repository.Exceptions
{
    public class UserUndefinedException : Exception
    {
        public string message { get; set; }
        public string ErrorMessage { get; set; }
        public UserUndefinedException() { }
        public UserUndefinedException(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }
    }
}
