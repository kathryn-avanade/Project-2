using Frontend.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Frontend.Models
{
    [ExcludeFromCodeCoverage]
    public class ErrorViewModel : IErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
