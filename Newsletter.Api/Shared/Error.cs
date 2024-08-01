﻿namespace Newsletter.Api.Shared
{
    public class Error
    {
        public string? Code { get; }

        public string? Message { get; }

        public Error(string? code, string? message)
        {
            Code = code;
            Message = message;
        }

 
        public static readonly Error None = new Error(string.Empty, string.Empty);

    }
}
