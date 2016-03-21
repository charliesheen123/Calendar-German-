using System;

namespace Calendar
{
    class ExpiredTaskException : Exception
    {
        public ExpiredTaskException() : base()
        {
        }

        public ExpiredTaskException(string msg) : base(msg)
        {
        }
    }
}
