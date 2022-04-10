using System;
using System.Collections.Generic;
using System.Text;

namespace MainPart.Exceptions
{
    public class ValueIsNullException : Exception
    {
        public ValueIsNullException(string msg) : base(msg)
        {
        }
    }
}
