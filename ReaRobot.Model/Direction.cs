using System;

namespace ReaRobot.Model
{
    /// <summary>
    /// The Direction enum encapsulating all four directions
    /// </summary>
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public static class OrientationExtensions
    {
        /// <summary>
        /// Rotate left from current direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>Direction after rotating left</returns>
        /// <exception cref="InvalidOperationException">Direction unknown: " + direction</exception>
        public static Direction Left(this Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return Direction.WEST;
                case Direction.EAST:
                    return Direction.NORTH;
                case Direction.SOUTH:
                    return Direction.EAST;
                case Direction.WEST:
                    return Direction.SOUTH;
                default:
                    throw new InvalidOperationException("Direction unknown: " + direction);
            }
        }

        /// <summary>
        /// Rotate right from current direction
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>Direction after rotating right</returns>
        /// <exception cref="InvalidOperationException">Direction unknown: " + direction</exception>
        public static Direction Right(this Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return Direction.EAST;
                case Direction.EAST:
                    return Direction.SOUTH;
                case Direction.SOUTH:
                    return Direction.WEST;
                case Direction.WEST:
                    return Direction.NORTH;
                default:
                    throw new InvalidOperationException("Direction unknown: " + direction);
            }
        }
    }
}
