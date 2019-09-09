using System;
using System.Linq;
using static System.Environment;

namespace ArktiLight
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ArktiLightClient("http://arktilight.local/api/v3");
            Console.WriteLine(GetFolderPath(SpecialFolder.ApplicationData));
            // if(args.Count() == 0)
            //     System.Console.WriteLine(client.SetLeds("").Result);
            
            // foreach (var arg in args)
            //     System.Console.WriteLine(client.SetLeds(arg).Result);

            // var action = "";
            // var leds = new List<int>();
            // var setBrightnesses =new List<int>();
            // var changeBrightnesses = new List<int>();
            // var changeStates = new List<int>();
            // foreach (var arg in args)
            // {
            //     switch (arg)
            //     {
            //         case "--change-brightness":
            //             action = "changeBrightness";
            //             break;
            //         case "--set-brightness":
            //             action = "setBrightness";
            //             break;
            //         case "--set-state":
            //             action = "setState";
            //             break;
            //         case "--led":
            //             action = "ledIndex";
            //             break;
            //         default:
            //             break;
            //     }

            // }



        }
    }
}
