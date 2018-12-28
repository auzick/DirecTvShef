using System;
using Newtonsoft.Json;
using Shef;

namespace DirecTvShef
{
    class Program
    {
        private const string Host = "172.20.1.22";
        private const string Port = "8080";

        static void Main(string[] args)
        {
            //Console.WriteLine(new Server(Host, Port).MakeRawRequest($"serial/processCommand?cmd=FA9A"));

            //Console.WriteLine(JsonConvert.SerializeObject(
            //    new Api(Host, Port).GetLocations(LocationType.client)
            //    , Formatting.Indented));

            var result = new Api(Host, Port).GetTuned();
            Console.WriteLine($"{result.status.msg} ({result.status.code})");
            Console.WriteLine();
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));

            Console.ReadLine();
        }
        
    }
}
