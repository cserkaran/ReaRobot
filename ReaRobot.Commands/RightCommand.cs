using ReaRobot.Model;

namespace ReaRobot.Commands
{
    /// <summary>
    ///  Command to change robot direction to right.
    /// </summary>
    /// <seealso cref="ReaRobot.Commands.AbstractBaseCommand" />
    public class RightCommand : AbstractBaseCommand
    {
        /// <summary>
        /// Applies the transformation.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The new configuration after transformation.</returns>
        protected override Configuration ApplyInternal(Configuration input)
        {
            return new Configuration(input.Position(), input.Direction().Right());
        }
    }
}
