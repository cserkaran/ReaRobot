using ReaRobot.Model;

namespace ReaRobot.Commands
{
    /// <summary>
    /// Command to place the robot in an initial configuration
    /// </summary>
    /// <seealso cref="ReaRobot.Commands.AbstractBaseCommand" />
    public class PlaceCommand : AbstractBaseCommand
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly Configuration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaceCommand"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public PlaceCommand(Configuration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaceCommand"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="direction">The direction.</param>
        public PlaceCommand(int x,int y,Direction direction) : this(new Configuration(x,y,direction))
        {
        }

        /// <summary>
        /// Applies the transformation.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The new configuration after transformation.</returns>
        protected override Configuration ApplyInternal(Configuration input)
        {
            return configuration;
        }
    }
}
