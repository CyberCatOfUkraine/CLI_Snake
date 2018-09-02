using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Snake
{
    partial class Program
    {
        private static void ProcessPressedButtons()
        {
            var pressedKey = Console.ReadKey();
            if (_playerObject == null) return;
            switch (pressedKey.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    _playerObject.Move(Directions.Left);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    _playerObject.Move(Directions.Right);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    _playerObject.Move(Directions.Up);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    _playerObject.Move(Directions.Down);
                    break;
                case ConsoleKey.Escape:
                    _isGameFinished = true;
                    break;
            }
        }
        private static void SpawnPlayer()
        {
            var player = new Player();
            gameObjects.Add(player);
            _playerObject = player;
            _isPlayerSpawned = true;
        }
        private static void SpawnFruit()
        {
            var newFruit = new Fruit();
            gameObjects.Add(newFruit);
            _isFruitSpawned = true;
        }
        private static void ProcessCollision()
        {
            if (_playerObject == null) return;
            var playerPos = _playerObject.Position;
            foreach (var gameObject in gameObjects)
            {
                var objectPos = gameObject.Position;
                if (playerPos.X == objectPos.X && playerPos.Y == objectPos.Y)
                {
                    if (gameObject is Fruit)
                    {
                        var fruit = gameObject as Fruit;
                        fruit.Respawn();
                    }
                }
            }
        }
    }
}
