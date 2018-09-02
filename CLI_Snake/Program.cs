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

        static void Main()
        {
            Console.WriteLine("Press any key to start game...");

            while (!_isGameFinished)
            {
                Update();
            }

            Console.ReadKey();
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

            ProcessPressedButtons();

            // When all completed — call Draw process
            Draw();
            Thread.Sleep(10);
        }
        // Main game's draw loop
        private static void Draw()
        {
            Console.Clear();

            foreach (var gameObject in gameObjects)
            {
                gameObject.Spawn();
            }

            // Hide cursor
            Console.SetCursorPosition(0, 0);
        }
    }
}
