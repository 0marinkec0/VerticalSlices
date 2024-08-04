namespace Newsletter.Api.Entities;

public class Vote
{
    public int Id { get; set; }

    public int UserId { get; private set; }
    public User User { get; private set; }

    public int PostId { get; private set; }
    public Post Post { get; private set; }

    public bool IsUpvoted { get; set; }

    private Vote() { }

    public static Vote CreateVote(User user, Post post, bool IsUpovoted) => new Vote { User = user, Post = post, IsUpvoted = IsUpovoted};

    //public void SetUpvoteFlag() => IsUpvoted = true;
}
