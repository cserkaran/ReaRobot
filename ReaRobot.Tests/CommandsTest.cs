using ReaRobot.Commands;
using ReaRobot.Model;
using System.Drawing;
using Xunit;

namespace ReaRobot.Tests
{
    public class CommandTests
    {
        private Configuration _configuration;
        private Configuration _placeConfiguration;

        public CommandTests()
        {
            _configuration = new Configuration(new Point(2, 2), Direction.NORTH);
            _placeConfiguration = new Configuration(new Point(0, 0), Direction.SOUTH);
        }

        [Fact]
        public void TestLeftCommand()
        {
            Assert.Equal(new Configuration(2, 2, Direction.WEST),
                    new LeftCommand().Apply(_configuration));
        }

        [Fact]
        public void TestMoveCommand()
        {
            Assert.Equal(new Configuration(2, 3, Direction.NORTH),
                    new MoveCommand().Apply(_configuration));
        }

        [Fact]
        public void TestPlaceCommand()
        {
            Assert.Equal(_placeConfiguration,
                    new PlaceCommand(_placeConfiguration).Apply(_placeConfiguration));
        }

        [Fact]
        public void TestReportCommand()
        {
            Assert.Equal(new Configuration(2, 2, Direction.NORTH),
                    new ReportCommand().Apply(_configuration));
        }

        [Fact]
        public void TestRightCommand()
        {
            Assert.Equal(new Configuration(2, 2, Direction.EAST),
                    new RightCommand().Apply(_configuration));
        }
    }
}
