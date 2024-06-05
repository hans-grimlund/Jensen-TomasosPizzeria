namespace TomasosPizzeria.UseCases.Interfaces;

public interface IErrorHandler
{
    void LogError(Exception e);
}