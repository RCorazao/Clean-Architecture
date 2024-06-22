﻿
using Clean.Architecture.Domain.Models;

namespace Clean.Architecture.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(
            int statusCode, object data = null, string message = null)
        {
            bool success = false;
            if (statusCode >= 200 && statusCode < 300)
                success = true;

            var result = new BaseResponseModel
            {
                StatusCode = statusCode,
                Success = success,
                Message = message,
                Data = data
            };
            return result;
        }
    }
}
