namespace models.memento;
public class MessageHistory
{
    private readonly Stack<IMessageMemento> _messageHistory = new();

    public void SaveMessage(string message)
    {
        _messageHistory.Push(new MessageMemento(message, DateTime.Now));
    }

    public IMessageMemento? UndoLastMessage()
    {
        return _messageHistory.Count == 0 ? null : _messageHistory.Pop();
    }

    public List<string> GetFullHistory()
    {
        return _messageHistory
            .OrderBy(m => m.GetTimestamp())
            .Select(m => m.GetSavedMessage())
            .ToList();
    }
}