using MarsExploration.Models;
using System;

namespace MarsExploration
{
    public class InputValidator
    {
        private char[] allowedDirections = new char[4] { 'N', 'E', 'S', 'W' };
        private char[] allowedMovingInstuctions = new char[3] { 'L', 'M', 'R' };

        /// <summary>
        /// Check the format of the grid dimensions entered by user
        /// </summary>
        /// <param name="enteredPlateauDimensions"></param>
        /// <returns></returns>
        public bool IsPlateauDimensionFormatValid(string enteredPlateauDimensions)
        {
            //Check if it contains space
            if (!enteredPlateauDimensions.Contains(' '))
            {
                return false;
            }

            string[] splitString = enteredPlateauDimensions.Split(' ');
            if (splitString.Length != 2)
            {
                return false;
            }

            //Check if x co-ordinate is valid digit
            string plateauXInString = splitString[0];
            int plateauX;
            if (!Int32.TryParse(plateauXInString, out plateauX))
            {
                return false;
            }

            //Check if y co-ordinate is valid digit
            string plateauYInString = splitString[1];
            int plateauY;
            if (!Int32.TryParse(plateauYInString, out plateauY))
            {
                return false;
            }

            //Check if x or y co-ordinates are equal to or less than 0
            if(plateauX <= 0 || plateauY <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the format of the rover position entered by user
        /// </summary>
        /// <param name="enteredRoverPosition"></param>
        /// <returns></returns>
        public bool IsRoverPositionFormatValid(string enteredRoverPosition)
        {
            //Check if it contains space
            if (!enteredRoverPosition.Contains(' '))
            {
                return false;
            }

            string[] splitString = enteredRoverPosition.Split(' ');
            if (splitString.Length != 3)
            {
                return false;
            }

            //Check if x co-ordinate is valid digit
            string roverXInString = splitString[0];
            int roverX;
            if (!Int32.TryParse(roverXInString, out roverX))
            {
                return false;
            }

            //Check if y co-ordinate is valid digit
            string roverYInString = splitString[1];
            int roverY;
            if (!Int32.TryParse(roverYInString, out roverY))
            {
                return false;
            }

            //Check if the x and y co-ordinates are not negative
            if (roverX < 0 || roverY < 0)
            {
                return false;
            }

            //Check if the direction is single character
            char direction;
            if (!char.TryParse(splitString[2], out direction))
            {
                return false;
            }

            //Check if the rover direction is one of the allowed directions
            string roverDirection = splitString[2];
            if (Array.IndexOf(allowedDirections, direction) == -1)
            {
                return false;
            }
  
            if (PlateauGridDimensions.x < roverX || PlateauGridDimensions.y < roverY)
                return false;

            return true;
        }

        /// <summary>
        /// Checks the format of the instructions entered by user
        /// </summary>
        /// <param name="enteredInstructions"></param>
        /// <returns></returns>
        public bool IsInstructionsFormatValid(string enteredInstructions)
        {
            //For loop is used for better performance compared with foreach
            //This should ideally be handled using Regular expression
            for (int i = 0; i < enteredInstructions.Length; i++)
            {
                //Check if each instruction is one of the allowed instructions
                if (Array.IndexOf(allowedMovingInstuctions, enteredInstructions[i]) <= -1)
                {
                    return false;
                }               
            }
            return true;
        }
    }
}
