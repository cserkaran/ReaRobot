using System;
using System.Drawing;

namespace ReaRobot.Model
{
    /// <summary>
    /// Immutable data object representing a position and direction.
    /// </summary>
    public class Configuration
    {
        private readonly Direction _direction;

        private readonly Point _position;

        public Configuration(int x, int y, Direction orientation)
        {
            _direction = orientation;
            _position = new Point(x, y);
        }

        public Configuration(Point position, Direction orientation)
        {
            _direction = orientation;
            _position = position;
        }

        public Direction Direction()
        {
            return _direction;
        }

        public Point Position()
        {
            return _position;
        }


        public override int GetHashCode()
        {
            int result = 77;
            result = 31 * result + this.Direction().GetHashCode();
            result = 31 * result + this.Position().GetHashCode();
            return result;
        }


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


        public override String ToString()
        {
            return Position() + "," + Direction();
        }
    }
}
