using GameProject.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    class GameLibraryManager
    {
        //GameLibrary game1 = new GameLibrary() { Id = 1, Name = "CS:GO", Price = 35 };
        //GameLibrary game2 = new GameLibrary() { Id = 2, Name = "Grand Theft Auto 5", Price = 105 };
        //GameLibrary game3 = new GameLibrary() { Id = 3, Name = "Payday 2", Price = 35 };

        List<GameLibrary> gameLibraries;

        public GameLibraryManager()
        {
            gameLibraries = new List<GameLibrary>();
        }

        public void AddGame(GameLibrary gameLibrary)
        {
            gameLibraries.Add(gameLibrary);
            Console.WriteLine("Games of {0} added", gameLibrary.Name);
        }

        public void DeleteGame(GameLibrary gameLibrary)
        {
            gameLibraries.Remove(gameLibrary);
            Console.WriteLine("Games of {0} deleted", gameLibrary.Name);
        }
        public void RetrieveGameLibraryList()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Games\n");

            foreach (var games in gameLibraries)
            {
                Console.WriteLine("Game Name : " + games.Name);
                Console.WriteLine("Game Price : " + games.Price + "TL");
            }
            Console.WriteLine("**********************************");
        }

        
    }
}
