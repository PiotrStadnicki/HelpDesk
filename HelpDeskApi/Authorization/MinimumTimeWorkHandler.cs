using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HelpDeskApi.Authorization
{
    public class MinimumTimeWorkHandler : AuthorizationHandler<MinimumTimeWork>
    {
        private readonly ILogger<MinimumTimeWorkHandler> _logger;

        public  MinimumTimeWorkHandler(ILogger<MinimumTimeWorkHandler>logger)
        {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumTimeWork requirement)
        {
            var workStart = DateTime.Parse(context.User.FindFirst(c => c.Type == "WorkStart").Value);

            var userEmail = context.User.FindFirst(c => c.Type == ClaimTypes.Name).Value;
            _logger.LogInformation($"urzytkownik: {userEmail} pracujący od{workStart}");

            if (workStart.AddMonths(requirement.MinimumMounth) > DateTime.Today)
            {
                _logger.LogInformation("Posiada wymagany starz");
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogInformation("Nie posiada wymaganego starzu pracy");
            }
            return Task.CompletedTask;
        }
    }
}
