using models.mediator;

namespace models;
public class User
{
    public string Name { get; }
    private readonly IChatMediator _mediator;

    public User(string name, IChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
        mediator.RegisterUser(this);
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        _mediator.SendMessage(message, this);
    }

    public void Broadcast(string message)
    {
        Console.WriteLine($"{Name} broadcasts: {message}");
        _mediator.BroadcastMessage(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} receives: {message}");
    }
}