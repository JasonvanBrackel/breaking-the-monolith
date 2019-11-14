using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using MoreHumanSoftware.Chat.API.Controllers;
using MoreHumanSoftware.Chat.API.Repositories;
using Xunit;
using FakeItEasy;
using MoreHumanSoftware.Chat.API;

namespace MoreHuman.Software.Tests.Chat.API
{
    public class MessageControllerTests
    {
        [Fact]
        public void ReceiveMessage_ShouldStoreTheMessage()
        {
            // Arrange
            var messageRepo = A.Fake<IMessageRepository>();
            var fakeMessage = A.Fake<ReceivedMessage>();
            var controller = new MessagesController(messageRepo);


            // Act
            controller.ReceiveMessage(fakeMessage);

            // Assert
            A.CallTo(() => messageRepo.StoreMessage(fakeMessage)).MustHaveHappened();
        }

        [Fact]
        public void GetMessages_ShouldReturnMessages()
        {
            // Arrange
            var messageRepo = A.Fake<IMessageRepository>();
            A.Dummy<IMessageFactory>();
            var messages = A.Fake<IEnumerable<Message>>();
            A.CallTo(() => messageRepo.List()).Returns(messages);
            var controller = new MessagesController(messageRepo);

            // Act
            controller.GetMessages();

            // Assert
            A.CallTo(() => messageRepo.List()).MustHaveHappened();
        }
    }
}