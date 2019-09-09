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
        public async Task<LedsStatesModel.Leds> SetLeds(string query)
        {
            var fullUrl = $"{Url}?{query}";
            var ledsResponse = await _client.GetAsync(fullUrl);
            ledsResponse.EnsureSuccessStatusCode();
            var ledStates = ledsResponse.Content.ReadAsStringAsync();
            var leds = JsonConvert.DeserializeObject<LedsStatesModel.Leds>(ledStates.Result);
            return leds;
        }

        public LedsStatesModel.Leds ChangeBrightness(int led, int offset)
        {
            return SetLeds($"ledIndex={led}&changeBrightness={offset}").Result;
        }

        public LedsStatesModel.Leds SetBrightness(int led, int value)
        {
            return SetLeds($"ledIndex={led}&setBrightness={value}").Result;
        }
        public LedsStatesModel.Leds SetState(int led, int state)
        {
            return SetLeds($"ledIndex={led}&setState={state}").Result;
        }
    }
}