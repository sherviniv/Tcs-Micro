using System;

namespace Tcs.Common.Domain.Exceptions
{
    public class TcsException : Exception
    {
        public string Code { get; }

        public TcsException()
        {
        }

        public TcsException(string code)
        {
            Code = code;
        }

        public TcsException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public TcsException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public TcsException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public TcsException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}