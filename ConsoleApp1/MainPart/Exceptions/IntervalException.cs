using System;
using System.Collections.Generic;
using System.Text;

namespace MainPart.Exceptions
{
    public class IntervalException:Exception
    {
        public IntervalException(string msg):base(msg)
        {
        }
    }
}
