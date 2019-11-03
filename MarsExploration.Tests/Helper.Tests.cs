using MarsExploration.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsExploration.Tests
{
    [TestClass]
    public class HelperTests
    {
        #region ExtractRoverPositionFromUserInput Tests
        
        [TestMethod]
        public void ExtractRoverPositionFromUserInputTest_N()
        {
            //Arrange
            Helper helper = new Helper();

            //Act
            RoverPosition result = helper.ExtractRoverPositionFromUserInput("1 2 N");

            //Assert
            RoverPosition expectedResult = new RoverPosition(1, 2, Direction.N);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ExtractRoverPositionFromUserInputTest_S()
        {
            //Arrange
            Helper helper = new Helper();

            //Act
            RoverPosition result = helper.ExtractRoverPositionFromUserInput("1 2 S");

            //Assert
            RoverPosition expectedResult = new RoverPosition(1, 2, Direction.S);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ExtractRoverPositionFromUserInputTest_W()
        {
            //Arrange
            Helper helper = new Helper();

            //Act
            RoverPosition result = helper.ExtractRoverPositionFromUserInput("1 2 W");

            //Assert
            RoverPosition expectedResult = new RoverPosition(1, 2, Direction.W);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ExtractRoverPositionFromUserInputTest_E()
        {
            //Arrange
            Helper helper = new Helper();

            //Act
            RoverPosition result = helper.ExtractRoverPositionFromUserInput("1 2 E");

            //Assert
            RoverPosition expectedResult = new RoverPosition(1, 2, Direction.E);
            Assert.AreEqual(result, expectedResult);
        }

        #endregion

        #region ExtractPlateauDimensionsFromUserInput Tests

        [TestMethod]
        public void ExtractPlateauDimensionsFromUserInputTest_ValidInput()
        {
            //Arrange
            Helper helper = new Helper();

            //Act
            Coordinates result = helper.ExtractPlateauDimensionsFromUserInput("6 6");

            //Assert
            Coordinates expectedResult = new Coordinates(6, 6);
            Assert.AreEqual(result, expectedResult);
        }

        #endregion

    }
}
