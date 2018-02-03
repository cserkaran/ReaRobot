using ReaRobot.Commands;
using ReaRobot.Model;
using System;
using System.Drawing;

namespace ReaRobot.Builder
{
    public class Robot : IRobot
    {

        private readonly Point _boundary;

        private Configuration _configuration;

        public Robot(Configuration configuration, Point boundary)
        {
            _boundary = boundary;
            _configuration = configuration;
        }


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

        public Configuration Configuration()
        {
            return _configuration;
        }

        public Point Boundary()
        {
            return _boundary;
        }


        public override string ToString()
        {
            return "Current robot configuration: " +
                    (_configuration != null ? _configuration.ToString() : "Not placed yet");
        }

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
