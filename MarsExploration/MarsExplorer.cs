using System;
using MarsExploration.Interfaces;
using MarsExploration.Models;

namespace MarsExploration
{
    /// <summary>
    /// This class handles the logic of Mars Exploration
    /// </summary>
    public class MarsExplorer
    {
        public IRover rover1, rover2;
        public MarsExplorer(IRover _iRover1, IRover _iRover2)
        {
            rover1 = _iRover1;
            rover2 = _iRover2;
        }

        // Application starting point
        public void Run()
        {
            //Plateau grid creation
            DividePlateauInGrid();

            //Rover 1 
            //Setting initial position
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~ Rover 1 ~~~~~~~~~~~~~~~");
            rover1 = SetRoverPosition();

            //Getting and processing instructions
            ProcessInstructions(rover1);

            //Rover 2
            //Setting initial position
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~ Rover 2 ~~~~~~~~~~~~~~~");
            rover2 = SetRoverPosition();

            //Getting and processing instructions
            ProcessInstructions(rover2);

            //Results     
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~ Final Rover Positions ~~~~~~~~~~~~~~~");
            Console.WriteLine("Rover 1: " + rover1.GetRoverPositionInStringFormat());
            Console.WriteLine("Rover 2: " + rover2.GetRoverPositionInStringFormat());
            Console.ReadLine();
        }

        /// <summary>
        /// This method asks for user input for grid dimensions, checks the format of the user input and sets the plateau dimensions
        /// </summary>
        private void DividePlateauInGrid()
        {
            Program program = new Program();
            InputValidator validator = new InputValidator();
            Helper helper = new Helper();

            //Get user input
            Console.WriteLine("~~~~~~~~~ MARS EXPLORATION ~~~~~~~~~");
            Console.WriteLine("LET'S DIVIDE THE PLATEAU INTO GRID.");
            Console.WriteLine("ENTER MAXIMUM X AND Y CO-ORDINATES OF THE GRID IN THE FORMAT SUCH AS 5 5:");
            string enteredPlateauDimentions = Console.ReadLine();

            //Check format
            bool isValid = validator.IsPlateauDimensionFormatValid(enteredPlateauDimentions);

            while (!isValid)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! Please enter in valid format:");
                Console.WriteLine("(Valid format: number number");
                Console.WriteLine("Valid numbers: greater than zero)");
                enteredPlateauDimentions = Console.ReadLine();
                isValid = validator.IsPlateauDimensionFormatValid(enteredPlateauDimentions);
            }

            //Set grid dimensions
            Coordinates coordinates = helper.ExtractPlateauDimensionsFromUserInput(enteredPlateauDimentions);

            PlateauGridDimensions.x = coordinates.x;
            PlateauGridDimensions.y = coordinates.y;

            Console.WriteLine();
            Console.WriteLine("THE PLATEAU IS DIVIDED INTO A " + PlateauGridDimensions.x + " x " + PlateauGridDimensions.y + " GRID");
        }

        /// <summary>
        /// This method asks for user input for initial rover position, checks the format of user input and sets the initial rover position
        /// </summary>
        /// <returns></returns>
        private Rover SetRoverPosition()
        {
            //Get user input
            Program program = new Program();
            Helper helper = new Helper();
            Console.WriteLine("ENTER ROVER'S INITIAL POSITION IN THE FORMAT SUCH AS 1 2 N:");
            Console.WriteLine("(Note: 1 is x co-ordinate, 2 is y co-ordinate and N is the rover's facing direction.");
            Console.WriteLine("Valid values for direction: N, S, W, E)");
            string enteredRoverPosition = Console.ReadLine();

            //Check format
            InputValidator validator = new InputValidator();
            bool isValid = validator.IsRoverPositionFormatValid(enteredRoverPosition);

            while (!isValid)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! Please enter in valid format:");
                Console.WriteLine("(Valid values: ");
                Console.WriteLine("For x co-ordinate: Numbers which fall in the grid");
                Console.WriteLine("For y co-ordinate: Numbers which fall in the grid");
                Console.WriteLine("For direction: N, S, E, W)");
                enteredRoverPosition = Console.ReadLine();
                isValid = validator.IsRoverPositionFormatValid(enteredRoverPosition);
            }

            //Set rover position
            RoverPosition position = helper.ExtractRoverPositionFromUserInput(enteredRoverPosition);
            Rover rover = new Rover();
            rover.SetRoverPosition(position.x, position.y, position.direction);

            return rover;
        }

        /// <summary>
        /// This method accepts user instructions, checks validity of user instructions and moves the rover according to them
        /// </summary>
        /// <param name="rover"></param>
        /// <returns></returns>
        private void ProcessInstructions(IRover rover)
        {
            //Get user input
            Console.WriteLine();
            Console.WriteLine("ENTER INSTRUCTIONS FOR THE ROVER TO MOVE ON THE PLATEAU:");
            Console.WriteLine("(Note: Use L to turn left, R to turn right, M to move one position ahead in the direction of facing)");

            string enteredInstructions = Console.ReadLine().ToUpper();

            //Check format
            InputValidator validator = new InputValidator();
            bool isValid = validator.IsInstructionsFormatValid(enteredInstructions);

            while (!isValid)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR! Please enter in valid format:");
                Console.WriteLine("(Valid values: series of characters containing only L,R and M)");
                enteredInstructions = Console.ReadLine();
                isValid = validator.IsInstructionsFormatValid(enteredInstructions);
            }

            try
            {
                //Process instructions
                rover.ProcessInstructions(enteredInstructions);
            }
            catch (RoverOutOfRangeException ex)
            {
                Console.WriteLine("Operation aborted!! Rover is at the edge, can not move ahead.");
            }
        }
    }
}
