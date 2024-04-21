using Azure;
using Microsoft.AspNetCore.Components;
using PiiDetectionDemo.Models;
using PiiDetectionDemo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiiDetectionDemo.Components.Pages
{
    public partial class Home
    {

        private IndexModel Model = new();
        private bool isProcessing = false;
        private bool isSearchPerformed = false;

        private async Task Submit()
        {
            isSearchPerformed = false;
            isProcessing = true;
            try
            {
                var response = await _piiRemovalTextAnalyticsClientService.RecognizePiiEntitiesAsync(Model.InputText, null);
                Model.RedactedText = response?.Value?.RedactedText;
                Model.AnalysisResult = response?.Value;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
            }
            isProcessing = false;
            isSearchPerformed = true;
        }

        private void removeWhitespace(ChangeEventArgs args)
        {
            Model.InputText = args.Value?.ToString()?.CleanupAllWhiteSpace();
            StateHasChanged();
        }



    }
}
