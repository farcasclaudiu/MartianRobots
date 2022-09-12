namespace MartianRobotsSolver
{
    public interface IRobotCommand
    {
        public string Command { get; }

        public void Process(RobotInfo robotInfo);
    }
}
