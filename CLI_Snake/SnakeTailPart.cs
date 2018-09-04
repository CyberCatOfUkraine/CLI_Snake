using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Snake
{
    public class SnakeTailPart : IGameObject
    {
        public Point Position { get; set; }

        public SnakeTailPart(Point coords)
        {
            Position = new Point(coords);
        }

        public void Spawn()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write('#');
        }
    }
}
