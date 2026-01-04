namespace aireports.Modules.AI.Application.Services;

public class AskAiResult
{
    public string Answer { get; }

    public AskAiResult(string answer)
    {
        Answer = answer;
    }
}