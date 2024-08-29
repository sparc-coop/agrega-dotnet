namespace Agrega;

public class Source : BlossomEntity<string>
{
    public Source(string name, string url, string imageUrl, string description)
    {
        Id = BlossomTools.FriendlyId();
        SourceId = Id;
        Name = name;
        Url = url;
        ImageUrl = imageUrl;
        Description = description;
        DateCreated = DateTime.UtcNow;
    }

    public string SourceId { get; set; }
    public string Name { get; set; }

    public string? Url { get; set; }

    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreated { get; private set; }
}

