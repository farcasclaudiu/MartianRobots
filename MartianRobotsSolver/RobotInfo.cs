using Ardalis.GuardClauses;

namespace MartianRobotsSolver
{
    public class RobotInfo
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Head { get; set; }
        public string Commands { get; }
        public bool IsLost { get; set; } = false;

        public RobotInfo(int posX, int posY, string head, string commands)
        {
            Guard.Against.Negative(posX, nameof(posX));
            Guard.Against.Negative(posY, nameof(posX));
            this.PosX = posX;
            this.PosY = posY;
            this.Head = head;
            this.Commands = commands;
        }

        public override string ToString()
        {
            return $"{PosX} {PosY} {Head}{ (IsLost ? " LOST" : string.Empty) }";
        }
    }
}