using MartianRobots.Web.Shared;

namespace MartianRobots.Web.Server.Data
{
    public class RobotSolutionStorage : IRobotSolutionStorage
    {
        private List<RobotSolutionModel> solutions = new List<RobotSolutionModel>
        {
            new RobotSolutionModel{ Input = "5 3\n1 1 E\nRFRFRFRF\n3 2 N\nFRRFLLFFRRFLL\n0 3 W\nLLFFFRFLFL" }
        };

        public void Add(RobotSolutionModel solution)
        {
            solutions.Insert(0,solution);
        }

        public List<RobotSolutionModel> List()
        {
            return solutions;
        }
    }
}
