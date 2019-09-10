using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ArktiLight {
    public class SettingsManager {
        public List<Address> Settings { get; set; } = new List<Address>();
        public void Add(IEnumerable<string> settings) {
            ReadFromFile();
            foreach (var setting in settings) {
                var splitted = setting.Split(",").Select(a => a.Trim());
                if (!Settings.Exists(a => splitted.Count() == 2 && a.Alias == splitted.FirstOrDefault())) {
                    Settings.Add(new Address() {
                        Alias = splitted.ElementAtOrDefault(0),
                            Path = splitted.ElementAtOrDefault(1)
                    });
                }
                System.Console.WriteLine();
            }
            SaveToFile();
        }
        public void Remove(IEnumerable<string> names) {
            ReadFromFile();
            foreach (var name in names) {
                Settings.RemoveAll(a => a.Alias == name || a.Path == name);
            }
            SaveToFile();
        }

        public string ListAll() {
            ReadFromFile();
            return string.Join("\n", Settings);
        }

        private void ReadFromFile() {
            if (!File.Exists(Constants.SettingsFilePath))
                SaveToFile();
            Settings = JsonConvert.DeserializeObject<List<Address>>(File.ReadAllText(Constants.SettingsFilePath));
        }
        private void SaveToFile() {
            if (!Directory.Exists(Path.GetDirectoryName(Constants.SettingsFilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(Constants.SettingsFilePath));
            File.WriteAllText(Constants.SettingsFilePath, JsonConvert.SerializeObject(Settings, Formatting.Indented));
        }

    }
}
