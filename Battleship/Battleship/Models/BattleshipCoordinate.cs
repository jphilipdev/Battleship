namespace Battleship.Models
{
    public class BattleshipCoordinate
    {
        public BattleshipCoordinate(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public Coordinate Coordinate { get; }

        public bool Hit { get; set; }
    }
}
