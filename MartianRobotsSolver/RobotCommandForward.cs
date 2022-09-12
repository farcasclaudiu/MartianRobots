namespace MartianRobotsSolver
{
    public class RobotCommandForward: IRobotCommand
    {
        public string Command => "F";

        public void Process(RobotInfo robotInfo)
        {
            int deltaX = 0;
            int deltaY = 0;
            switch (robotInfo.Head)
            {
                case "N":
                    deltaY = 1;
                    break;
                case "S":
                    deltaY = -1;
                    break;
                case "E":
                    deltaX = 1;
                    break;
                case "W":
                    deltaX = -1;
                    break;
            }
            robotInfo.PosX += deltaX;
            robotInfo.PosY += deltaY;
        }
    }
}
