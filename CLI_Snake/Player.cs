using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI_Snake
{
    public class Player : IGameObject
    {
        public Point Position { get; set; }

        private char _symbol;
        private char _tailSymbol;
        private Direction _currentDirection;
        private List<Point> _tailParts;
        private bool isNewTailPartWasAdded;
        private Point previousPoint;

        public Player()
        {
            var centerX = (Console.WindowLeft + Console.WindowWidth) / 2;
            var centerY = (Console.WindowTop + Console.WindowHeight) / 2;
            Position = new Point(centerX, centerY);
            previousPoint = new Point(centerX+1, centerY);
            _symbol = '█';
            _tailSymbol = '#';
            _currentDirection = Direction.Left;
            _tailParts = new List<Point>();
            isNewTailPartWasAdded = false;
        }

        public void Spawn()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(_symbol);
            Point lastPart = null;
            if (_tailParts.Count > 0)
                lastPart = _tailParts.Last();
            foreach (var tailPart in _tailParts)
            {
                if (isNewTailPartWasAdded && tailPart.Equals(lastPart))
                {
                    isNewTailPartWasAdded = false;
                    continue;
                }
                Console.SetCursorPosition(tailPart.X, tailPart.Y);
                Console.Write(_tailSymbol);
            }
        }
        public void Move()
        {
            previousPoint = new Point(Position);
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

            var newPos = new Point(previousPoint);
            foreach (var part in _tailParts)
            {
                var temp = new Point(part);
                part.Change(newPos);
                newPos = temp;
            }
        }
        public void ChangeDirection(Direction direction)
        {
            _currentDirection = direction;
        }
        public void IncreaseLength()
        {
            _tailParts.Add(previousPoint);
            isNewTailPartWasAdded = true;
        }
    }
}
