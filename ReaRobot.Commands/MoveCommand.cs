using ReaRobot.Model;
using System;

namespace ReaRobot.Commands
{
    public class MoveCommand : AbstractBaseCommand
    {
        protected override Configuration ApplyInternal(Configuration input)
        {
            switch (input.Direction())
            {
                case Direction.NORTH:
                    return new Configuration(input.Position().X, input.Position().Y + 1, input.Direction());
                case Direction.EAST:
                    return new Configuration(input.Position().X + 1, input.Position().Y, input.Direction());
                case Direction.SOUTH:
                    return new Configuration(input.Position().X, input.Position().Y - 1, input.Direction());
                case Direction.WEST:
                    return new Configuration(input.Position().X - 1, input.Position().Y, input.Direction());
                default:
                    Console.WriteLine("Direction unknown: " + input.Direction() + ", will not move.");
                    return input;
            }
        }
    }
}
