namespace MartianRobots.Web.Shared
{
    public class RobotSolutionModel
    {
        public RobotSolutionModel()
        {
            DateTimeStamp = DateTime.UtcNow;
        }

        public string Input { get; set; }
        public string Output { get; set; }
        public int RobotLosts { get; set; }

        public DateTime DateTimeStamp { get; set; }
    }
}
