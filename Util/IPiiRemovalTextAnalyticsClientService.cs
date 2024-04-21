using Azure;
using Azure.AI.TextAnalytics;

namespace PiiDetectionDemo.Util
{
    public interface IPiiRemovalTextAnalyticsClientService
    {
        Task<Response<PiiEntityCollection>> RecognizePiiEntitiesAsync(string document, string language = "no");
    }
}