namespace models.mediator
{
    public interface IChatMediator
    {
        void RegisterUser(User user);
        void SendMessage(string message, User sender);
        void BroadcastMessage(string message, User sender);
    }
}