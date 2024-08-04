namespace Newsletter.Api.Application.Features.Post.GetAllPosts
{
    public class PostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public int CalculateVotes { get; set; }
    }
}
