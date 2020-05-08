using System;
using System.Linq;

namespace CLI_Snake
{
    public static partial class Program
    {
        private static void ProcessPressedButtons()
        {
            var pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.LeftArrow || pressedKey.Key == ConsoleKey.A)
                _playerObject.ChangeDirection(Direction.Left);
            else if (pressedKey.Key == ConsoleKey.RightArrow || pressedKey.Key == ConsoleKey.D)
                _playerObject.ChangeDirection(Direction.Right);
            else if (pressedKey.Key == ConsoleKey.UpArrow || pressedKey.Key == ConsoleKey.W)
                _playerObject.ChangeDirection(Direction.Up);
            else if (pressedKey.Key == ConsoleKey.DownArrow || pressedKey.Key == ConsoleKey.S)
                _playerObject.ChangeDirection(Direction.Down);
            else if (pressedKey.Key == ConsoleKey.Escape) _isGameFinished = true;
        }
        private static void SpawnPlayer()
        {
            var player = new Player();
            _gameObjects.Add(player);
            _playerObject = player;
            _isPlayerSpawned = true;
        }
        private static void SpawnFruit()
        {
            _gameObjects.Add(new Fruit());
            _isFruitSpawned = true;
        }

        private static bool IsPositionOccupied(Point point)
        {
            return _gameObjects.Any(gameObject => gameObject.Position.Equals(point));
        }

        private static IGameObject GameObject
        {
            get
            {
                return _gameObjects.First(someGameObject => someGameObject.Position.X == _playerObject.Position.X &&
                                                            someGameObject.Position.Y == _playerObject.Position.Y);
            }
        }

        private static void ProcessCollision()
        {
            if (_playerObject == null) return;

                switch (GameObject)
                {
                    case Fruit o:
                        _score++;
                        var fruit = o;
                        // reSpawn fruit on FREE cell
                        do
                        {
                            fruit.ReSpawn();
                        } while (IsPositionOccupied(fruit.Position));

                        if (_delayPerFrame > MinDelayPerFrame)
                            _delayPerFrame -= 10;
                        _gameObjects.Add(_playerObject.IncreaseLength());
                        return;
                    case SnakeTailPart _:
                        _isGameFinished = true;
                        return;
                }
        }
        private static bool IsGameOver()
        {
            var playerPos = _playerObject.Position;
            var consoleSize = new Rectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
            return !consoleSize.IsIntersect(playerPos);
        }
        private static void ShowGameResults()
        {
            Console.Clear();
            var centerX = (Console.WindowLeft + Console.WindowWidth) / 2;
            var centerY = (Console.WindowTop + Console.WindowHeight) / 2;
            const string gameOverText = "Game Over";
            Console.SetCursorPosition(centerX - gameOverText.Length / 2, centerY);
            Console.WriteLine(gameOverText);
            var gameOverScore = $"Your score: {_score}";
            Console.SetCursorPosition(centerX - gameOverScore.Length / 2, centerY + 1);
            Console.WriteLine(gameOverScore);
        }
    }
}
