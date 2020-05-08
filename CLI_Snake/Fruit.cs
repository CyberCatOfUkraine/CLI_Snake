using System;

namespace CLI_Snake
{
    public class Fruit : IGameObject
    {
        public Point Position { get; set; }

        private const char Symbol = '@';

        public Fruit()
        {
            SetPosition();
        }

        public void Spawn()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Symbol);
        }
        public void ReSpawn()
        {
            
            
            Spawn();
        }

        private void SetPosition()
        {
            var posX = new Random().Next(Console.WindowLeft, Console.WindowWidth);
            var posY = new Random().Next(Console.WindowTop, Console.WindowHeight);
            Position = new Point(posX, posY);
        }
    }
}
