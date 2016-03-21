using System;

namespace Calendar
{
    class InvalidTaskException : Exception
    {
        public InvalidTaskException() : base()
        {
        }

        public InvalidTaskException(string msg) : base(msg)
        {
        }
    }
}
