namespace Shef
{
    public partial class Api
    {
        public Server Server { get; }

        public Api(string host, string port)
        {
            Server = new Server(host, port);
        }

 

    }
}
