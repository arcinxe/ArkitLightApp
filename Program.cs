using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Environment;

namespace ArktiLight {
    class Program {
        private static OptionsManager _lightsManager = new OptionsManager("light");
        private static OptionsManager _settingsManager = new OptionsManager("setting");
        static ManualResetEvent resetEvent = new ManualResetEvent(false);
        static void Main(string[] args) {
            switch (args.FirstOrDefault()) {
                case "a":
                case "add":
                    Add(args);
                    break;
                case "r":
                case "remove":
                    Remove(args);
                    break;
                case "ls":
                case "list":
                    System.Console.WriteLine(ListAll(args));
                    break;
                case null:
                    System.Console.WriteLine("No arguments provided. Exiting.");
                    break;
                case "x":
                case "ex":
                case "execute":
                    Execute(args.Skip(1)).Wait();
                    break;
                default:
                    System.Console.WriteLine("Wrong arguments.");
                    break;
            }
        }

        public static async Task Execute(IEnumerable<string> args) {
            var client = new ArktiLightClient();
            var queries = new List<string>();
            foreach (var arg in args) {
                var splitted = arg.Split(",");

                var address = _lightsManager.Find(splitted.ElementAtOrDefault(0)) ?? splitted.ElementAtOrDefault(0);
                var query = _settingsManager.Find(splitted.ElementAtOrDefault(1)) ?? splitted.ElementAtOrDefault(1);

                queries.Add($"http://{address}/api/v3?{query}");
            }
            Task<List<Leds>> setLeds = client.SetLeds(queries);
            var results = await setLeds;
            // System.Console.WriteLine(JsonConvert.SerializeObject(results, Formatting.Indented));
        }

        public static void Add(IEnumerable<string> args) {
            switch (args.ElementAtOrDefault(1)) {
                case "l":
                case "li":
                case "light":
                    _lightsManager.Add(args.Skip(2));
                    break;
                case "s":
                case "set":
                case "setting":
                    _settingsManager.Add(args.Skip(2));
                    break;
            }
        }

        public static void Remove(IEnumerable<string> args) {
            switch (args.ElementAtOrDefault(1)) {
                case "l":
                case "li":
                case "light":
                    _lightsManager.Remove(args.Skip(2));
                    break;
                case "s":
                case "set":
                case "setting":
                    _settingsManager.Remove(args.Skip(2));
                    break;
            }
        }

        public static string ListAll(IEnumerable<string> args) {
            var result = "";
            switch (args.ElementAtOrDefault(1)) {
                case "l":
                case "li":
                case "light":
                    result = _lightsManager.ListAll();
                    break;
                case "s":
                case "set":
                case "setting":
                    result = _settingsManager.ListAll();
                    break;
                case null:
                    result += "Lights:\n";
                    result += _lightsManager.ListAll();
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
