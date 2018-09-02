using System;
using System.Collections.Generic;
using System.Threading;

namespace CLI_Snake
{
    class Program
    {
        private static List<IGameObject> gameObjects = new List<IGameObject>();
        private static bool isFruitSpawned = default;

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start game...");
            Console.ReadKey();

            Update();

            Console.ReadKey();
        }

        // Main game's logic loop
        private static void Update()
        {
            // Logic here
            if (!isFruitSpawned)
            {
                Fruit newFruit = new Fruit();
                gameObjects.Add(newFruit);
                isFruitSpawned = true;
            }
            // When all completed — call Draw process
            Draw();
            Thread.Sleep(100);
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
