using Azure.AI.TextAnalytics;
using Microsoft.AspNetCore.Components;
using PiiDetectionDemo.Util;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiiDetectionDemo.Models
{

    public class IndexModel
    {

        [Required]
        public string? InputText { get; set; }

        public string? RedactedText { get; set; }

        public string? HtmlRedactedText { get; set; }

        public MarkupString HtmlRedactedTextMarkupString { get; set; }

        public void UpdateHtmlRedactedText()
        {
            var sb = new StringBuilder(RedactedText);
            if (AnalysisResult != null && RedactedText != null)
            {
                foreach (var piiEntity in AnalysisResult.OrderByDescending(a => a.Offset))
                {
                    sb.Insert(piiEntity.Offset + piiEntity.Length, "</b></span>");
                    sb.Insert(piiEntity.Offset, $"<span style='background-color:lightgray;border:1px solid black;corner-radius:2px; color:{GetBackgroundColor(piiEntity)}' title='{piiEntity.Category}: {piiEntity.SubCategory} Confidence: {piiEntity.ConfidenceScore} Redacted Text: {piiEntity.Text}'><b>");
                }
            }
            HtmlRedactedText = sb.ToString()?.CleanupAllWhiteSpace();    
            HtmlRedactedTextMarkupString = new MarkupString(HtmlRedactedText ?? string.Empty);
        }

        private string GetBackgroundColor(PiiEntity piiEntity)
        {
            if (piiEntity.Category == PiiEntityCategory.PhoneNumber)
            {
                return "yellow";
            }
            if (piiEntity.Category == PiiEntityCategory.Organization)
            {
                return "orange";
            }
            if (piiEntity.Category == PiiEntityCategory.Address)
            {
                return "green";
            }
            return "gray";                   
        }

        public long ExecutionTime { get; set; }
        public PiiEntityCollection? AnalysisResult { get; set; }

    }
}
