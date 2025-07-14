using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Shared.Contants
{
    public static class ErrorCodes
    {
        public const string BadRequest = "ERR_BAD_REQUEST";                     // Yêu cầu không hợp lệ (400)
        public const string Unauthorized = "ERR_UNAUTHORIZED";                 // Chưa xác thực (401)
        public const string Forbidden = "ERR_FORBIDDEN";                       // Không có quyền truy cập (403)
        public const string NotFound = "ERR_NOT_FOUND";                        // Không tìm thấy tài nguyên (404)
        public const string Conflict = "ERR_CONFLICT";                         // Xung đột dữ liệu (409)
        public const string UnprocessableEntity = "ERR_UNPROCESSABLE";        // Dữ liệu không thể xử lý (422)
        public const string InternalServerError = "ERR_INTERNAL_SERVER";      // Lỗi hệ thống (500)
        public const string TooManyRequests = "ERR_TOO_MANY_REQUESTS";        // Quá nhiều yêu cầu (429)

        // Add more codes if needed
        public const string EmailAlreadyExists = "ERR_EMAIL_EXISTS";          // Email đã tồn tại
        public const string InvalidCredentials = "ERR_INVALID_CREDENTIALS";   // Thông tin đăng nhập không hợp lệ
        public const string TokenExpired = "ERR_TOKEN_EXPIRED";               // Token đã hết hạn
        public const string AccessDenied = "ERR_ACCESS_DENIED";               // Truy cập bị từ chối

    }
}
