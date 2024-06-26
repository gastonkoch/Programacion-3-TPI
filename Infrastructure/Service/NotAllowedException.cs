﻿using System.Runtime.Serialization;

namespace Infrastructure.Service
{
    [Serializable]
    internal class NotAllowedException : Exception
    {
        public NotAllowedException()
        {
        }

        public NotAllowedException(string? message) : base(message)
        {
        }

        public NotAllowedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotAllowedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}