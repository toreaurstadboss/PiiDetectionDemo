using Azure;
using Azure.AI.TextAnalytics;

namespace PiiDetectionDemo.Util
{
    public class PiiRemovalTextAnalyticsClientService : IPiiRemovalTextAnalyticsClientService
    {

        private TextAnalyticsClient _client;

        public PiiRemovalTextAnalyticsClientService()
        {
            var azureEndpoint = Environment.GetEnvironmentVariable("AZURE_COGNITIVE_SERVICE_ENDPOINT");
            var azureKey = Environment.GetEnvironmentVariable("AZURE_COGNITIVE_SERVICE_KEY");

            if (string.IsNullOrWhiteSpace(azureEndpoint))
            {
                throw new ArgumentNullException(nameof(azureEndpoint), "Missing system environment variable: AZURE_COGNITIVE_SERVICE_ENDPOINT");
            }
            if (string.IsNullOrWhiteSpace(azureKey))
            {
                throw new ArgumentNullException(nameof(azureKey), "Missing system environment variable: AZURE_COGNITIVE_SERVICE_KEY");
            }

            _client = new TextAnalyticsClient(new Uri(azureEndpoint), new AzureKeyCredential(azureKey));
        }

        public async Task<Response<PiiEntityCollection>> RecognizePiiEntitiesAsync(string? document, string? language)
        {
            var piiEntities = await _client.RecognizePiiEntitiesAsync(document, language);
            return piiEntities;
        }



    }
}
