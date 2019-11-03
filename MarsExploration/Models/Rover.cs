using MarsExploration.Interfaces;
using System;

namespace MarsExploration.Models
{
    /// <summary>
    /// Represents Rover
    /// </summary>
    public class Rover : IRover
    {
        RoverPosition roverPosition = new RoverPosition();

        #region Public Methods
        
        /// <summary>
        /// Sets rover position
        /// </summary>
        /// <param name="x_coordinate"></param>
        /// <param name="y_coordinate"></param>
        /// <param name="facingDirection"></param>
        public void SetRoverPosition(int x_coordinate, int y_coordinate, Direction facingDirection)
        {
            roverPosition.x = x_coordinate;
            roverPosition.y = y_coordinate;
            roverPosition.direction = facingDirection;
        }

        /// <summary>
        /// Gets rover position
        /// </summary>
        /// <returns></returns>
        public RoverPosition GetRoverPosition()
        {
            return this.roverPosition;
        }

        /// <summary>
        /// Gets rover position in string format
        /// </summary>
        /// <returns></returns>
        public string GetRoverPositionInStringFormat()
        {
            return this.roverPosition.x + " " + this.roverPosition.y + " " + this.roverPosition.direction;
        }

        /// <summary>
        /// Navigates rover according to instructions
        /// </summary>
        /// <param name="instructions"></param>
        public void ProcessInstructions(string instructions)
        {
            try
            {
                RoverPosition currentPosition = this.roverPosition;
                //For loop is used for better performance compared with foreach
                for (int i = 0; i < instructions.Length; i++)
                {
                    char instruction = instructions[i];
                    switch (instruction)
                    {
                        case 'L':
                            currentPosition = TurnLeft();
                            break;

                        case 'R':
                            currentPosition = TurnRight();
                            break;

                        case 'M':
                            currentPosition = MoveAheadInTheSameDirection();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Checks if the position is within the boundary of grid
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool CheckRoverIsInPlateauBoundary(RoverPosition position)
        {
            if (position.x < 0 || position.y < 0 || position.x > PlateauGridDimensions.x || position.y > PlateauGridDimensions.y)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Turns rover to the left
        /// </summary>
        /// <returns></returns>
        private RoverPosition TurnLeft()
        {
            Direction newDirection;
            Direction currentDirection = this.roverPosition.direction;
            switch (currentDirection)
            {
                case Direction.N:
                    newDirection = Direction.E;
                    break;

                case Direction.E:
                    newDirection = Direction.S;
                    break;

                case Direction.S:
                    newDirection = Direction.W;
                    break;

                case Direction.W:
                    newDirection = Direction.N;
                    break;

                default:
                    newDirection = Direction.N;
                    break;
            }

            this.roverPosition.direction = newDirection;
            return this.roverPosition;
        }

        /// <summary>
        /// Turns rover to the right
        /// </summary>
        /// <returns></returns>
        private RoverPosition TurnRight()
        {
            Direction newDirection;
            Direction currentDirection = this.roverPosition.direction;
            switch (currentDirection)
            {
                case Direction.N:
                    newDirection = Direction.E;
                    break;

                case Direction.W:
                    newDirection = Direction.N;
                    break;

                case Direction.S:
                    newDirection = Direction.W;
                    break;

                case Direction.E:
                    newDirection = Direction.S;
                    break;

                default:
                    newDirection = Direction.N;
                    break;
            }

            this.roverPosition.direction = newDirection;
            return this.roverPosition;
        }

        /// <summary>
        /// Moves rover one position ahead in the direction it is facing
        /// </summary>
        /// <returns></returns>
        private RoverPosition MoveAheadInTheSameDirection()
        {
            RoverPosition newPosition = this.roverPosition;
            Direction currentDirection = this.roverPosition.direction;

            switch (currentDirection)
            {
                case Direction.N:
                    newPosition.y += 1;
                    break;

                case Direction.E:
                    newPosition.x += 1;
                    break;

                case Direction.S:
                    newPosition.y -= 1;
                    break;

                case Direction.W:
                    newPosition.x -= 1;
                    break;

                default:
                    break;
            }

            if (CheckRoverIsInPlateauBoundary(newPosition))
            {
                this.roverPosition = newPosition;
            }
            else
            {
                throw new RoverOutOfRangeException();
            }
            return this.roverPosition;
        }

        #endregion
    }
}
