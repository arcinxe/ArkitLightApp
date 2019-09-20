using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ArktiLight {
    public class OptionsManager {
        public List<ConfigOption> Options { get; set; } = new List<ConfigOption>();
        public string Name { get; set; }
        public string FilePath { get; set; }

        public OptionsManager(string name) {
            Name = name;
            FilePath = Path.Combine(Constants.DefaultFilePath,
                $"{System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name)}Config.json");
        }
        public string Find(string name) {
            ReadFromFile();
            return Options.FirstOrDefault(o => o.Name == name)?.Value;
        }
        public void Add(IEnumerable<string> options) {
            ReadFromFile();
            foreach (var option in options) {
                var splitted = option.Split(",").Select(a => a.Trim());
                if (!Options.Exists(a => splitted.Count() == 2 && a.Name == splitted.FirstOrDefault())) {
                    System.Console.WriteLine($"Added new {Name}: {splitted.ElementAtOrDefault(0)} => {splitted.ElementAtOrDefault(1)}");
                    Options.Add(new ConfigOption() {
                        Name = splitted.ElementAtOrDefault(0),
                            Value = splitted.ElementAtOrDefault(1)
                    });
                }
            }
            SaveToFile();
        }
        public void Remove(IEnumerable<string> names) {
            ReadFromFile();
            foreach (var name in names) {
                foreach (var option in Options.Where(a => a.Name == name || a.Value == name)) {
                    System.Console.WriteLine($"Removed {Name}: {option.Name} => {option.Value}");
                }
                Options.RemoveAll(a => a.Name == name || a.Value == name);
            }
            SaveToFile();
        }

        public string ListAll() {
            ReadFromFile();
            return string.Join("\n", Options);
        }

        private void ReadFromFile() {
            if (!File.Exists(FilePath))
                SaveToFile();
            Options = JsonConvert.DeserializeObject<List<ConfigOption>>(File.ReadAllText(FilePath));
        }
        private void SaveToFile() {
            if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Options, Formatting.Indented));
        }

    }
}
