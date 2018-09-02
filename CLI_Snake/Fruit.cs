using System;

namespace CLI_Snake
{
    public class Fruit : IGameObject
    {
        public Point Position { get; set; }

        private char _symbol;

        public Fruit()
        {
            var rand = new Random();
            var posX = rand.Next(Console.WindowLeft, Console.WindowWidth);
            var posY = rand.Next(Console.WindowTop, Console.WindowHeight);
            Position = new Point(posX, posY);
            _symbol = '@';
        }
        public Fruit(char symbol, Point position)
        {
            _symbol = symbol;
            Position = position;
        }

        public void Spawn()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(_symbol);
        }
        public void Respawn()
        {
            var rand = new Random();
            var posX = rand.Next(Console.WindowLeft, Console.WindowWidth);
            var posY = rand.Next(Console.WindowTop, Console.WindowHeight);
            Position = new Point(posX, posY);
            Spawn();
        }
    }
}
