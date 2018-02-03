using ReaRobot.Model;
using System;
using System.Drawing;

namespace ReaRobot.Builder
{
    /// <summary>
    /// Builder to create the toy robot for the simulator.
    /// </summary>
    public class RobotBuilder
    {
        /// <summary>
        /// The boundary
        /// </summary>
        private Point _boundary;

        /// <summary>
        /// The configuration
        /// </summary>
        private Configuration _configuration;

        /// <summary>
        /// Optional initial configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public RobotBuilder OptionalInitialConfiguration(Configuration configuration)
        {
            _configuration = configuration;
            return this;
        }

        /// <summary>
        /// Optional initial configuration.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public RobotBuilder OptionalInitialConfiguration(Point position, Direction direction)
        {
            OptionalInitialConfiguration(new Configuration(position, direction));
            return this;
        }

        /// <summary>
        /// Set the mandatory boundary to avoid robot falling off.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public RobotBuilder MandatoryNorthEastBoundary(Point position)
        {
            _boundary = position;
            return this;
        }

        /// <summary>
        /// Builds the robot.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">No boundaries for movement are set.</exception>
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
