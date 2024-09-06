namespace Agrega;

public class Post : BlossomEntity<string>
{
    public Post(string title,
        string url,
        string summary,
        DateTime? postDate,
        List<string> authors,
        List<string> categories,
        string sourceId,
        string sourceName,
        string sourceImage)
    {
        Id = Guid.NewGuid().ToString();
        PostId = Id;
        Title = title;
        Url = url;
        Summary = summary;
        PostDate = postDate;
        Authors = authors;
        Categories = categories;
        SourceId = sourceId;
        SourceName = sourceName;
        SourceImage = sourceImage;
        DateCreated = DateTime.UtcNow;
        LastUpdatedTime = DateCreated;
    }

    public string PostId { get; set; }
    public string SourceId { get; set; }
    public string SourceName { get; set; }
    public string SourceImage { get; set; }
    public string Title { get; set; }
    public string? Summary { get; set; }
    public string? Url { get; set; }
    public string? ImgUrl { get; set; }
    public List<string> Authors { get; set; } = new List<string>();
    public List<string> Categories { get; set; } = new List<string>();
    public DateTime? PostDate { get; set; }
    public DateTime DateCreated { get; private set; }

    public DateTimeOffset LastUpdatedTime;

    public DateTimeOffset PublishDate;

    public bool? ReadLater { get; set; } = false;

    public void ToggleReadLater()
    {
        ReadLater = ReadLater.HasValue ? !ReadLater.Value : true;
    }
}