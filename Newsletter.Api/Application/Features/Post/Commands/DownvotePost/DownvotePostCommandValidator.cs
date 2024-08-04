using FluentValidation;

namespace Newsletter.Api.Application.Features.Post.DownvotePost;

public class DownvotePostCommandValidator : AbstractValidator<DownvotePostCommand>
{
    public DownvotePostCommandValidator()
    {
        RuleFor(x => x.postId)
            .NotEmpty()
            .WithMessage("Post Id must not be empty");
    }
}
