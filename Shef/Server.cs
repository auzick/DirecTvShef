using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Shef.Model;

namespace Shef
{
    public class Server
    {

        public string Host { get; set; }
        public string Port { get; set; }

        private RestClient Client => new RestClient($"http://{Host}:{Port}");

        public Server(string host, string port)
        {
            Host = host;
            Port = port;
        }

        /// <summary>
        /// Makes a request to the server's specified path
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>The body of the response</returns>
        public string MakeRawRequest(string path)
        {
            var request = new RestRequest(path, Method.GET);
            return Client.Execute(request).Content;
        }

        /// <summary>
        /// Makes a request to the server
        /// </summary>
        /// <typeparam name="T">Type of response expected. Must inherit from IShefResponse.</typeparam>
        /// <param name="request">The request</param>
        /// <returns>IShefResponse</returns>
        public T MakeRequest<T>(RestRequest request)
            where T : IShefResponse
        {
            request.Method = Method.GET;
            var response = Client.Execute(request);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Makes a request to the server.
        /// </summary>
        /// <typeparam name="T">Type of response expected. Must inherit from IShefResponse.</typeparam>
        /// <param name="path">The path</param>
        /// <param name="parameters">Parameters to pass</param>
        /// <returns>IShefResponse</returns>
        public T MakeRequest<T>(
            string path,
            IEnumerable<Parameter> parameters = null
        )
            where T : IShefResponse
        {
            var request = new RestRequest(path, Method.GET);
            if (parameters == null) return MakeRequest<T>(request);
            foreach (var param in parameters)
            {
                request.AddParameter(param);
            }
            return MakeRequest<T>(request);
        }

    }
}
