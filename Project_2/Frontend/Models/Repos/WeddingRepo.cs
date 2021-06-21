using Frontend.Data;
using Frontend.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Frontend.Models.Repos
{
    [ExcludeFromCodeCoverage]
    public class WeddingRepo : Repos<Wedding>, IWeddingRepo
    {
        public WeddingRepo(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}