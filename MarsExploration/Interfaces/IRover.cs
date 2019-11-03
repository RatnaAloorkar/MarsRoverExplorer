using MarsExploration.Models;

namespace MarsExploration.Interfaces
{
    public interface IRover
    {
        void SetRoverPosition(int x_coordinate, int y_coordinate, Direction facingDirection);
        RoverPosition GetRoverPosition();
        string GetRoverPositionInStringFormat();
        void ProcessInstructions(string instructions);
    }
}
