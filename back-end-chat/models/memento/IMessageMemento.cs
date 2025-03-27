namespace models.memento;

public interface IMessageMemento
{
    string GetSavedMessage();
    DateTime GetTimestamp();
}