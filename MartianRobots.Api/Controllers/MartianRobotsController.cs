using MartianRobots.Api.Data;
using MartianRobotsSolver;
using Microsoft.AspNetCore.Mvc;

namespace MartianRobots.Api.Controllers
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
        [HttpPost("Solves Martian Robots")]
        [Route("Solve")]
        public IActionResult Solve([FromBody] string input)
        {
            var result = new MarsSolver().Process(input);
            storage.Add(result);
            return Ok(result);
        }

        [HttpGet("Get the list of solutions")]
        [Route("List")]
        public IActionResult GetLastSolved()
        {
            return Ok(storage.List());
        }
    }
}