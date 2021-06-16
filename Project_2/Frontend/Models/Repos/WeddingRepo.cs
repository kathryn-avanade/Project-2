using Frontend.Data;
using Frontend.Interfaces;

namespace Frontend.Models.Repos
{
    public class WeddingRepo : Repos<Wedding>, IWeddingRepo
    {
        public WeddingRepo(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}