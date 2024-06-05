using Microsoft.Extensions.Logging;
using TomasosPizzeria.UseCases.Interfaces;

namespace TomasosPizzeria.Infrastructure.ErrorHandler;

public class ErrorHandler : IErrorHandler
{
    private readonly ILogger<ErrorHandler> _logger;
    
    public ErrorHandler(ILogger<ErrorHandler> logger)
    {
        _logger = logger;
    }
    public void LogError(Exception e)
    {
        _logger.LogError(e.Message);
        _logger.LogInformation(e.StackTrace);
    }
}