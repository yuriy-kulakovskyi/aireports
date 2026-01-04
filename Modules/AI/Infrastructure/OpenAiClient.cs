using aireports.Modules.AI.Domain.Interfaces;

public class MockAiClient : IAiClient
{
    public Task<string> Ask(string prompt)
    {
        return Task.FromResult($"[MOCK RESPONSE] You asked: {prompt}");
    }
}