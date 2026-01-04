using aireports.Modules.AI.Application.Services;
using aireports.Modules.AI.Domain.Interfaces;

public class AskAiHandler
{
    private readonly IAiClient _client;

    public AskAiHandler(IAiClient client)
    {
        _client = client;
    }

    public async Task<AskAiResult> Handle(AskAiCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Prompt))
            throw new AiException("Prompt is empty");

        var answer = await _client.Ask(command.Prompt);

        return new AskAiResult(answer);
    }
}