using ReaRobot.Model;

namespace ReaRobot.Commands
{
    public class ReportCommand : AbstractBaseCommand
    {
        protected override Configuration ApplyInternal(Configuration input)
        {
            return input;
        }
    }
}
