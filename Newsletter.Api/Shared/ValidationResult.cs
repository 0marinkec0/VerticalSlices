using Microsoft.Identity.Client;

namespace Newsletter.Api.Shared;

public class ValidationResult : Result
{
    private ValidationResult(Error[] errors)
        : base(false, new Error(code: "ValidationError", message: "A validation problem occurred."))
    {
      Errors = errors;
    }

    public Error[] Errors { get;}


    public static ValidationResult WithErrors(Error[] errors) => new(errors);
}
