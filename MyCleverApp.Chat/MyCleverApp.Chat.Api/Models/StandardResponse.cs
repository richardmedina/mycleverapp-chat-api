using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyCleverApp.Chat.Api.Models
{
    public class StandardResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
