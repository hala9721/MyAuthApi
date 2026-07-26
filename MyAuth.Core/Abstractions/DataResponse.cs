using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MyAuth.Core.Abstractions
{
    public sealed class DataResponse<T>
    {
        public T? Data { set; get; }
        public IReadOnlyCollection<string> Errors { set; get; } = [];
        public HttpStatusCode StatusCode { set; get; }
        public bool IsSuccess => Errors.Count == 0;
    }

    public static class DataResponses
    {
        public static DataResponse<T> Ok<T>(T data)=>
            new DataResponse<T>() { Data = data, StatusCode = HttpStatusCode.OK };

        public static DataResponse<T> BadRequest<T>(params string[] errors) =>
            new DataResponse<T>() { Errors = errors, StatusCode = HttpStatusCode.BadRequest };

        public static DataResponse<T> Unauthorized<T>(params string[] errors) =>
            new DataResponse<T>() { Errors = errors, StatusCode = HttpStatusCode.Unauthorized };
    }
}
