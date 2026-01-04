namespace aireports.Modules.AI.Domain.Interfaces;

public interface IAiClient
{
    Task<string> Ask(string prompt);
}