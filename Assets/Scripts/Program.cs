using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Character Creation
            Console.WriteLine("Welcome to Zombie Survival RPG!");
            Console.WriteLine("Please enter your character's name:");
            string playerName = Console.ReadLine();
            GameEntity player = new GameEntity(new Stat(100, 100), new Stat(100, 100), new Stat(100, 100), new Stat(100, 100), new Stat(100, 100), new Stat(100, 100), 0, 0, 0);
            Console.WriteLine($"Welcome, {playerName}!");

            // Main Game Loop
            bool gameRunning = true;
            while (gameRunning)
            {
                Console.WriteLine("What would you like to do?");
                string action = Console.ReadLine();

                switch (action.ToLower())
                {
                    case "quit":
                        gameRunning = false;
                        break;
                    case "status":
                        Console.WriteLine("Displaying player status...");
                        // Display player stats
                        break;
                    case "move":
                        Console.WriteLine("Where would you like to move?");
                        // Handle movement
                        break;
                    default:
                        Console.WriteLine("Invalid action. Try again.");
                        break;
                }
            }
        }
    }