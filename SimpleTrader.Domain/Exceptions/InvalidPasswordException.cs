using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public InvalidPasswordException(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public InvalidPasswordException(string username, string password, string message) : base(message)
        {
            Username = username;
            Password = password;
        }

        public InvalidPasswordException(string username, string password, string message, Exception innerException) : base(message, innerException)
        {
            Username = username;
            Password = password;
        }
    }
}
