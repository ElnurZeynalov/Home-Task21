using System;
using System.Collections.Generic;
using System.Text;

namespace MainPart.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string msg):base(msg)
        {
        }
    }
}
