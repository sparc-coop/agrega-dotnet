using agregadotnet.Features.Posts.Entities;

namespace agregadotnet.Features.Posts
{
    public class GetChannels : PublicFeature<List<Channel>>
    {
        private IConfiguration _configuration;

        public GetChannels(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override async Task<List<Channel>> ExecuteAsync()
        {
            var channels = _configuration.GetSection("Channels").Get<List<Channel>>();

            return await Task.FromResult(channels);
        }
    }
}
