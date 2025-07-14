using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Shared.Exceptions
{
    public class AppException : Exception
    {
        public int StatusCode { get; }
        public string? ErrorCode { get; }

        public AppException(int statusCode, string message, string? errorCode = null)
            : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }
    }
}
