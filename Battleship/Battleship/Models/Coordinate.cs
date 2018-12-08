namespace Battleship.Models
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override bool Equals(object obj)
        {
            var coordinate = obj as Coordinate;
            if(coordinate == null)
            {
                return false;
            }

            return coordinate.X == X && coordinate.Y == Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
