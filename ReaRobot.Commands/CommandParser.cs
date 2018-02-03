using ReaRobot.Model;
using System;
using System.Text.RegularExpressions;

namespace ReaRobot.Commands
{
    public class CommandParser
    {
        private static readonly string LEFT = "LEFT";
        private static readonly string MOVE = "MOVE";
        private static readonly String PLACE_PREFIX = "PLACE";
        private static readonly Regex PLACE_REGEX = new Regex(PLACE_PREFIX + " (\\d+),(\\d+),(\\w+)");

        private static readonly string REPORT = "REPORT";
        private static readonly string RIGHT = "RIGHT";
        private static readonly string NORTH = "NORTH";
        private static readonly string EAST = "EAST";
        private static readonly string SOUTH = "SOUTH";
        private static readonly string WEST = "WEST";

        public static AbstractBaseCommand Command(string commandString)
        {
            if (string.IsNullOrWhiteSpace(commandString))
            {
                Console.WriteLine("Empty command");
                return new NullCommand();
            }
            else if (commandString.Equals(LEFT))
            {
                return new LeftCommand();
            }
            else if (commandString.Equals(MOVE))
            {
                return new MoveCommand();
            }
            else if (commandString.StartsWith(PLACE_PREFIX))
            {
                return ParsePlaceCommand(commandString);
            }
            else if (commandString.Equals(REPORT))
            {
                return new ReportCommand();
            }
            else if (commandString.Equals(RIGHT))
            {
                return new RightCommand();
            }
            else
            {
                Console.WriteLine("Unknown command: " + commandString + "; doing nothing.");
                return new NullCommand();
            }
        }

        private static AbstractBaseCommand ParsePlaceCommand(String commandString)
        {
            Match matcher = PLACE_REGEX.Match(commandString);
            if (matcher.Success)
            {
                return ProducePlaceCommand(matcher);
            }
            else
            {
                Console.WriteLine("Unknown command: " + commandString + "; doing nothing.");
                return new NullCommand();
            }
        }

        private static AbstractBaseCommand ProducePlaceCommand(Match matcher)
        {
            try
            {
                return new PlaceCommand(
                        int.Parse(matcher.Groups[0].Value),
                        int.Parse(matcher.Groups[1].Value),
                        ParsePlaceCommandDirection(matcher.Groups[2].Value)
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new NullCommand();
            }
        }

        private static Direction ParsePlaceCommandDirection(String directionString)
        {
            if (string.IsNullOrWhiteSpace(directionString))
            {
                throw new InvalidOperationException("Empty orientation");
            }
            else if (directionString.Equals(NORTH))
            {
                return Direction.NORTH;
            }
            else if (directionString.Equals(EAST))
            {
                return Direction.EAST;
            }
            else if (directionString.Equals(SOUTH))
            {
                return Direction.SOUTH;
            }
            else if (directionString.Equals(WEST))
            {
                return Direction.WEST;
            }
            else
            {
                throw new InvalidOperationException("Unknown direction: " + directionString);
            }
        }
    }
}
