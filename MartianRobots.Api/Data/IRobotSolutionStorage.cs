using MartianRobotsSolver;

namespace MartianRobots.Api.Data
{
    public interface IRobotSolutionStorage
    {
        void Add(RobotSolution solution);
        List<RobotSolution> List();
    }
}