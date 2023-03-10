using agregadotnet.Features.Posts.Entities;
using System.ServiceModel.Syndication;
using System.Xml;

namespace agregadotnet.Features.Posts
{
    public class GetBlogPosts : PublicFeature<List<Post>>
    {
        private IConfiguration _configuration;
        public GetBlogPosts(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override async Task<List<Post>> ExecuteAsync()
        {
            var blogs = _configuration.GetSection("Blogs").Get<List<Blog>>();

            var posts = new List<Post>();

            foreach (var blog in blogs)
            {
                string url = blog.Url;
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items.Take(3))
                {

                    Post post = new Post(blog);
                    post.Subject = item.Title.Text;
                    post.Summary = item.Summary.Text;
                    post.LastUpdatedTime = item.LastUpdatedTime;
                    post.PublishDate = item.PublishDate;
                    post.PostDate = item.PublishDate.LocalDateTime;
                    post.Url = item.Links?.FirstOrDefault().Uri.ToString();

                    foreach (var a in item.Authors)
                    {
                        post.Authors.Add(a.Name);
                    }

                    foreach (var c in item.Categories)
                    {
                        post.Categories.Add(c.Name);
                    }

                    posts.Add(post);
                }
            }

            return await Task.FromResult(posts.OrderByDescending(x => x.PublishDate).ToList());
        }
    }
}
