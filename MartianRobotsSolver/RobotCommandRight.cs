namespace MartianRobotsSolver
{
    public class RobotCommandRight : IRobotCommand
    {
        public string Command => "R";

        public void Process(RobotInfo robotInfo)
        {
            var hIndex = RobotCommandConstants.HEADING.IndexOf(robotInfo.Head)+1;
            if(hIndex>RobotCommandConstants.HEADING.Length-1)
                hIndex = 0;
            robotInfo.Head = RobotCommandConstants.HEADING[hIndex].ToString();
        }
    }
}
