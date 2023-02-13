using System.Numerics;

namespace PlantHere.Application.Interfaces.Queries
{
    public interface IQueryCacheable
    {
        // Munite
        int Expiration { set; get; }
    }
}
