using System;

namespace CLI_Snake
{
    partial class Program
    {
        private static void ProcessPressedButtons()
        {
            var pressedKey = Console.ReadKey();
            switch (pressedKey.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    _playerObject.ChangeDirection(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    _playerObject.ChangeDirection(Direction.Right);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    _playerObject.ChangeDirection(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    _playerObject.ChangeDirection(Direction.Down);
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
                    switch (gameObject)
                    {
                        case Fruit _:
                            _score++;
                            var fruit = gameObject as Fruit;
                            fruit.Respawn();
                            if (_delayPerFrame > MinDelayPerFrame)
                                _delayPerFrame -= 10;
                            gameObjects.Add(_playerObject.IncreaseLength());
                            return;
                        case SnakeTailPart _:
                            _isGameFinished = true;
                            return;
                    }
                }
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
            var gameOverText = "Game Over";
            Console.SetCursorPosition(centerX - gameOverText.Length / 2, centerY);
            Console.WriteLine(gameOverText);
            var gameOverScore = $"Your score: {_score}";
            Console.SetCursorPosition(centerX - gameOverScore.Length / 2, centerY + 1);
            Console.WriteLine(gameOverScore);
        }
    }
}
