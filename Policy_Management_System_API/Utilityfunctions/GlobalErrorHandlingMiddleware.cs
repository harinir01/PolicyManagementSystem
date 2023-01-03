// using System.Net;
// using System.Text.Json;
// using NotFoundException = GlobalExceptionHandling.Exceptions.NotFoundException;
// using ArgumentNullException = GlobalExceptionHandling.Exceptions.ArgumentNullException;
// using BadRequestException = GlobalExceptionHandling.Exceptions.BadRequestException;
// using ValidationException = GlobalExceptionHandling.Exceptions.ValidationException;
// namespace GlobalExceptionHandling.Utility {
//     public class GlobalErrorHandlingMiddleware {
//         private readonly RequestDelegate _next;
//         public GlobalErrorHandlingMiddleware(RequestDelegate next) {
//             _next = next;
//         }
//         public async Task Invoke(HttpContext context) {
//             try {
//                 await _next(context);
//             } catch (Exception ex) {
//                 await HandleExceptionAsync(context, ex);
//             }
//         }
//         private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
//             HttpStatusCode status;
//             var stackTrace = String.Empty;
//             string message;
//             var exceptionType = exception.GetType();
//             if (exceptionType == typeof(BadRequestException)) {
//                 message = exception.Message;
//                 status = HttpStatusCode.BadRequest;
//                 stackTrace = exception.StackTrace;
//             } else if (exceptionType == typeof(NotFoundException)) {
//                 message = exception.Message;
//                 status = HttpStatusCode.NotFound;
//                 stackTrace = exception.StackTrace;
//             } else if (exceptionType == typeof(ArgumentNullException)) {
//                 status = HttpStatusCode.BadRequest;
//                 message = exception.Message;
//                 stackTrace = exception.StackTrace;
//             } else if (exceptionType == typeof(ValidationException)) {
//                 status = HttpStatusCode.BadRequest;
//                 message = exception.Message;
//                 stackTrace = exception.StackTrace;
//             } else {
//                 status = HttpStatusCode.InternalServerError;
//                 message = exception.Message;
//                 stackTrace = exception.StackTrace;
//             }
//             var exceptionResult = JsonSerializer.Serialize(new {
//                 error = message,status, stackTrace
//             });
//             context.Response.ContentType = "application/json";
//             context.Response.StatusCode = (int) status;
//             return context.Response.WriteAsync(exceptionResult);
//         }
//     }
// }