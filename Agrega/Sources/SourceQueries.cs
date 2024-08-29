using Ardalis.Specification;

namespace Agrega;

public class All : BlossomQuery<Source>
{
    public All() => Query.OrderByDescending(x => x.DateCreated);
}