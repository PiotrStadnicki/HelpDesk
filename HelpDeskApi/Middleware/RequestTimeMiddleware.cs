using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace HelpDeskApi.Middleware

{
    public class RequestTimeMiddleware : IMiddleware
    {
        private Stopwatch _stopwatch;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware>logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }

        public ILogger<RequestTimeMiddleware> Logger { get; }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
            if (elapsedMilliseconds / 1000 > 4)
            {
                var message = $"Request[{context.Request.Method}] at {context.Request} ms";
                _logger.LogInformation(message);
            }
        }

        
    }
}
