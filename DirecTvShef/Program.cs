using System;
using Newtonsoft.Json;
using Shef;
using Shef.Model.ShefResponses;

namespace DirecTvShef
{
    class Program
    {
        private const string Host = "172.20.1.22";
        private const string Port = "8080";

        static void Main(string[] args)
        {
            Console.WriteLine(new Server(Host, Port).MakeRawRequest($"serial/processCommand?cmd={Serial.Commands.GetUserCommand}"));

            //Console.WriteLine(JsonConvert.SerializeObject(
            //    new Api(Host, Port).GetLocations(LocationType.client)
            //    , Formatting.Indented));

            //var result = new Api(Host, Port).ProcessKey(RemoteKey.poweron, RemoteKeyAction.keyPress);
            //var result = new Api(Host, Port).PrimaryStatus();

            //Console.WriteLine();
            //Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));

            Console.ReadLine();
        }
        
    }
}
