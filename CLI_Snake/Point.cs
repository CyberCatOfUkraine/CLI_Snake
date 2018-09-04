namespace CLI_Snake
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Create 2D point with coordinates (X;Y)
        /// </summary>
        /// <param name="posX">X coordinate (row)</param>
        /// <param name="posY">Y coordinate (column)</param>
        public Point(int posX, int posY)
        {
            X = posX;
            Y = posY;
        }
        public Point(Point newPoint)
        {
            X = newPoint.X;
            Y = newPoint.Y;
        }

        public void Change(Point newPoint)
        {
            X = newPoint.X;
            Y = newPoint.Y;
        }

        public override bool Equals(object point)
        {
            var cmpPoint = (Point) point;
            if (cmpPoint == null)
                return false;
            return X == cmpPoint.X && Y == cmpPoint.Y;
        }
    }
}
