using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaRobot.Model;

namespace ReaRobot.Commands
{
    public class NullCommand : AbstractBaseCommand
    {
        protected override Configuration ApplyInternal(Configuration input)
        {
            return input;
        }
    }
}
