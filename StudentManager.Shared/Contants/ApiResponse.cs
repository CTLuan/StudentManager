using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Shared.Contants
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; }

        public ApiResponse(int statusCode, string message, T data = default, bool success = true)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Success = success;
        }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Operation Successful", int statusCode = 200)
        {
            return new ApiResponse<T>(statusCode, message, data, true);
        }

        public static ApiResponse<T> ErrorResponse(string message, int statusCode = 400)
        {
            return new ApiResponse<T>(statusCode, message, default, false);
        }
    }
}
