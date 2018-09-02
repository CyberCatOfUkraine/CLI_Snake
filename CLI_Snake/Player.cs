using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Snake
{
    public class Player : IGameObject
    {
        public Point Position { get; set; }

        private char _symbol;

        public Player()
        {
            var centerX = (Console.WindowLeft + Console.WindowWidth) / 2;
            var centerY = (Console.WindowTop + Console.WindowHeight) / 2;
            Position = new Point(centerX, centerY);
            _symbol = '&';
        }

        public void Spawn()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(_symbol);
        }
        public void Move(Directions direction)
        {
            switch (direction)
            {
                case Directions.Left:
                    Position.X--;
                    break;
                case Directions.Right:
                    Position.X++;
                    break;
                case Directions.Up:
                    Position.Y--;
                    break;
                case Directions.Down:
                    Position.Y++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}
