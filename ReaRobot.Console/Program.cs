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
        /// <summary>
        /// The boundary
        /// </summary>
        private static readonly Point _boundary = new Point(4, 4);

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Robot robot = BuildRobot();
            RunSimulator(robot);
            System.Console.Read();
        }

        /// <summary>
        /// Runs the simulator.
        /// </summary>
        /// <param name="robot">The robot.</param>
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

        /// <summary>
        /// Builds the robot.
        /// </summary>
        /// <returns>Built robot</returns>
        private static Robot BuildRobot()
        {
            return new RobotBuilder()
                    .MandatoryNorthEastBoundary(_boundary)
                    .OptionalInitialConfiguration(new Configuration(new Point(0, 0), Direction.NORTH))
                    .Build();
        }
    }
}
