using Microsoft.AspNetCore.Mvc;
using Sparc.Blossom.Api;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Agrega;

public class Source : BlossomEntity<string>
{
    public Source(string name, string url, string feedUrl, string imageUrl, string description)
    {
        Id = Guid.NewGuid().ToString();
        SourceId = Id;
        Name = name;
        Url = url;
        FeedUrl = feedUrl;
        ImageUrl = imageUrl;
        Description = description;
        DateCreated = DateTime.UtcNow;
        Type = "RSS";
        Active = true;
    }

    public string SourceId { get; set; }
    public string Name { get; set; }
    public string? Url { get; set; }
    public string FeedUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; }
    public DateTime DateCreated { get; private set; }
    public DateTime? LastUpdatedTime { get; private set; }
    public bool Active { get; set; } = true;

    public void UpdateVisibility(bool active)
    {
        Active = active;
        LastUpdatedTime = DateTime.UtcNow;
    }
}

