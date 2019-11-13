namespace MoreHumanSoftware.Chat.API.Controllers
{
    public interface IMessageFactory
    {
        Message Create(ReceivedMessage receivedMessage);
    }
}