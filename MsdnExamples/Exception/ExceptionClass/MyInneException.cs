using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClass
{
    public class MyInneException : Exception
    {

        public MyInneException()
            : base()
            { }

        public MyInneException(string message)
            : base(message)
        {
            Message = message;
        }

        public MyInneException(string message, string value)
            : this(String.Format("{0} is not a valid argument.", value))
        {
            Message = message;
            Value = value;
        }

        public MyInneException(string message, string value, Exception innerException) :
             base(message, innerException)
            {
                Value = value;
            }

        public string Message { get; private set; }
        public string? Value { get; private set; }
    }
}
