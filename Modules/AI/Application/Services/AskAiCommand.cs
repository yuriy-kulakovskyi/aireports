namespace aireports.Modules.AI.Application.Services;

public class AskAiCommand
{
    public string Prompt { get; }

    public AskAiCommand(string prompt)
    {
        Prompt = prompt;
    }
}