using EndpointWithDelayHelper;
using RestSharp;
using System;
using System.Linq;
using System.Threading;

namespace EndpointWithDelayClient
{
    class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            Console.Write("URL: ");

            var url = Console.ReadLine();
            var client = new RestClient(url);

            int i = 0;

            while (true)
            {
                var request = new RestRequest("api/values?key=" + keys[i]);

                client.ExecuteAsync<KeyValue>(request, response =>
                {
                    if (!response.IsSuccessful)
                    {
                        Console.WriteLine("Error...");
                    }
                    else
                    {
                        Console.WriteLine("Key: " + response.Data.Key);
                        Console.WriteLine("Value: " + response.Data.Value);
                        Console.WriteLine("Is Valid? " + IsValid(response.Data.Key, response.Data.Value));
                    }

                    Console.WriteLine("-----------------");
                });

                if (++i >= keys.Length)
                    i = 0;

                Thread.Sleep(1000);
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static bool IsValid(string key, string value)
            => key.ToBase64() == value;

        static string[] keys = new string[] {
            "2BLFBMT2DY",
            "NZ7R92XSNF",
            "NRJS1W42F1",
            "4KN7O7Z0MO",
            "V8RKR0EEA7",
            "XVUY0K22NO",
            "R1WL4DLADB",
            "D6F9TPA9AB",
            "S02IDJZZHD",
            "F6M764LFPO",
            "PDA830PVFL",
            "K21M618OIV",
            "NV3A6HUHCY",
            "E4TWVOZ3PM",
            "3DU63NE9BF",
            "6774A3KACV",
            "GHSQGPIF1R",
            "BE851KB7HS",
            "DUG72H7ZW2",
            "EZ13GWUDZN",
            "E8IUD18BC0",
            "1N2TSWBVY9",
            "RTT8MMNFZF",
            "Z7I3OELW4B",
            "J6W5A16HLU",
            "U9PZ6UPJH0",
            "N2M7A4F9EO",
            "KP1W0V6X8V",
            "QG4FU0SS74",
            "YBODXQUZ5G",
            "W7C7JFH28K",
            "X2LWKH8GMK",
            "LWBKZIAY8K",
            "BH229SD75O",
            "TZTWG6012Q",
            "SNMU4952HA",
            "ET3YJP9SX1",
            "EBK71WCPD2",
            "SJ5S2X4H89",
            "XKZ5J955M0",
            "7IEAMRCP3I",
            "6QZPS5XL6W",
            "V1UXE3LPX1",
            "0HCM5KE4GL",
            "VPOZDGVKNO",
            "MU80FFXR5S",
            "FW1BSYNMUI",
            "12FVBGN4T7",
            "IBCJPFJMGZ",
            "WW8XF8XMHO",
            "3I0FWTPNZ9",
            "2387KEURWM",
            "PAF4VF4RPC",
            "SAWEE9L6X5",
            "05XH72YBNB",
            "NGZ593C5TR",
            "Z77WR1H33K"
        };
    }
}
