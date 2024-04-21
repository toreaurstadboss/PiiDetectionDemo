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
            //__piiRemovalTextAnalyticsClientService.




        }

        private void removeWhitespace(ChangeEventArgs args)
        {
            Model.InputText = args.Value?.ToString()?.CleanupAllWhiteSpace();
            StateHasChanged();
        }



    }
}
