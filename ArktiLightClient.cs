using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ArktiLight
{
    public class ArktiLightClient
    {
        private readonly static HttpClient _client = new HttpClient();
        public string Url { get; set; }
        public ArktiLightClient(string url)
        {
            Url = url;
        }
        public async Task<Leds> SetLeds(string query)
        {
            var fullUrl = $"{Url}?{query}";
            var ledsResponse = await _client.GetAsync(fullUrl);
            ledsResponse.EnsureSuccessStatusCode();
            var ledStates = ledsResponse.Content.ReadAsStringAsync();
            System.Console.WriteLine(ledStates.Result);
            var leds = JsonConvert.DeserializeObject<Leds>(ledStates.Result);
            return leds;
        }

    }
}