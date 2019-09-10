using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Environment;

namespace ArktiLight {
    class Program {
        private static AddressesManager _addressesManager = new AddressesManager();
        private static SettingsManager _settingsManager = new SettingsManager();
        static ManualResetEvent resetEvent = new ManualResetEvent(false);
        static void Main(string[] args) {
            switch (args.FirstOrDefault()) {
                case "add":
                    Add(args);
                    break;
                case "remove":
                    Remove(args);
                    break;
                case "list":
                    System.Console.WriteLine(ListAll(args));
                    break;
                case null:
                    System.Console.WriteLine("No arguments provided. Exiting.");
                    break;
                default:
                    System.Console.WriteLine("Wrong arguments.");
                    break;
            }
            var client = new ArktiLightClient("http://arktilight.local/api/v3");
            var queries = new List<string>() { "LED0=SS-1", "LED1=SS-1" };
            Task.Run(() => client.SetLeds(queries).Wait());
        }

        public static void Add(IEnumerable<string> args) {
            switch (args.ElementAtOrDefault(1)) {
                case "addr":
                case "address":
                    _addressesManager.Add(args.Skip(2));
                    break;
                case "set":
                case "setting":
                    _settingsManager.Add(args.Skip(2));
                    break;
            }
        }

        public static void Remove(IEnumerable<string> args) {
            switch (args.ElementAtOrDefault(1)) {
                case "addr":
                case "address":
                    _addressesManager.Remove(args.Skip(2));
                    break;
                case "set":
                case "setting":
                    _settingsManager.Remove(args.Skip(2));
                    break;
            }
        }

        public static string ListAll(IEnumerable<string> args) {
            var result = "";
            switch (args.ElementAtOrDefault(1)) {
                case "addr":
                case "address":
                    result = _addressesManager.ListAll();
                    break;
                case "set":
                case "setting":
                    result = _settingsManager.ListAll();
                    break;
                case null:
                    result += "Addresses:\n";
                    result += _addressesManager.ListAll();
                    result += "\n\nSettings:\n";
                    result += _settingsManager.ListAll();
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
