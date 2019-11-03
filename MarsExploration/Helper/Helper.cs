using MarsExploration.Models;
using System;

namespace MarsExploration
{
    public class Helper
    {
        /// <summary>
        /// It extracts rover position from user input. THIS METHOD ASSUMES THAT THE INPUT SENT TO IT IS IN VALID FORMAT.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public RoverPosition ExtractRoverPositionFromUserInput(string userInput)
        {
            RoverPosition roverPosition = new RoverPosition();
            string[] splitString = userInput.Split(' ');
            string roverXInString = splitString[0];
            int roverX;
            Int32.TryParse(roverXInString, out roverX);
            roverPosition.x = roverX;
            
            string roverYInString = splitString[1];
            int roverY;
            Int32.TryParse(roverYInString, out roverY);
            roverPosition.y = roverY;
            
            string roverDirection = splitString[2];
            Direction direction;
            Enum.TryParse(roverDirection, out direction);
            roverPosition.direction = direction;
            return roverPosition;
        }

        /// <summary>
        /// Extract Plateau Dimensions From User Input. THIS METHOD ASSUMES THAT THE INPUT SENT TO IT IS IN VALID FORMAT.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public Coordinates ExtractPlateauDimensionsFromUserInput(string userInput)
        {
            Coordinates coordinates = new Coordinates();

            string[] splitString = userInput.Split(' ');
            string plateauXInString = splitString[0];
            int plateauX;
            Int32.TryParse(plateauXInString, out plateauX);
            coordinates.x = plateauX;
                    
            string plateauYInString = splitString[1];
            int plateauY;
            Int32.TryParse(plateauYInString, out plateauY);
            coordinates.y = plateauY;

            return coordinates;
        }
    }
}
