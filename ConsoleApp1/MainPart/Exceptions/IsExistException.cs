using System;
using System.Collections.Generic;
using System.Text;

namespace MainPart.Exceptions
{
    public class IsExistException:Exception
    {
        public IsExistException(string msg):base(msg)
        {
        }
    }
}
