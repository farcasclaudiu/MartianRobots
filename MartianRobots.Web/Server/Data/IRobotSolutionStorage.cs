using MartianRobots.Web.Shared;
using MartianRobotsSolver;

namespace MartianRobots.Web.Server.Data
{
    public interface IRobotSolutionStorage
    {
        void Add(RobotSolutionModel solution);
        List<RobotSolutionModel> List();
    }
}