namespace models.memento;

public class MessageMemento : IMessageMemento
{
    public string Message { get; }
    public DateTime Timestamp { get; }

    public MessageMemento(string message, DateTime timestamp)
    {
        Message = message;
        Timestamp = timestamp;
    }

    public string GetSavedMessage() => Message;
    public DateTime GetTimestamp() => Timestamp;
}