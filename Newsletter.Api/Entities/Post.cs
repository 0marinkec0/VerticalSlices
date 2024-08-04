using Newsletter.Api.Shared;

namespace Newsletter.Api.Entities;

public class Post : IAuditableEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Upvotes { get; set; }
    public int Downvotes { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public List<Vote> Votes { get; set; } = new();

    private Post() { }

    public static Post CreatePost(string title, string content, User user) => 
        new Post { Title = title, Content = content, User = user };


    public Result Upvote(User user, Vote voteByUserExist)
    {
        if (user.Id == UserId)
        {
            return Result.Failure(new Error(code: "Post.UpvoteError", message: "Cannot upvote your own post!"));
        }

        if (voteByUserExist is not null)
        {
            if (voteByUserExist.IsUpvoted == true)
            {
                voteByUserExist.IsUpvoted = false;
                Upvotes--;
                return Result.Success();
            }

            voteByUserExist.IsUpvoted = true;
            Downvotes--;
            Upvotes++;
            return Result.Success();
        }

        Votes.Add(Vote.CreateVote(user, this, true));
        Upvotes++;
        return Result.Success();
    }

    public Result Downvote(User user, Vote voteByUserExist)
    {
        if (user.Id == UserId)
        {
            return Result.Failure(new Error(code: "Post.DownvoteError", message: "Cannot downvote your own post!"));
        }

        if (voteByUserExist is not null)
        {
            if (voteByUserExist.IsUpvoted == false)
            {
                Downvotes--;
                return Result.Success();
            }

            voteByUserExist.IsUpvoted = false;
            Upvotes--;
            Downvotes++;
            return Result.Success();
        }

        Votes.Add(Vote.CreateVote(user, this, false));
        Downvotes++;
        return Result.Success();
    }

    public int CalculateVotes => Upvotes - Downvotes;
}
