using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using PANZAPI.Exceptions;
using ProblemDetailsOptions = Hellang.Middleware.ProblemDetails.ProblemDetailsOptions;

namespace PANZAPI.Setup
{
    public class CustomExceptionOptions : IConfigureOptions<ProblemDetailsOptions>
    {
        public void Configure(ProblemDetailsOptions options)
        {
            options.Map<ForbiddenException>(ex => new ProblemDetails
            {
                Detail = ex.Message,
                Status = StatusCodes.Status403Forbidden,
                Type = $"https://httpstatuses.com/{StatusCodes.Status403Forbidden}",
                Title = ReasonPhrases.GetReasonPhrase(StatusCodes.Status403Forbidden)
            });
        }
    }
}
