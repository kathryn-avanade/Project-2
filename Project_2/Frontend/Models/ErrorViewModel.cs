using Frontend.Interfaces;
using System;

namespace Frontend.Models
{
    public class ErrorViewModel : IErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
