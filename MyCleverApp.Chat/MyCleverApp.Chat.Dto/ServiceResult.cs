using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Dto
{
    public class ServiceResult<TResult>
    {
        public ServiceRequest Request { get; set; }
        public TResult Result;
        public DateTime ProcessedDateTime { get; set; }
        public StatusCodeType StatusCode { get; set; }
        public IEnumerable<ErrorMessage> ErrorMessages { get; set; }
    }
}
