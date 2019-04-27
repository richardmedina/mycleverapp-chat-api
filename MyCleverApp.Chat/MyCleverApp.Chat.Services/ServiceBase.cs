using MyCleverApp.Chat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Services
{
    public class ServiceBase
    {
        protected virtual ServiceResult<TResult> GetSuccessResult<TResult> (ServiceRequest request, TResult result)
        {
            return new ServiceResult<TResult>
            {
                Result = result,
                Request = request,
                StatusCode = StatusCodeType.Success,
                ProcessedDateTime = DateTime.UtcNow
            };
        }

        protected virtual ServiceResult<TResult> GetFailedResult<TResult>(ServiceRequest request, params ErrorMessage [] errorMessages)
        {
            return new ServiceResult<TResult>
            {
                Request = request,
                ErrorMessages = errorMessages,
                ProcessedDateTime = DateTime.Now
            };
        }
    }
}
