namespace aireports.Modules.AI.Controllers.Contracts;

public class AskAiResponse
{
    public AskAiResponse(string answer)
    {
        Answer = answer;
    }
    
    public string Answer { get; init; } = null!;
}