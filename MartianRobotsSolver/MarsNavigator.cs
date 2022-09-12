using Ardalis.GuardClauses;

namespace MartianRobotsSolver
{
    public class MarsNavigator
    {
        private WorldInfo worldInfo;

        private CommandProcessor commandProcessor = new CommandProcessor();
        public MarsNavigator(WorldInfo worldInfo)
        {
            this.worldInfo=worldInfo;
        }

        public string Navigate(RobotInfo robotInfo)
        {
            //validate robot coordintates in world
            Guard.Against.InvalidInput(robotInfo, nameof(robotInfo), ri => { 
                return ri.PosX<= worldInfo.SizeX || ri.PosY <= worldInfo.SizeY; 
            });

            foreach (var cmd in robotInfo.Commands)
            {
                //save old coords
                var oldPosX = robotInfo.PosX;
                var oldPosY = robotInfo.PosY;

                //process command
                commandProcessor.Process(robotInfo, cmd.ToString());

                //check new robot coordintates in world
                if (robotInfo.PosX> worldInfo.SizeX || robotInfo.PosY > worldInfo.SizeY ||
                    robotInfo.PosX<0 || robotInfo.PosY<0)
                {
                    //revert to previous values
                    robotInfo.PosX = oldPosX;
                    robotInfo.PosY = oldPosY;

                    if (!worldInfo.HasScent(oldPosX, oldPosY))
                    {
                        robotInfo.IsLost = true;
                        //add scent
                        worldInfo.AddScent(robotInfo.PosX, robotInfo.PosY);
                        //exit loop
                        break;
                    }
                    
                }
            }

            return robotInfo.ToString();
        }
    }
}