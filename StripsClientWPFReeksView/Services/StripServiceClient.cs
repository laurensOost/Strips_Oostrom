using StripsClientWPFReeksView.Exceptions;
using StripsClientWPFReeksView.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace StripsClientWPFReeksView.Services
{
    public class StripServiceClient
    {
        private HttpClient client = new HttpClient();

        public StripServiceClient(string baseUri)
        {
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ReeksModel> GetReeksById(int reeksId)
        {
            ReeksModel reeks = null;
            HttpResponseMessage response = await client.GetAsync($"api/Strips/beheer/Reeks/{reeksId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                reeks = JsonConvert.DeserializeObject<ReeksModel>(json);

                // Assuming 'Strips' is a List<StripModel> or similar within 'ReeksModel'
                // and 'Titel' is the property you want to sort by.
                reeks.Strips = reeks.Strips.OrderBy(strip => strip.Titel).ToList();
            }
            else
            {
                MessageBox.Show($"Error: {response.StatusCode}", "Failed to Load", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return reeks;
        }

    }
}
