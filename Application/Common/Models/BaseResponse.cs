using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Common.Models
{
    public class BaseResponse
    {
        public BaseResponse(HttpStatusCode statusCode, string? error = null)
        {
            IsSuccess = (int)statusCode < 400;
            StatusCode = statusCode;
            Error = error;
        }

        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Error { get; set; }
    }
    public class BaseResponse<T>: BaseResponse
    {
        public BaseResponse(HttpStatusCode statusCode, T? content, string? error = null) : base(statusCode, error)
        {
            IsSuccess = (int)statusCode < 400;
            StatusCode = statusCode;
            Content = content;
            Error = error;
        }

        public T? Content { get; set; }
    }
}
