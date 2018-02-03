using ReaRobot.Model;

namespace ReaRobot.Commands
{
    public class RightCommand : AbstractBaseCommand
    {
        protected override Configuration ApplyInternal(Configuration input)
        {
            return new Configuration(input.Position(), input.Direction().Right());
        }
    }
}
