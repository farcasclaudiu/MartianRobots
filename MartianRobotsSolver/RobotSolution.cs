namespace MartianRobotsSolver
{
    public class RobotSolution
    {
        public WorldInfo WorldInfo { get; internal set; }
        public string Input { get; set; }
        public List<RobotInfo> Robots { get; internal set; } = new List<RobotInfo>();
        public string Output { get; internal set; }

        public DateTime DateTimeStamp { get; }
    }
}
