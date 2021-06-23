using Frontend.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    [ExcludeFromCodeCoverage]
    public class Wedding : IWedding
    {
        public int ID { get; set; }
        public string WeddingText { get; set; }
        public string PersonURL { get; set; }
        public string PlaceURL { get; set; }

        public DateTime Date { get; set; }
    }
}
