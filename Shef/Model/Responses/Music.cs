using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Shef.Model.Responses
{
    public class Music
    {
        /// <summary>
        /// Artist
        /// </summary>
        public string by { get; set; }

        /// <summary>
        /// Name of the CD
        /// </summary>
        public string cd { get; set; }

        /// <summary>
        /// Title of the song
        /// </summary>
        public string title { get; set; }

    }
}
