using System.Data.Common;
using System.Security;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace AuthServer.Shared.Dtos
{
    public class Response<T> where T : class

    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public ErrorDto Error { get; private set; }
        [JsonIgnore] public bool IsSuccessful { get; private set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new Response<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static Response<T> Fail(string errorMassage, int statusCode, bool inShow)
        {
            var errorDto = new ErrorDto(errorMassage, inShow);
            return new Response<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }
    }
}