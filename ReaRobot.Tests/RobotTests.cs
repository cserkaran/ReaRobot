using ReaRobot.Builder;
using ReaRobot.Commands;
using ReaRobot.Model;
using System.Drawing;
using Xunit;

namespace ReaRobot.Tests
{
    public class RobotTests
    {
        private Robot robot;

        public RobotTests()
        {
            robot = new RobotBuilder()
                    .MandatoryNorthEastBoundary(new Point(2, 2))
                    .OptionalInitialConfiguration(new Configuration(new Point(0, 0), Direction.NORTH))
                    .Build();
        }

        [Fact]
        public void TestMove()
        {
            robot.Apply(new PlaceCommand(0, 0, Direction.NORTH));
            Transition transition = robot.Apply(new MoveCommand());
            Assert.Equal(new Configuration(0, 1, Direction.NORTH), transition.To());
        }

        [Fact]
        public void TestBoundary()
        {
            robot.Apply(new PlaceCommand(0, 0, Direction.NORTH));
            robot.Apply(new MoveCommand());
            Transition transition = this.robot.Apply(new MoveCommand());
            Assert.Equal(new Configuration(0, 1, Direction.NORTH), transition.To());
        }

        [Fact]
        public void TransitionToEqualsConfigurationA()
        {
            Transition transition = robot.Apply(new PlaceCommand(0, 0, Direction.NORTH));
            Assert.Equal(robot.Configuration(), transition.To());
        }

        [Fact]
        public void TransitionToEqualsConfigurationB()
        {
            robot.Apply(new PlaceCommand(0, 0, Direction.NORTH));
            Transition transition = this.robot.Apply(new MoveCommand());
            Assert.Equal(robot.Configuration(), transition.To());
        }
    }
}
