namespace Shef.Model.Responses
{
    public class Status
    {
        /// <summary>
        /// HTTP Status code
        /// </summary>
        public int code { get; set; }
        
        /// <summary>
        /// result of the command request. 0: success, non zero: error
        /// </summary>
        public int commandResult { get; set; }
        
        /// <summary>
        /// OK: success, otherwise an error message is returned 
        /// </summary>
        public string msg { get; set; }
        
        /// <summary>
        /// Incoming query string
        /// </summary>
        public string query { get; set; }
    }
}
