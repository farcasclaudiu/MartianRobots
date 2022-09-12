namespace MartianRobotsSolver
{
    public class RobotCommandLeft : IRobotCommand
    {
        public string Command => "L";

        public void Process(RobotInfo robotInfo)
        {
            var hIndex = RobotCommandConstants.HEADING.IndexOf(robotInfo.Head)-1;
            if(hIndex<0)
                hIndex = RobotCommandConstants.HEADING.Length-1;
            robotInfo.Head = RobotCommandConstants.HEADING[hIndex].ToString();
        }
    }
}
