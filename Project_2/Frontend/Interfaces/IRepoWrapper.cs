using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Interfaces
{
    public interface IRepoWrapper
    {
        IWeddingRepo Weddings { get; }


        void Save() { }
    }
}
