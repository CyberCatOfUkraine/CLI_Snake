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
        private Direction _currentDirection;

        public Player()
        {
            var centerX = (Console.WindowLeft + Console.WindowWidth) / 2;
            var centerY = (Console.WindowTop + Console.WindowHeight) / 2;
            Position = new Point(centerX, centerY);
            _symbol = '&';
            _currentDirection = Direction.Left;
        }

        public void Spawn()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(_symbol);
        }
        public void Move()
        {
            switch (_currentDirection)
            {
                case Direction.Left:
                    Position.X--;
                    break;
                case Direction.Right:
                    Position.X++;
                    break;
                case Direction.Up:
                    Position.Y--;
                    break;
                case Direction.Down:
                    Position.Y++;
                    break;
            }
        }
        public void ChangeDirection(Direction direction)
        {
            _currentDirection = direction;
        }
    }
}
