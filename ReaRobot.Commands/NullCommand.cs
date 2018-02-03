using ReaRobot.Model;

namespace ReaRobot.Commands
{
    /// <summary>
    /// Returns the unmodified input, thus causes no configuration change.
    /// Used as null-object in fault cases.
    /// </summary>
    /// <seealso cref="ReaRobot.Commands.AbstractBaseCommand" />
    public class NullCommand : AbstractBaseCommand
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
