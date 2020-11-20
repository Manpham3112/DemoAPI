using System.Net;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Volo.Abp.Authorization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.EventBus;
using Volo.Abp.Validation;

namespace SaleManagement.Filters
{
    public class ExceptionFilter : IExceptionFilter, ITransientDependency
    {
        public ILogger Logger { get; set; }

        public IEventBus EventBus { get; set; }

        public ExceptionFilter()
        {
            Logger = NullLogger.Instance;
        }

        public void OnException(ExceptionContext context)
        {
            HandleException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Logger.Debug($"Exception filter handling: ", context.Exception);

            context.HttpContext.Response.StatusCode = (int)GetStatusCode(context);

            context.Result = new ObjectResult(new
            {
                Code = GetResponseCode(context),
                TraceId = context.HttpContext.TraceIdentifier
            });


            context.Exception = null; // Handled!
        }

        private HttpStatusCode GetStatusCode(ExceptionContext context)
        {
            if (context.Exception is HttpStatusCodeException)
            {
                var exception = context.Exception as HttpStatusCodeException;
                return exception.HttpStatusCode;
            }

            if (context.Exception is AbpAuthorizationException)
            {
                return context.HttpContext.User.Identity.IsAuthenticated
                    ? HttpStatusCode.Forbidden
                    : HttpStatusCode.Unauthorized;
            }

            if (context.Exception is AbpValidationException)
            {
                return HttpStatusCode.BadRequest;
            }

            if (context.Exception is EntityNotFoundException)
            {
                return HttpStatusCode.NotFound;
            }

            return HttpStatusCode.InternalServerError;
        }

        private int GetResponseCode(ExceptionContext context)
        {
            if (context.Exception is HttpStatusCodeException)
            {
                var exception = context.Exception as HttpStatusCodeException;
                var code = exception.ApplicationCode;

                if (code > 0)
                {
                    return code;
                }
                else
                {
                    return (int)GetStatusCode(context);
                }
            }

            return 0;
        }
    }
}
