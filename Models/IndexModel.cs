using Azure.AI.TextAnalytics;
using System.ComponentModel.DataAnnotations;

namespace PiiDetectionDemo.Models
{

    public class IndexModel
    {

        [Required]
        public string? InputText { get; set; }

        public string? RedactedText { get; set; }
      
        public long ExecutionTime { get; set; }

        public PiiEntityCollection? AnalysisResult { get; set; }

    }
}
