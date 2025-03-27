using models.memento;

namespace models.mediator;

public class ChatMediator : IChatMediator
{
    private readonly List<User> _users = new();
    private readonly MessageHistory _messageHistory;

    public ChatMediator(MessageHistory messageHistory)
    {
        _messageHistory = messageHistory;
    }

    public void RegisterUser(User user) => _users.Add(user);

    public void SendMessage(string message, User sender)
    {
        var messageWithTimestamp = $"[{DateTime.Now:HH:mm:ss}] {sender.Name}: {message}";
        _messageHistory.SaveMessage(messageWithTimestamp);
        
        foreach (var user in _users.Where(u => u != sender))
        {
            user.Receive(messageWithTimestamp);
        }
    }

    public void BroadcastMessage(string message, User sender)
    {
        var messageWithTimestamp = $"[Broadcast {DateTime.Now:HH:mm:ss}] {sender.Name}: {message}";
        _messageHistory.SaveMessage(messageWithTimestamp);
        
        foreach (var user in _users)
        {
            user.Receive(messageWithTimestamp);
        }
    }
}