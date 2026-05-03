using Customer.Core.Interfaces;

namespace Customer.Api.Endpoints;

public static class EmailEndpoints
{
        public static WebApplication MapEmailEndpoints(this WebApplication app)
        {
            var groupEmailEndpoints = app.MapGroup("/email");
            groupEmailEndpoints.MapPost("/send", SendEmail);
            return app;
        
        }

        public static async Task<IResult> SendEmail(IEmailService emailService, string email, string subject, string message)
        {
            await emailService.SendEmailAsync(email, subject, message);
            return Results.Ok();
        }

}