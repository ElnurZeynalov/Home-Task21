using System;
using System.Collections.Generic;
using System.Text;

namespace MainPart.Exceptions
{
    public class MealIsNotFreeException:Exception
    {
        public MealIsNotFreeException(string msg):base(msg)
        {
        }
    }
}
