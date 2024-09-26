namespace Agrega._Plugins
{
    public class YouTubeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public YouTubeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["YouTubeAPI:ApiKey"]; // Access API key directly from configuration
        }

        public async Task<YouTubeVideoResponse> GetVideosAsync(string channelId)
        {
            string requestUrl = $"https://www.googleapis.com/youtube/v3/search?part=snippet&channelId={channelId}&maxResults=10&order=date&type=video&key={_apiKey}";
            return await _httpClient.GetFromJsonAsync<YouTubeVideoResponse>(requestUrl);
        }
    }

    public record YouTubeVideoResponse
    {
        public Item[] Items { get; set; }
    }

    public record Item
    {
        public Id Id { get; set; }
        public Snippet Snippet { get; set; }
    }

    public record Id
    {
        public string Kind { get; set; }
        public string VideoId { get; set; }
        public string Url => $"https://www.youtube.com/watch?v={VideoId}";
    }

    public record Snippet
    {
        public DateTime PublishedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Thumbnails Thumbnails { get; set; }
    }

    public record Thumbnails
    {
        public Thumbnail Default { get; set; }
        public Thumbnail High { get; set; }
    }

    public record Thumbnail
    {
        public string Url { get; set; }
    }

}
