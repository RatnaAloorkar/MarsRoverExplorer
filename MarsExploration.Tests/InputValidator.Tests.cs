using MarsExploration.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsExploration.Tests
{
    [TestClass]
    public class InputValidatorTests
    {
        #region Plateau input validator tests

        [DataRow("123")]
        [DataRow("ABCD")]
        [DataRow("123ABCD")]
        [DataRow("ABCD efg")]
        [DataRow("ABCD 123")]
        [DataRow("-2 3")]
        [DataRow("2 -3")]
        [DataRow("-2 -3")]
        [DataRow("0 3")]
        [DataRow("3 0")]
        [DataRow("0 0")]
        [TestMethod]
        public void IsPlateauDimensionFormatValidTest_InvalidInput(string userInput)
        {
            //Arrange
            InputValidator validator = new InputValidator();

            //Act
            bool isValid = validator.IsPlateauDimensionFormatValid(userInput);

            //Assert
            Assert.AreEqual(isValid, false);
        }

        [DataRow("5 5")]
        [TestMethod]
        public void IsPlateauDimensionFormatValidTest_ValidInput(string userInput)
        {
            //Arrange
            InputValidator validator = new InputValidator();

            //Act
            bool isValid = validator.IsPlateauDimensionFormatValid(userInput);

            //Assert
            Assert.AreEqual(isValid, true);
        }

        #endregion

        #region Rover input validator tests

        [DataRow("123")]
        [DataRow("abcd")]
        [DataRow("1 2")]
        [DataRow("A C")]
        [DataRow("1 C")]
        [DataRow("1 B C")]
        [DataRow("1 2 3")]
        [DataRow("A B C")]
        [DataRow("-1 -2 N")]
        [DataRow("1 -2 N")]
        [DataRow("1 2 North")]
        [DataRow("1 2 T")]
        [DataRow("6 6 N")]
        [DataTestMethod]
        public void IsRoverPositionFormatValidTest_InvalidInput(string userInput)
        {
            //Arrange
            PlateauGridDimensions.x = 5;
            PlateauGridDimensions.y = 5;
            InputValidator validator = new InputValidator();

            //Act
            bool isValid = validator.IsRoverPositionFormatValid(userInput);

            //Assert
            Assert.AreEqual(isValid, false);
        }

        [DataRow("0 0 N")]
        [DataRow("2 3 N")]
        [DataRow("2 3 S")]
        [DataRow("2 3 W")]
        [DataRow("2 3 E")]
        [TestMethod]
        public void IsRoverPositionFormatValidTest_ValidInput(string userInput)
        {
            //Arrange
            InputValidator validator = new InputValidator();

            //Act
            bool isValid = validator.IsRoverPositionFormatValid(userInput);

            //Assert
            Assert.AreEqual(isValid, true);
        }

        #endregion

        #region Instructions input validator tests

        [DataRow("6324234")]
        [DataRow("abcdefgh")]
        [DataRow("@#$@#@#$")]
        [DataTestMethod]
        public void IsInstructionsFormatValidTest_InvalidInput(string userInput)
        {
            //Arrange
            InputValidator validator = new InputValidator();

            //Act
            bool isValid = validator.IsInstructionsFormatValid(userInput);

            //Assert
            Assert.AreEqual(isValid, false);
        }

        [DataRow("LMMRMMRLL")]
        [DataTestMethod]
        public void IsInstructionsFormatValidTest_ValidInput(string userInput)
        {
            //Arrange
            InputValidator validator = new InputValidator();

            //Act
            bool isValid = validator.IsInstructionsFormatValid(userInput);

            //Assert
            Assert.AreEqual(isValid, true);
        }

        #endregion
    }
}
