using Microsoft.AspNetCore.Mvc;
using models;
using models.dtos;
using models.mediator;
using models.memento;

namespace ChatApp.Backend.Controllers;

[ApiController]
[Route("demo-chat")]
public class ChatController : ControllerBase
{
    private readonly IChatMediator _mediator;
    private readonly MessageHistory _messageHistory;

    public ChatController(IChatMediator mediator, MessageHistory messageHistory)
    {
        _mediator = mediator;
        _messageHistory = messageHistory;
    }

    [HttpPost("send")]
    public IActionResult SendMessage([FromBody] ChatMessageDto messageDto)
    {
        var user = new User(messageDto.SenderName, _mediator);
        user.Send(messageDto.Message);
        return Ok();
    }

    [HttpPost("broadcast")]
    public IActionResult BroadcastMessage([FromBody] ChatMessageDto messageDto)
    {
        var user = new User(messageDto.SenderName, _mediator);
        user.Broadcast(messageDto.Message);
        return Ok();
    }

    [HttpGet("history")]
    public IActionResult GetMessageHistory()
    {
        return Ok(_messageHistory.GetFullHistory());
    }

    [HttpPost("undo")]
    public IActionResult UndoLastMessage()
    {
        var memento = _messageHistory.UndoLastMessage();
        return memento == null 
            ? NotFound("No messages to undo") 
            : Ok($"Undid message: {memento.GetSavedMessage()}");
    }
}