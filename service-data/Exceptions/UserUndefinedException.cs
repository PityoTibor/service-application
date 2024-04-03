﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Exceptions
{
    public class UserUndefinedException : Exception
    {
        public string message { get; set; }
        public UserUndefinedException() { }
        public UserUndefinedException(string message)
        {
            this.message = message;
        }
    }
}
