using System.IO;
using static System.Environment;

namespace ArktiLight {
    public static class Constants {
        public readonly static string DefaultFilePath = Path
            .Combine(GetFolderPath(SpecialFolder.ApplicationData), "ArktiLight");
    }
}
