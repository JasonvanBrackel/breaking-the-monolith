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
            var messageFactory = A.Fake<IMessageFactory>();
            var fakeMessage = A.Fake<ReceivedMessage>();
            var fakeFullMessage = A.Fake<Message>();
            var controller = new MessagesController(messageRepo, messageFactory);

            A.CallTo(() => messageFactory.Create(fakeMessage)).Returns(fakeFullMessage);

            // Act
            controller.ReceiveMessage(fakeMessage);

            // Assert
            A.CallTo(() => messageRepo.StoreMessage(fakeFullMessage)).MustHaveHappened();
        }

        [Fact]
        public void GetMessages_ShouldReturnMessages()
        {
            // Arrange
            var messageRepo = A.Fake<IMessageRepository>();
            var messageFactory = A.Dummy<IMessageFactory>();
            var messages = A.Fake<IEnumerable<Message>>();
            A.CallTo(() => messageRepo.List()).Returns(messages);
            var controller = new MessagesController(messageRepo, messageFactory);
            
            // Act
            controller.GetMessages();

            // Assert
            A.CallTo(() => messageRepo.List()).MustHaveHappened();
        }
    }
}
