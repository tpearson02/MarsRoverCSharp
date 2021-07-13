using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                Message message = new Message("", commands);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "A Message name is required.");
            }
        }
        [TestMethod]
        public void ConstructorSetsName()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 500) };
            Message newMessage = new Message("Test message with two commands", commands);
            Assert.AreEqual(newMessage.Name, "Test message with two commands");
        }
        [TestMethod]
        public void ConstructorSetsCommandField()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 500) };
            Message newMessage = new Message("Test message", commands);
            Assert.AreEqual(newMessage.Commands, commands);
        }

    }
}
