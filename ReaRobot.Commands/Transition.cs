using ReaRobot.Model;

namespace ReaRobot.Commands
{
    public class Transition
    {
        private readonly Configuration _from;
        private readonly AbstractBaseCommand _by;
        private readonly Configuration _to;

        public Transition(Configuration from, AbstractBaseCommand by, Configuration to)
        {
            _from = from;
            _by = by;
            _to = to;
        }

        public Configuration From()
        {
            return _from;
        }

        public AbstractBaseCommand By()
        {
            return _by;
        }

        public Configuration To()
        {
            return _to;
        }
    }
}
