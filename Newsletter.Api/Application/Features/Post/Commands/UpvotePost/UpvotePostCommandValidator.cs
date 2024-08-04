using FluentValidation;

namespace Newsletter.Api.Application.Features.Post.Commands.UpvotePost;

public class UpvotePostCommandValidator : AbstractValidator<UpvotePostCommand>
{
    public UpvotePostCommandValidator()
    {
        RuleFor(x => x.postId)
            .NotEmpty()
            .WithMessage("Post Id must not be empty");
    }
}
