using System.Runtime.Serialization;

namespace Calculator.Mathematics
{
    internal class BajskorvException : Exception
    {
        public BajskorvException()
        {
        }

        public BajskorvException(string? message) : base(message)
        {
        }

        public BajskorvException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}