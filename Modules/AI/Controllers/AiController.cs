using aireports.Modules.AI.Application.Services;
using aireports.Modules.AI.Controllers.Contracts;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/ai")]
public class AiController : ControllerBase
{
    private readonly AskAiHandler _handler;

    public AiController(AskAiHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> Ask([FromBody] AskAiRequest request)
    {
        var result = await _handler.Handle(
            new AskAiCommand(request.Prompt)
        );

        return Ok(new AskAiResponse(result.Answer));
    }
}