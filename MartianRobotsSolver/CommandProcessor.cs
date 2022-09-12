using System.Reflection;

namespace MartianRobotsSolver
{
    public class CommandProcessor
    {
        private Dictionary<string, IRobotCommand> processors = new Dictionary<string, IRobotCommand>();

        public CommandProcessor()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => !t.IsAbstract && t.IsAssignableTo(typeof(IRobotCommand)))
                .Select(t =>
                {
                    IRobotCommand? command = Activator.CreateInstance(t) as IRobotCommand;
                    if(command != null)
                        processors.Add(command.Command, command);
                    return command;
                })
                .ToList();
        }

        public void Process(RobotInfo robotInfo, string cmd)
        {
            
            if (processors.ContainsKey(cmd))
            {
                processors[cmd].Process(robotInfo);
            } else { 
                    throw new NotSupportedException($"cmd {cmd} is not supported.");
            }
        }
    }
}
