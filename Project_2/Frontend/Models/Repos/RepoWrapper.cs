using Frontend.Data;
using Frontend.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models.Repos
{
    [ExcludeFromCodeCoverage]
    public class RepoWrapper : IRepoWrapper
    {
        //Dependency injection for 'fake' db
        ApplicationDBContext _repoContext;
        public RepoWrapper(ApplicationDBContext repoContext)
        {
            _repoContext = repoContext;
        }
        IWeddingRepo _weddings;
        public IWeddingRepo Weddings
        {
            get
            {
                if (_weddings == null)
                {
                    _weddings = new WeddingRepo(_repoContext);
                }
                return _weddings;
            }
        }

        

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
