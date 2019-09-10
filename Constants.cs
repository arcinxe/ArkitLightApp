using System.IO;
using static System.Environment;

namespace ArktiLight {
    public static class Constants {
        public readonly static string SettingsFilePath = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), "ArktiLight", "Settings.json");
        public readonly static string AddressesFilePath = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), "ArktiLight", "Addresses.json");
    }
}
