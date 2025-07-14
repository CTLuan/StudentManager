using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManager.Shared.Contants;

namespace StudentManager.Shared.Exceptions
{
    public static class ErrorCatalog
    {
        public static readonly AppException BadRequest = new AppException(
            400,
            //"Yêu cầu không hợp lệ.",
            ErrorCodes.BadRequest,
            ErrorCodes.BadRequest
        );

        public static readonly AppException Unauthorized = new AppException(
            401,
            //"Chưa xác thực.",
            ErrorCodes.Unauthorized,
            ErrorCodes.Unauthorized
        );

        public static readonly AppException Forbidden = new AppException(
            403,
            //"Không có quyền truy cập.",
            ErrorCodes.Forbidden,
            ErrorCodes.Forbidden
        );

        public static readonly AppException NotFound = new AppException(
            404,
            //"Không tìm thấy tài nguyên.",
            ErrorCodes.NotFound,
            ErrorCodes.NotFound
        );

        public static readonly AppException InternalServerError = new AppException(
            500,
            //"Lỗi hệ thống.",
            ErrorCodes.InternalServerError,
            ErrorCodes.InternalServerError
        );

        public static readonly AppException TooManyRequests = new AppException(
            429,
            //"Quá nhiều yêu cầu. Vui lòng thử lại sau.",
            ErrorCodes.TooManyRequests,
            ErrorCodes.TooManyRequests
        );

        public static AppException Custom(int statusCode, string message, string errorCode)
        {
            return new AppException(statusCode, message, errorCode);
        }
    }
}
