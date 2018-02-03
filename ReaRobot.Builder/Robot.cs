using ReaRobot.Commands;
using ReaRobot.Model;
using System;
using System.Drawing;

namespace ReaRobot.Builder
{
    /// <summary>
    /// Robot for simulation.
    /// </summary>
    public class Robot : IRobot
    {
        /// <summary>
        /// The boundary
        /// </summary>
        private readonly Point _boundary;

        /// <summary>
        /// The configuration of the robot.
        /// </summary>
        private Configuration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Robot"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="boundary">The boundary.</param>
        public Robot(Configuration configuration, Point boundary)
        {
            _boundary = boundary;
            _configuration = configuration;
        }


        /// <summary>
        /// Applies the specified command and transitions the robot configuration.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        ///   <see cref="Transition" />Robot transition from one command to another.
        /// </returns>
        public Transition Apply(AbstractBaseCommand command)
        {
            Configuration oldConfiguration = _configuration;
            Configuration newConfiguration = command.Apply(this._configuration);

            if (IsValidConfiguration(newConfiguration))
            {
                _configuration = newConfiguration;
                return new Transition(oldConfiguration, command, newConfiguration);
            }
            else
            {
                Console.WriteLine("New configuration would be invalid, not changing.");
                return new Transition(oldConfiguration, command, oldConfiguration);
            }

        }

        /// <summary>
        /// Current Robot Configuration.
        /// </summary>
        /// <returns></returns>
        public Configuration Configuration()
        {
            return _configuration;
        }

        /// <summary>
        /// The boundaries of the tabletop.
        /// </summary>
        /// <returns></returns>
        public Point Boundary()
        {
            return _boundary;
        }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Current robot configuration: " +
                    (_configuration != null ? _configuration.ToString() : "Not placed yet");
        }

        /// <summary>
        /// Determines whether the configuration to which robot is transitioning is valid or not.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>
        ///   <c>true</c> if is valid configuration otherwise, <c>false</c>.
        /// </returns>
        private bool IsValidConfiguration(Configuration configuration)
        {
            // Not being placed at all is valid.
            if (configuration == null)
            {
                return true;
            }

            // Else check boundary.
            Point position = configuration.Position();
            return position.X >= 0 &&
                    position.Y >= 0 &&
                    position.X < _boundary.X &&
                    position.Y < _boundary.Y;
        }

    }
}
