using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MoreHumanSoftware.Chat.API;
using MoreHumanSoftware.Chat.API.Repositories;
using Xunit;
using Enumerable = System.Linq.Enumerable;

namespace MoreHuman.Software.Tests.Chat.API
{
    public class ChatAppBackedMessageRepositoryTests
    {
        [Fact]
        public void List_ShouldGetAListOfMessageFromTheAspClassicPage()
        {
            // Arrange
            var repo = new ChatAppBackedMessageRepository();
            var random = new Random(DateTime.Now.Millisecond);
            var expectedUsername = "Test_user" + random.Next();
            var expectedMessage = "Test_message " + random.Next();
            var message = new ReceivedMessage
            {
                Username = expectedUsername,
                Message = expectedMessage
            };

            // Act
            repo.StoreMessage(message);

            // Assert
            Thread.Sleep(TimeSpan.FromSeconds(7));
            var messages = repo.List();
            Assert.Contains(messages,
                message1 => message1.Username.Equals(expectedUsername) && message1.Text.Equals(expectedMessage));
        }

        [Fact]
        public void StoreMessage_ShouldCallTheAspClassicPage()
        {
            var repo = new ChatAppBackedMessageRepository();

            var results = repo.List();

            Assert.IsAssignableFrom<IEnumerable<Message>>(results);
        }
    }
}