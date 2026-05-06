// using Company.Core.Interfaces;
// using Company.Domain.Dto;

// namespace Company.Api.Endpoints;

// public static class EmailEndpoints
// {
//         public static WebApplication MapEmailEndpoints(this WebApplication app)
//         {
//             var groupEmailEndpoints = app.MapGroup("/email");
//             groupEmailEndpoints.MapPost("/send", SendEmail);
//             return app;
        
//         }

//         public static async Task<IResult> SendEmail(IEmailService emailService, EmailBuilderDto emailBuilder)
//         {
           
           
//             await emailService.SendEmailAsync(emailBuilder);
//             return Results.Ok();
//         }

// }