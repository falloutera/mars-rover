namespace MarsRover
{
    public class Terrain{
        public Terrain(int coordinateX, int coordinateY) => (_coordinateX, _coordinateY) = (coordinateX, coordinateY);
        private readonly int _coordinateX;
        private readonly int _coordinateY;
        public bool AvailableToMove(int coordinateX, int coordinateY)=> !(coordinateX> _coordinateX || coordinateY > _coordinateY || _coordinateY < 0 || _coordinateX < 0);
    }
}