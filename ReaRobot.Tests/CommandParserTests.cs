using ReaRobot.Commands;
using ReaRobot.Model;
using Xunit;

namespace ReaRobot.Tests
{
    public class CommandParserTests
    {
        private Configuration _dummyConfiguration;

        public CommandParserTests()
        {
            _dummyConfiguration = new Configuration(0, 0, Direction.NORTH);
        }

        [Fact]
        public void TestLeft()
        {
            AbstractBaseCommand command = CommandParser.Command("LEFT");
            Assert.True(command is LeftCommand);
        }

        [Fact]
        public void TestMove()
        {
            AbstractBaseCommand command = CommandParser.Command("MOVE");
            Assert.True(command is MoveCommand);
        }

        [Fact]
        public void TestPlace()
        {
            AbstractBaseCommand command = CommandParser.Command("PLACE 0,0,NORTH");
            Assert.True(command is PlaceCommand);
        }

        [Fact]
        public void TestReport()
        {
            AbstractBaseCommand command = CommandParser.Command("REPORT");
            Assert.True(command is ReportCommand);
        }

        [Fact]
        public void TestRight()
        {
            AbstractBaseCommand command = CommandParser.Command("RIGHT");
            Assert.True(command is RightCommand);
        }

        [Fact]
        public void TestValidPlace()
        {
            AbstractBaseCommand command = CommandParser.Command("PLACE 0,0,NORTH");
            Configuration configuration = command.Apply(_dummyConfiguration);
            Assert.Equal(new Configuration(0, 0, Direction.NORTH), configuration);
        }


        [Fact]
        public void TestInvalidPlace()
        {
            AbstractBaseCommand command = CommandParser.Command("PLACE4,2,EAST");
            Configuration configuration = command.Apply(_dummyConfiguration);
            Assert.Equal(_dummyConfiguration, configuration);
        }
    }
}
