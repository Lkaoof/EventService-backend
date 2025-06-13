using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlatform.Application.Common.ResultWrapper
{
    [Flags]
    public enum Status
    {
        Ok,
        Error
    }

    public class Result
    {
        public bool IsSuccess { get; set; }
        public bool IsFailure { get => !IsSuccess; }
        public string? Message { get; set; }
        public Status Status { get; set; }

        public static Result Success(string message = "Success")
            => new() { IsSuccess = true, Message = message, Status = Status.Ok };

        public static Result Failure(string message = "Failure")
            => new() { IsSuccess = false, Message = message, Status = Status.Error };
    }

    public class Result<T> : Result
    {
        public T? Value { get; set; }

        public static Result<T> Success(T value, string message = "Success")
            => new() { Value = value, IsSuccess = true, Message = message, Status = Status.Ok };
    }
}
