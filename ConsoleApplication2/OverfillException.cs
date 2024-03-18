using System;

namespace ConsoleApplication2
{
    public class OverfillException : Exception 
    {
        public OverfillException(string message) : base(message)
        {
            
        }
    }
}