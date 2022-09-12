using MartianRobots.Web.Server.Data;
using MartianRobots.Web.Shared;
using MartianRobotsSolver;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MartianRobots.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MartianRobotsController : ControllerBase
    {
        private readonly ILogger<MartianRobotsController> logger;
        private readonly IRobotSolutionStorage storage;

        public MartianRobotsController(ILogger<MartianRobotsController> logger, IRobotSolutionStorage storage)
        {
            this.logger = logger;
            this.storage = storage;
        }

        /// <summary>
        /// Solves Martian Robots
        /// </summary>
        /// <param name="input"></param>
        /// <example>"5 3\n1 1 E\nRFRFRFRF\n3 2 N\nFRRFLLFFRRFLL\n0 3 W\nLLFFFRFLFL"</example>
        /// <returns></returns>
        [HttpPost("Solve")]
        [Description("Solves Martian Robots")]
        public IActionResult Solve([FromBody] string input)
        {
            var result = new MarsSolver().Process(input);
            var model = new RobotSolutionModel { 
                Input = result.Input, 
                Output = result.Output,
                RobotLosts = result.Robots.Count(r=>r.IsLost)
            };
            storage.Add(model);
            return Ok(model);
        }

        /// <summary>
        /// Get the list of solutions
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Description("Get the list of solutions")]
        public IActionResult GetList()
        {
            return Ok(storage.List());
        }

        /// <summary>
        /// Number of all lost robots
        /// </summary>
        /// <returns></returns>
        [HttpGet("LostRobots")]
        [Description("Number of all lost robots")]
        public IActionResult LostRobots()
        {
            return Ok(storage.List().Sum(r=>r.RobotLosts));
        }
    }
}