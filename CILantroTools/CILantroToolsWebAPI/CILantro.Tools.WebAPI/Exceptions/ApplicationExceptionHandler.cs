using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace CILantro.Tools.WebAPI.Exceptions
{
    public class ApplicationExceptionHandler : ExceptionHandler
    {
        public ApplicationExceptionHandler()
        {
        }

        public async override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var innerExceptionMessage = context.ExceptionContext.Exception.InnerException != null ? "\n\nInner exception:\n" + context.ExceptionContext.Exception.InnerException : string.Empty;

            context.Result = new TextPlainInternalServerErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = context.ExceptionContext.Exception.Message + innerExceptionMessage
            };
        }

        private class TextPlainInternalServerErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }
    }
}