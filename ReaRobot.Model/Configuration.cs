using System;
using System.Drawing;

namespace ReaRobot.Model
{
    /// <summary>
    /// Immutable data object representing a position and direction.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The direction
        /// </summary>
        private readonly Direction _direction;

        /// <summary>
        /// The position
        /// </summary>
        private readonly Point _position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="orientation">The orientation.</param>
        public Configuration(int x, int y, Direction orientation)
        {
            _direction = orientation;
            _position = new Point(x, y);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="orientation">The orientation.</param>
        public Configuration(Point position, Direction orientation)
        {
            _direction = orientation;
            _position = position;
        }

        /// <summary>
        /// Direction of the configuration.
        /// </summary>
        /// <returns>Direction of the robot.</returns>
        public Direction Direction()
        {
            return _direction;
        }

        /// <summary>
        /// Current position of the robot.
        /// </summary>
        /// <returns>Position of the robot.</returns>
        public Point Position()
        {
            return _position;
        }


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            int result = 77;
            result = 31 * result + Direction().GetHashCode();
            result = 31 * result + Position().GetHashCode();
            return result;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (!(obj is Configuration))
            {
                return false;
            }
            Configuration configuration = (Configuration)obj;
            return Direction() == configuration.Direction() && Position().Equals(configuration.Position());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override String ToString()
        {
            return Position() + "," + Direction();
        }
    }
}
