using ReaRobot.Builder;
using System.Drawing;
using System;
using System.IO;
using System.Collections.Generic;
using ReaRobot.Commands;
using ReaRobot.Model;

namespace ReaRobot.Console
{
    class Program
    {
        private static readonly Point _boundary = new Point(4, 4);

        static void Main(string[] args)
        {
            Robot robot = BuildRobot();
            RunSimulator(robot);
            System.Console.Read();
        }

        private static void RunSimulator(Robot robot)
        {
            List<string> files = new List<string> { "A", "B", "C" };
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            foreach(var file in files)
            {
                var filePath = path + "\\Resources\\" + file + ".txt";
                
                using (StreamReader r = new StreamReader(filePath))
                {
                    while (!r.EndOfStream)
                    {
                        var commandString = r.ReadLine();
                        AbstractBaseCommand command = CommandParser.Command(commandString);
                        robot.Apply(command);
                    }

                    System.Console.WriteLine(robot.Configuration());
                }
            }

        }

        private static Robot BuildRobot()
        {
            return new RobotBuilder()
                    .MandatoryNorthEastBoundary(_boundary)
                    .OptionalInitialConfiguration(new Configuration(new Point(0, 0), Direction.NORTH))
                    .Build();
        }
    }
}
