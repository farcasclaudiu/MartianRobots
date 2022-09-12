using Ardalis.GuardClauses;

namespace MartianRobotsSolver
{
    public class WorldInfo
    {
        private List<(int X,int Y)> scents = new List<(int X, int Y)>();
        public WorldInfo(int sizeX, int sizeY)
        {
            Guard.Against.OutOfRange(sizeX, nameof(sizeX), 0, 50);
            Guard.Against.OutOfRange(sizeY, nameof(sizeY), 0, 50);
            this.SizeX=sizeX;
            this.SizeY=sizeY;
        }

        public int SizeX { get; internal set; }
        public int SizeY { get; internal set; }

        internal void AddScent(int posX, int posY)
        {
            if(!HasScent(posX, posY))
                scents.Add((posX, posY));
        }

        internal bool HasScent(int posX, int posY)
        {
            return scents.Contains((posX, posY));
        }
    }
}