using Microsoft.AspNetCore.Mvc;
using MyCleverApp.Chat.Api.Models;
using MyCleverApp.Chat.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyCleverApp.Chat.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string GetCurrentUserName ()
        {
            return "richard";
        }

        protected StandardResponse GetResponse<TResult> (ServiceResult<object> serviceResult, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return new StandardResponse
            {
                Result = serviceResult.Result,
                Errors = serviceResult.ErrorMessages.Select(e => e.Text),
                StatusCode = GetStatusCode(serviceResult.StatusCode, httpStatusCode)
            };
        }

        protected HttpStatusCode GetStatusCode (StatusCodeType codeType, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            switch (codeType)
            {
                case StatusCodeType.Error:
                    return HttpStatusCode.InternalServerError;
                 case StatusCodeType.Success:
                    return httpStatusCode;
                default: return HttpStatusCode.OK;
            }
        }
    }
}
