using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreHumanSoftware.Chat.API.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> List();
        void StoreMessage(ReceivedMessage message);
    }
}
