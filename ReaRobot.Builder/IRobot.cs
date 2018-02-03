using ReaRobot.Commands;
using ReaRobot.Model;
using System.Drawing;

namespace ReaRobot.Builder
{
    /// <summary>
    /// Robot for simulation.
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Applies the specified command and transitions the robot configuration.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns><see cref="Transition"/>Robot transition from one command to another.</returns>
        Transition Apply(AbstractBaseCommand command);

        /// <summary>
        /// Current Robot Configuration.
        /// </summary>
        /// <returns></returns>
        Configuration Configuration();

        /// <summary>
        /// The boundaries of the tabletop.
        /// </summary>
        /// <returns></returns>
        Point Boundary();
    }
}
