using ReaRobot.Model;
using System;
using System.Drawing;

namespace ReaRobot.Builder
{
    public class RobotBuilder
    {
        private Point _boundary;
        private Configuration _configuration;

        public RobotBuilder OptionalInitialConfiguration(Configuration configuration)
        {
            _configuration = configuration;
            return this;
        }

        public RobotBuilder OptionalInitialConfiguration(Point position, Direction direction)
        {
            OptionalInitialConfiguration(new Configuration(position, direction));
            return this;
        }

        public RobotBuilder MandatoryNorthEastBoundary(Point position)
        {
            _boundary = position;
            return this;
        }

        public Robot Build()
        {
            if (_boundary == null)
            {
                throw new InvalidOperationException("No boundaries for movement are set.");
            }
            return new Robot(_configuration, _boundary);
        }
    }
}
