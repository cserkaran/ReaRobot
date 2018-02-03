using ReaRobot.Model;

namespace ReaRobot.Commands
{
    /// <summary>
    /// Command to report the current configuration
    /// </summary>
    /// <seealso cref="ReaRobot.Commands.AbstractBaseCommand" />
    public class ReportCommand : AbstractBaseCommand
    {
        /// <summary>
        /// Applies the transformation.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The new configuration after transformation.</returns>
        protected override Configuration ApplyInternal(Configuration input)
        {
            return input;
        }
    }
}
