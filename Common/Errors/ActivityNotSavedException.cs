using System;

namespace Common.Errors
{
    public class ActivityNotSavedException: Exception
    {
        public ActivityNotSavedException(string message): base(message)
        {
        }
    }
}
