using Ardalis.Specification;

namespace Agrega.Posts;

public class All : BlossomQuery<Post>
{
    public All() => Query.OrderByDescending(x => x.PostDate);
}

public class Paginated : BlossomQuery<Post>
{
    public Paginated(int page, int pageSize)
    {
        Query.OrderByDescending(x => x.DateCreated);
        Query.Skip((page - 1) * pageSize).Take(pageSize);
    }
}

public class  Exists : BlossomQuery<Post>
{
    public Exists(string url)
    {
        Query.Where(x => x.Url == url);
    }
}

public class ReadLaterList : BlossomQuery<Post>
{
    public ReadLaterList()
    {
        Query.Where(x => x.ReadLater == true);
    }
}
