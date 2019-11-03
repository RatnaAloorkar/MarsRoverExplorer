using MarsExploration.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsExploration.Tests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ProcessInstructionsTest_ValidInput12N()
        {
            //Arrange
            PlateauGridDimensions.x = 5;
            PlateauGridDimensions.y = 5;

            Rover rover = new Rover();
            rover.SetRoverPosition(1, 2, Direction.N);

            //Act
            rover.ProcessInstructions("LMLMLMLMM");

            //Assert
            RoverPosition expectedPosition = new RoverPosition(1, 3, Direction.N);
            Assert.AreEqual(rover.GetRoverPosition(), expectedPosition);
        }

        [TestMethod]
        public void ProcessInstructionsTest_ValidInput33E()
        {
            //Arrange
            PlateauGridDimensions.x = 5;
            PlateauGridDimensions.y = 5;

            Rover rover = new Rover();
            rover.SetRoverPosition(3, 3, Direction.E);

            //Act
            rover.ProcessInstructions("MMRMMRMRRM");

            //Assert
            RoverPosition expectedPosition = new RoverPosition(5, 1, Direction.E);
            Assert.AreEqual(rover.GetRoverPosition(), expectedPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(RoverOutOfRangeException))]
        public void ProcessInstructionsTest_OutOfBoundaryException()
        {
            //Arrange
            PlateauGridDimensions.x = 5;
            PlateauGridDimensions.y = 5;

            Rover rover = new Rover();
            rover.SetRoverPosition(5, 5, Direction.N);

            //Act
            rover.ProcessInstructions("M");
        }
    }
}
