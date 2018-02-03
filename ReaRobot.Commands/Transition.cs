using ReaRobot.Model;

namespace ReaRobot.Commands
{
    /// <summary>
    /// Transition state information about robot transitioning from one state to another.
    /// This can be used to store and log the transformations 
    /// and later replayed in reverse to get to the original state as well,just in case.
    /// </summary>
    public class Transition
    {
        /// <summary>
        /// Initial Configuration
        /// </summary>
        private readonly Configuration _from;

        /// <summary>
        /// Command by which the transition is happening
        /// </summary>
        private readonly AbstractBaseCommand _by;

        /// <summary>
        /// Final Configuration
        /// </summary>
        private readonly Configuration _to;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transition"/> class.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="by">The by.</param>
        /// <param name="to">To.</param>
        public Transition(Configuration from, AbstractBaseCommand by, Configuration to)
        {
            _from = from;
            _by = by;
            _to = to;
        }

        /// <summary>
        /// Initial Configuration
        /// </summary>
        /// <returns>The original configuration before transformation</returns>
        public Configuration From()
        {
            return _from;
        }

        /// <summary>
        /// Command by which the transition is happening
        /// </summary>
        public AbstractBaseCommand By()
        {
            return _by;
        }

        /// <summary>
        /// Final Configuration after transformation.
        /// </summary>
        public Configuration To()
        {
            return _to;
        }
    }
}
