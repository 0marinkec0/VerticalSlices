﻿namespace Newsletter.Api.Shared;

public class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }


    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);
    
}

public class Result<TValue> : Result
{
    private readonly TValue _value;

    public Result(TValue value,bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value => IsSuccess
       ? _value!
       : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static Result<TValue> Success(TValue value) => new(value, true, Error.None);

    public new static Result<TValue> Failure(Error error) => new(default!, false, error);
}
