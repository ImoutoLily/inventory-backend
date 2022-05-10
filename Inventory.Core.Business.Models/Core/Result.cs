using Inventory.Core.Business.Errors;

namespace Inventory.Core.Business.Models.Core;

public class Result
{
    public IError? Error { get; }

    protected Result(IError? error = null)
    {
        Error = error;
    }

    public static Result Fail(IError error)
    {
        return new Result(error);
    }

    public static Result<T> Fail<T>(IError error)
    {
        return new Result<T>(default(T), error);
    }

    public static Result Ok()
    {
        return new Result();
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value);
    }
}

public class Result<T> : Result
{
    public T? Value { get; }

    protected internal Result(T? value, IError? error = null) : base(error)
    {
        Value = value;
    }
}