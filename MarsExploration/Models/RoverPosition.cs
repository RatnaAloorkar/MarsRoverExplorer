namespace MarsExploration.Models
{
    /// <summary>
    /// Represents directions - N: North, E: East, S: South, W: West
    /// </summary>
    public enum Direction
    {
        N,
        E,
        S,
        W
    }

    /// <summary>
    /// Represents rover's position
    /// </summary>
    public struct RoverPosition
    {
        public int x;
        public int y;
        public Direction direction;

        public RoverPosition(int _x, int _y, Direction _dir)
        {
            x = _x;
            y = _y;
            direction = _dir;
        }
    }
}
