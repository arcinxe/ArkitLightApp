using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ArktiLight {
    public class AddressesManager {
        public List<Address> Addresses { get; set; } = new List<Address>();
        public void Add(IEnumerable<string> addresses) {
            ReadFromFile();
            foreach (var address in addresses) {
                var splitted = address.Split(",").Select(a => a.Trim());
                if (!Addresses.Exists(a => splitted.Count() == 2 && a.Alias == splitted.FirstOrDefault())) {
                    Addresses.Add(new Address() {
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
                Addresses.RemoveAll(a => a.Alias == name || a.Path == name);
            }
            SaveToFile();
        }

        public string ListAll() {
            ReadFromFile();
            return string.Join("\n", Addresses);
        }

        private void ReadFromFile() {
            if (!File.Exists(Constants.AddressesFilePath))
                SaveToFile();
            Addresses = JsonConvert.DeserializeObject<List<Address>>(File.ReadAllText(Constants.AddressesFilePath));
        }
        private void SaveToFile() {
            if (!Directory.Exists(Path.GetDirectoryName(Constants.AddressesFilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(Constants.AddressesFilePath));
            File.WriteAllText(Constants.AddressesFilePath, JsonConvert.SerializeObject(Addresses, Formatting.Indented));
        }

    }
}
