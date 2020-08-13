using System;

namespace FitoGraph.Api.Infrastructure
{
    public class FitoException : Exception
    {
        public FitoException()
        {
        }

        public FitoException(string message)
            : base(message)
        {
        }

        public FitoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}