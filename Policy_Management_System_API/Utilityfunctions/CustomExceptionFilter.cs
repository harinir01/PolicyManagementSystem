using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
// using System.Web.Http.Filters;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Mvc.Filters;

namespace Policy_Management_System_API
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errorMsg = string.Empty;
            var exceptionType = context.Exception.GetType();
            var stackTrace = String.Empty;
            if (exceptionType == typeof(NullReferenceException))
            {
                errorMsg = context.Exception.Message;
                statusCode = HttpStatusCode.NotFound;
                stackTrace = context.Exception.StackTrace;
            }
            else if (exceptionType == typeof(ArgumentNullException))
            {
                errorMsg = context.Exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = context.Exception.StackTrace;
            }
            else if (exceptionType == typeof(BadHttpRequestException))
            {
                errorMsg = context.Exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = context.Exception.StackTrace;
            } else if (exceptionType == typeof(ValidationException))
            {
                errorMsg = context.Exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = context.Exception.StackTrace;
            }else if (exceptionType == typeof(ArgumentException))
            {
                errorMsg = context.Exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = context.Exception.StackTrace;
            }
             else
            {
                errorMsg = context.Exception.Message;
                statusCode = HttpStatusCode.InternalServerError;
                stackTrace = context.Exception.StackTrace;
            }
            // var exceptionResult = JsonSerializer.Serialize(new {
            //     error = errorMsg,statusCode, stackTrace
            // var response = new HttpResponseMessage(statusCode)
            // {
            //     Content = new StringContent(errorMsg),
            //     ReasonPhrase = "From Exception Filter"
            // };
            // context.Response.StatusCode = (HttpStatusCode)(int)statusCode;
            // context.Response = response;
            // return context.Response.response;
            // base.OnException(context);
            context.Result=new ObjectResult(errorMsg)
            {
                StatusCode=(int)statusCode
                
            };
        }
    }
}

// var response=new HttpResponseMessage(statusCode){
//     Content=new StringContent(errorMsg),
//     ReasonPhrase="From Exception Filter"