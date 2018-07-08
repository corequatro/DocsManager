// //ServiceException.cs
// // Copyright (c) 2018 06 30All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;

namespace DocsManager.Domain.Verification
{
    public class ServiceException : AggregateException
    {
        public ServiceException()
        {
        }

        public ServiceException(string message)
            : base(message)
        {
        }

        public ServiceException(string property, string message)
            : base(message)
        {
            Property = property;
        }

        public ServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        
        public string Property { get; private set; }
    }
}