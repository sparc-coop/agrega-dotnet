using Sparc.Blossom;
using Sparc.Blossom.Data;

public class Post : BlossomEntity<string>
{
    public Post(string title, string subject, string sourceId)
    {
        Id = BlossomTools.FriendlyId();
        PostId = Id;
        Title = title;
        Subject = subject;
        SourceId = sourceId;
        DateCreated = DateTime.UtcNow;
    }

    public string PostId { get; set; }
    public string SourceId { get; set; }
    public string Title { get; set; }
    public string? Subject { get; set; }
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? ImgUrl { get; set; }

    public DateTimeOffset LastUpdatedTime;

    public DateTimeOffset PublishDate;
    public DateTime? PostDate { get; set; }
    public DateTime DateCreated { get; private set; }
}