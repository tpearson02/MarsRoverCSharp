using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover rover1 = new Rover(0);
            Assert.AreEqual(rover1.Position, 0);
        }
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover rover1 = new Rover(0);
            Assert.AreEqual(rover1.Mode, "NORMAL");
        }
        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover rover1 = new Rover(0);
            Assert.AreEqual(rover1.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        { 
            Command[] command1 = { new Command("MODE_CHANGE", "LOW_POWER") };
            Message newMessage = new Message("Test message", command1);
            Rover newRover = new Rover(0);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Mode, "LOW_POWER");
        }
        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Command[] command1 = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 3456) };
            Message newMessage = new Message("Test message", command1);
            Rover newRover = new Rover(0);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Position, 0);
        }
        [TestMethod]
        public void PositonChangesFromMoveCommand()
        {
            Command[] command1 = { new Command("MODE_CHANGE", "NORMAL"), new Command("MOVE", 3456) };
            Message newMessage = new Message("Test message", command1);
            Rover newRover = new Rover(0);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(3456, newRover.Position);
        }
    }
    

}
