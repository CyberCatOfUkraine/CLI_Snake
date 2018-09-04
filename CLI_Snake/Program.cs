using System;
using System.Collections.Generic;
using System.Threading;

namespace CLI_Snake
{
    partial class Program
    {
        private static List<IGameObject> gameObjects = new List<IGameObject>();
        private static bool _isFruitSpawned;
        private static bool _isPlayerSpawned;
        private static bool _isGameFinished;
        private static Player _playerObject;
        private static int _delayPerFrame = 200;
        private const int MinDelayPerFrame = 50;
        private static uint _score;

        static void Main()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Press any key to start game...");
            Console.ReadKey();

            while (!_isGameFinished)
            {
                Update();
            }

            ShowGameResults();
        }

        // Main game's logic loop
        private static void Update()
        {
            // Logic here

            // Spawn player
            if (!_isPlayerSpawned)
            {
                SpawnPlayer();
            }
            // Spawn/Respawn fruit
            if (!_isFruitSpawned)
            {
                SpawnFruit();
            }

            if (Console.KeyAvailable)
            {
                ProcessPressedButtons();
            }

            ProcessCollision();
            _playerObject.Move();

            if (IsGameOver())
            {
                _isGameFinished = true;
                return;
            }

            // When all completed — call Draw process
            Draw();
            Thread.Sleep(_delayPerFrame);
        }
        // Main game's draw loop
        private static void Draw()
        {
            Console.Clear();

            foreach (var gameObject in gameObjects)
            {
                gameObject.Spawn();
            }

            // Reset cursor
            Console.SetCursorPosition(0, 0);
        }
    }
}
