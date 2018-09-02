namespace CLI_Snake
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Create 2D point with coordinates (X;Y)
        /// </summary>
        /// <param name="posX">X coordinate</param>
        /// <param name="posY">Y coordinate</param>
        public Point(int posX, int posY)
        {
            X = posX;
            Y = posY;
        }
    }
}
