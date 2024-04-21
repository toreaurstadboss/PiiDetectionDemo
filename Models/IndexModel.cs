using System.ComponentModel.DataAnnotations;

namespace PiiDetectionDemo.Models
{

    public class IndexModel
    {

        [Required]
        public string? InputText { get; set; }
      
        public long ExecutionTime { get; set; }

        public string? AnalysisResult { get; set; }

    }
}
