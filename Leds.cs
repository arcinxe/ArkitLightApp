using System.Collections.Generic;
using Newtonsoft.Json;

public partial class Leds {
    [JsonProperty("lights")]
    public List<Light> Lights { get; set; }
}
public class Light {
    [JsonProperty("index")]
    public long Index { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("color")]
    public string Color { get; set; }

    [JsonProperty("brightness")]
    public long Brightness { get; set; }

    [JsonProperty("state")]
    public bool State { get; set; }

    [JsonProperty("mode")]
    public long Mode { get; set; }

    [JsonProperty("modeName")]
    public string ModeName { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}
