using Ardalis.GuardClauses;
using System.Text;

namespace MartianRobotsSolver
{
    public class MarsSolver
    {
        public RobotSolution Process(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            //extract world info
            var wInfo = lines[0].Split(" ");
            var sizeX = Convert.ToInt32(wInfo[0]);
            var sizeY = Convert.ToInt32(wInfo[1]);
            var worldInfo = new WorldInfo(sizeX, sizeY);
            var robotSolution = new RobotSolution()
            {
                Input = input,
                WorldInfo = worldInfo
            };

            //map robots info and commands
            for (int i = 0; i < (lines.Count - 1)/2; i++)
            {
                var rInfo = lines[1 + i*2].Split(" ");
                var rPosX = Convert.ToInt32(rInfo[0]);
                var rPosY = Convert.ToInt32(rInfo[1]);
                var rHead = rInfo[2];

                var robotCommands = lines[2 + i*2];
                Guard.Against.InvalidInput(robotCommands, nameof(robotCommands), rc => rc.Length<100);
                var robotInfo = new RobotInfo(rPosX, rPosY, rHead, robotCommands);
                robotSolution.Robots.Add(robotInfo);
            }

            //process commands
            var navigator = new MarsNavigator(worldInfo);
            StringBuilder sb = new StringBuilder();
            foreach (var robotInfo in robotSolution.Robots)
            {
                if (sb.Length>0)
                    sb.Append(Environment.NewLine);
                sb.Append(navigator.Navigate(robotInfo));
            }

            //store output
            robotSolution.Output = sb.ToString();

            return robotSolution;
        }
    }
}