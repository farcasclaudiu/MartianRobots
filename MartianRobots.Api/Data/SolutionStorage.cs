using MartianRobotsSolver;

namespace MartianRobots.Api.Data
{
    public class RobotSolutionStorage : IRobotSolutionStorage
    {
        private List<RobotSolution> solutions = new List<RobotSolution>
        {
            new RobotSolution{ Input = "5 3\n1 1 E\nRFRFRFRF\n3 2 N\nFRRFLLFFRRFLL\n0 3 W\nLLFFFRFLFL" }
        };

        public void Add(RobotSolution solution)
        {
            this.solutions.Add(solution);
        }

        public List<RobotSolution> List()
        {
            return solutions;
        }
    }
}
