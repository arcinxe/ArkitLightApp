using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ArktiLight {
    public class ArktiLightClient {
        private readonly static HttpClient _client = new HttpClient();
        public async Task<List<Leds>> SetLeds(List<string> queries) {
            var results = new List<Leds>();
            var responses = new List<Task<HttpResponseMessage>>();

            foreach (var query in queries) {
                responses.Add(_client.GetAsync(query));
            }

            var count = 0;
            foreach (var response in responses) {
                try {
                    var ledStates = await response.Result.Content.ReadAsStringAsync();
                    // System.Console.WriteLine(ledStates);
                    var leds = JsonConvert.DeserializeObject<Leds>(ledStates);
                    results.Add(leds);
                    count++;
                } catch (System.Exception e) {
                    System.Console.WriteLine($"{queries.ElementAtOrDefault(count)} => {e.Message}");
                }
            }
            return results;
        }

    }
}
