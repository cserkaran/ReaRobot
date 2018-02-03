using ReaRobot.Commands;
using ReaRobot.Model;
using System.Drawing;

namespace ReaRobot.Builder
{
    public interface IRobot
    {
        Transition Apply(AbstractBaseCommand command);

        Configuration Configuration();

        Point Boundary();
    }
}
