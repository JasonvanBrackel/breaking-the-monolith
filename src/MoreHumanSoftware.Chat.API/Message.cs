using System;

namespace MoreHumanSoftware.Chat.API
{
    public class Message
    {
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }

        public string Text { get; set; }
    }
}