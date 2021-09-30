using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MongoDB.Driver;
using ProjectSharp.WebApi.Common.Exceptions;

namespace ProjectSharp.WebApi.Common.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            switch (exception)
            {
                case MongoConfigurationException:
                    await SendResponse(httpContext, (int)HttpStatusCode.InternalServerError, 
                        "Mongodb configuration error, have you set up appsettings.json?");
                    break;
                case TimeoutException:
                    await SendResponse(httpContext, (int)HttpStatusCode.InternalServerError, 
                        "Server timed out check MongoDb");
                    break;
                case RequestValidationException:
                    await SendResponse(httpContext, (int)HttpStatusCode.BadRequest, 
                        exception.Message, true);
                    break;
                case ApplicationUserCredentialsException:
                    await SendResponse(httpContext, (int)HttpStatusCode.Forbidden, 
                        exception.Message, false);
                    break;
                default:
                    await SendResponse(httpContext, (int)HttpStatusCode.InternalServerError, "Unknown Error");
                    break;
            }
        }

        private async Task SendResponse(HttpContext httpContext, int statusCode , string message, bool json = false)
        {
            httpContext.Response.ContentType = json ? "application/json" : "text/plain";
            
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(message ?? "No Error Message Available.");
        }
    }
}