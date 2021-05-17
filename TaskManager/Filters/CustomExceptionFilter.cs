using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Net;

namespace TaskManager.Filters
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            string message = String.Empty;
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            if(actionExecutedContext.Exception is UnauthorizedAccessException)
            {
                message = "Unauthorized access to the Web API.";
                status = HttpStatusCode.Unauthorized;
            }
            else if(actionExecutedContext.Exception is NotImplementedException)
            {
                message = "Not implemented Action.";
                status = HttpStatusCode.NotImplemented;
            }
            else
            {
                message = "The resource can not be found. Check Your requested input.";
                status = HttpStatusCode.NotFound;
            }


            //set up the exception response
            actionExecutedContext.Response = new HttpResponseMessage()
            {
                Content = new StringContent(message),
                StatusCode = status
            };

        }

    }
}