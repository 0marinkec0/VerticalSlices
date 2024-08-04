namespace Newsletter.Api.Entities;

public class Vote
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }

    public bool IsUpvoted { get; set; }

    private Vote() { }

    public static Vote CreateVote(User user, Post post, bool IsUpovoted) => new Vote { User = user, Post = post, IsUpvoted = IsUpovoted};

}
